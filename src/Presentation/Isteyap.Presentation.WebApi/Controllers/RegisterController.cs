using Isteyap.Core.Application.Dtos;
using Isteyap.Core.Application.Features;
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

        public RegisterController(ILogger<RegisterController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpPost("consumer")]
        public async Task<IActionResult> ConsumerRegister([FromBody] ConsumerRegisterReq request)
        {
            var result = await _mediator.Send(new ConsumerRegisterCommand()
            {
                Email = request.Email,
                Password = request.Password,
                FirstName = request.FirstName,
                LastName = request.LastName,
                PhoneNumber = request.PhoneNumber,
                ConfirmPassword = request.ConfirmPassword
            });

            return result.ToActionResult(this);
        }
    }
}
