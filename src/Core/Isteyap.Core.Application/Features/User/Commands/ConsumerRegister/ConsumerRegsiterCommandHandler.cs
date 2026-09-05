using AutoMapper;
using Isteyap.Core.Application.IsteyapDbContext;
using Isteyap.Core.Application.Results;
using Isteyap.Core.Application.Services;
using Isteyap.Core.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Isteyap.Core.Application.Features
{
    public class ConsumerRegsiterCommandHandler : 
        IRequestHandler<ConsumerRegisterCommand, IResultControl>
    {
        private readonly IAppDbContext _appDbContext;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public ConsumerRegsiterCommandHandler(IAppDbContext appDbContext, IMapper mapper, IPasswordHasher passwordHasher, IMediator mediator)
        {
            _appDbContext = appDbContext;
            _mapper = mapper;
            _passwordHasher = passwordHasher;
            _mediator = mediator;
        }

        public async Task<IResultControl> Handle(ConsumerRegisterCommand request, CancellationToken cancellationToken)
        {
            var transaction = await _appDbContext.BeginTransactionAsync(cancellationToken);
            try
            {
                string email = request.Email.Trim().ToLowerInvariant();
                var emailExists = _appDbContext.User.Any(u => u.NormalizedEmail == email);
                if (emailExists)
                {
                    return ResultControl.FailError("EMAIL_ALREADY_EXISTS", "Belirtilen e-posta adresi halihazırda kayıtlı.");
                }

                var user = _mapper.Map<Isteyap.Core.Domain.Entities.User>(request);
                user.PasswordHash = _passwordHasher.Hash(request.Password);
                user.NormalizedEmail = email;
                user.Roles = new List<UserRole> { new UserRole { Role = Domain.Entities.Enums.IsteyapUserRoleEnum.ServiceConsumer } };
                user.CreateDate = DateTime.Now;
                user.State = EntityStateEnum.Online;
                user.IsEmailConfirmed = false;

                _appDbContext.User.Add(user);

                await _appDbContext.SaveChangesAsync(cancellationToken);
                await transaction.CommitAsync(cancellationToken);

                _mediator.Publish(new ConsumerRegisterEvent()
                {
                    Email = user.Email,
                    FullName = user.FullName,
                    VerificationLink = "your_verification_link_here"
                });

                return ResultControl.CreateSuccess();
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync(cancellationToken);
                throw ex;
            }
        }
    }
}
