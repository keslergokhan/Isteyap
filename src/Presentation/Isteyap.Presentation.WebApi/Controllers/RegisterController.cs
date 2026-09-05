using Isteyap.Core.Application.Dtos;
using Isteyap.Core.Application.Features;
using Isteyap.Core.Application.Services.Interfaces;
using Isteyap.Presentation.WebApi.Controllers.Base;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Isteyap.Presentation.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : AppControllerBase
    {
        private readonly ILogger<RegisterController> _logger;
        private readonly IMediator _mediator;
        private readonly IEmailService emailService;

        public RegisterController(ILogger<RegisterController> logger, IMediator mediator, IEmailService emailService)
        {
            _logger = logger;
            _mediator = mediator;
            this.emailService = emailService;
        }

        [HttpPost("consumer")]
        public async Task<IActionResult> ConsumerRegister([FromBody] ConsumerRegisterReq request, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new ConsumerRegisterCommand()
            {
                Email = request.Email,
                Password = request.Password,
                FirstName = request.FirstName,
                LastName = request.LastName,
                PhoneNumber = request.PhoneNumber,
                ConfirmPassword = request.ConfirmPassword
            },cancellationToken);

            return result.ToActionResult(this);
        }

        [HttpPost("eposta")]
        public async Task<IActionResult> eposta(CancellationToken cancellationToken)
        {
            await emailService.SendAsync(new Core.Application.Services.EmailMessage
            {
                To = "gkhnkslr34@gmail.com",
                Subject = "Şifre doğrulama",
                Body = "Oturum açma için 234234"
            });
            return Ok();
        }
    }
}
