using FluentValidation;
using Isteyap.Core.Application.Results;
using MediatR;
using System;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;

namespace Isteyap.Core.Application.Features.User.Commands
{

    public class ConsumerRegisterCommand : IRequest<IResultControl>
    {
        /// <summary>
        /// Kullanıcının ilk adı.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Kullanıcının soyadı.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Kullanıcının e-posta adresi.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Kullanıcının telefon numarası (opsiyonel).
        /// </summary>
        public string? PhoneNumber { get; set; }

        /// <summary>
        /// Düz metin parola (sunucu tarafında hashlenip saklanmalı).
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Parola doğrulama alanı.
        /// </summary>
        public string ConfirmPassword { get; set; }
    }

    public class ConsumerRegisterCommandValidator : AbstractValidator<ConsumerRegisterCommand>
    {
        public ConsumerRegisterCommandValidator()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("İsim boş olamaz.")
                .MaximumLength(100).WithMessage("İsim en fazla 100 karakter olabilir.");

            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("Soyisim boş olamaz.")
                .MaximumLength(100).WithMessage("Soyisim en fazla 100 karakter olabilir.");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("E-posta adresi zorunludur.")
                .EmailAddress().WithMessage("Geçerli bir e-posta adresi giriniz.")
                .MaximumLength(256).WithMessage("E-posta en fazla 256 karakter olabilir.");

            RuleFor(x => x.PhoneNumber)
                .MaximumLength(50).WithMessage("Telefon numarası en fazla 50 karakter olabilir.")
                .When(x => !string.IsNullOrWhiteSpace(x.PhoneNumber));

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Parola boş olamaz.")
                .MinimumLength(8).WithMessage("Parola en az 8 karakter olmalıdır.")
                .MaximumLength(128).WithMessage("Parola en fazla 128 karakter olabilir.")
                .Matches("[A-Z]").WithMessage("Parola en az bir büyük harf içermelidir.")
                .Matches("[a-z]").WithMessage("Parola en az bir küçük harf içermelidir.")
                .Matches("\\d").WithMessage("Parola en az bir rakam içermelidir.")
                .Matches("[\\p{P}\\p{S}]").WithMessage("Parola en az bir özel karakter içermelidir.");

            RuleFor(x => x.ConfirmPassword)
                .Equal(x => x.Password).WithMessage("Parolalar eşleşmiyor.");
        }
    }

    public class ConsumerRegsiterCommandHandler : IRequestHandler<ConsumerRegisterCommand, IResultControl>
    {
        public async Task<IResultControl> Handle(ConsumerRegisterCommand request, CancellationToken cancellationToken)
        {
            IResultControl result = new ResultControl();

            

            return ResultControl.CreateSuccess();
        }
    }
}
