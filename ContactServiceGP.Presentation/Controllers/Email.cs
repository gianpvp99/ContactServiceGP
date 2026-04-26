using ContactService.DTO.DTOs.Request;
using ContactServiceGP.Application.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ContactServiceGP.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class Email: ControllerBase
    {
        private readonly IMediator _mediator;
        public Email(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Route("SendEmail")]
        [HttpPost]
        public async Task<IActionResult> SendEmailAsync([FromBody] SendEmailReq request)
        {
            try
            {
                var response = await _mediator.Send(
                    new SendEmailCommand { fullname = request.fullname, email = request.email, message = request.message, phone = request.phone});
                return Ok(response);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }
    }
}
