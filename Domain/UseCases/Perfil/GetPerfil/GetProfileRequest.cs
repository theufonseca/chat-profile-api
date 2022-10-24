using Domain.Entities;
using Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.UseCases.Perfil.GetPerfil
{
    public class GetProfileRequest : IRequest<GetProfileRequestResult>
    {
        public string Id { get; init; } = default!;
    }

    public class GetProfileRequestResult
    {
        public Profile Perfil { get; init; } = null!;
    }

    public class GetPerfilRequestHandler : IRequestHandler<GetProfileRequest, GetProfileRequestResult>
    {
        private readonly IProfileDbService _profileService;

        public GetPerfilRequestHandler(IProfileDbService profileService)
        {
            _profileService = profileService;
        }

        public async Task<GetProfileRequestResult> Handle(GetProfileRequest request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(request.Id))
                throw new ArgumentException("Id precisa conter um valor diferente de nulo e vazio");

            var perfil = await _profileService.GetAsync(request.Id);

            if (perfil is null || perfil.Id is null)
                throw new Exception($"Perfil não localizado para o Id: {request.Id}");

            return new GetProfileRequestResult
            {
                Perfil = perfil
            };
        }
    }
}
