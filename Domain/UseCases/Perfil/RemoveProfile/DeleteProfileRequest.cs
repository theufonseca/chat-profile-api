using Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.UseCases.Perfil.RemoveProfile
{
    public class DeleteProfileRequest : IRequest<DeleteProfileRequestResult>
    {
        public string Id { get; init; } = default!;
    }

    public class DeleteProfileRequestResult
    {
        public bool Sucess { get; init; } = default!;
    }

    public class DelteProfileRequestHandler : IRequestHandler<DeleteProfileRequest, DeleteProfileRequestResult>
    {
        private readonly IProfileDbService _profileService;

        public DelteProfileRequestHandler(IProfileDbService profileService)
        {
            _profileService = profileService;
        }

        public async Task<DeleteProfileRequestResult> Handle(DeleteProfileRequest request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(request.Id))
                throw new ArgumentException("Id precisa conter um valor diferente de nulo e vazio");

            await _profileService.DeleteAsync(request.Id);

            return new DeleteProfileRequestResult { Sucess = true };
        }
    }
}
