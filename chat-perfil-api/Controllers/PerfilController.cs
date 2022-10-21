using Domain.UseCases.Perfil.NewPerfil;
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
    }
}
