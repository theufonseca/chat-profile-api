using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.UseCases.Perfil.NewPerfil
{
    public record NewPerfilRequest : IRequest<NewPerfilResponse>
    {
        public string Name { get; init; } = default!;
        public string NickName { get; init; } = default!;
        public string Email { get; init; } = default!;
    }

    public record NewPerfilResponse
    {
        public string Id { get; init; } = default!;
    }

    public class NewPerfilRequestHandler : IRequestHandler<NewPerfilRequest, NewPerfilResponse>
    {
        public Task<NewPerfilResponse> Handle(NewPerfilRequest request, CancellationToken cancellationToken)
        {
            
        }
    }
}
