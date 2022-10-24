using Domain.UseCases.Perfil.GetPerfil;
using Domain.UseCases.Perfil.NewPerfil;
using Domain.UseCases.Perfil.RemoveProfile;
using Domain.UseCases.Perfil.UpdateProfile;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace chat_perfil_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PerfilController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PerfilController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] NewPerfilRequest request)
        {
            var result = await _mediator.Send(request);

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var request = new GetProfileRequest { Id = id };
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var request = new DeleteProfileRequest { Id = id };
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateProfileRequest updateProfileRequest)
        {
            var result = await _mediator.Send(updateProfileRequest);
            return Ok(result);
        }
    }
}