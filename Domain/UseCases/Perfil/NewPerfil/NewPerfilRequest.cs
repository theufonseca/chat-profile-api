using Domain.Interfaces;
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
        public string Password { get; init; } = default!;
    }

    public record NewPerfilResponse
    {
        public string Id { get; init; } = default!;
    }

    public class NewPerfilRequestHandler : IRequestHandler<NewPerfilRequest, NewPerfilResponse>
    {
        private readonly IProfileDbService _profileDbService;

        public NewPerfilRequestHandler(IProfileDbService profileDbService)
        {
            _profileDbService = profileDbService;
        }

        public async Task<NewPerfilResponse> Handle(NewPerfilRequest request, CancellationToken cancellationToken)
        {
            var newPerfil = new Entities.Perfil()
            {
                Id = request.NickName,
                Email = request.Email,
                Name = request.Name, 
                Nick = request.NickName,
                Password = request.Password
            };

            var perfil = await _profileDbService.GetAsync(newPerfil.Id);

            if (perfil is not null)
                throw new ArgumentException($"user {perfil.Nick} already exists");

            await _profileDbService.CreateAsync(newPerfil);

            return new NewPerfilResponse
            {
                Id = newPerfil.Id
            };
        }
    }
}
