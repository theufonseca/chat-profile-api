using Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.UseCases.Perfil.UpdateProfile
{
    public class UpdateProfileRequest : IRequest<UpdateProfileRequestResult>
    {
        public string Id { get; set; }
        public string Name { get; init; } = default!;
        public string Email { get; init; } = default!;
        public string Password { get; init; } = default!;

    }

    public class UpdateProfileRequestResult
    {
        public Domain.Entities.Profile Profile { get; init; } = null!;
    }

    public class UpdateProfileRequestHandler : IRequestHandler<UpdateProfileRequest, UpdateProfileRequestResult>
    {
        private readonly IProfileDbService _profileService;

        public UpdateProfileRequestHandler(IProfileDbService profileService)
        {
            _profileService = profileService;
        }

        public async Task<UpdateProfileRequestResult> Handle(UpdateProfileRequest request, CancellationToken cancellationToken)
        {
            if (request.Id is null)
                throw new ArgumentException("Id precisa ser diferente de zero e de vazio");

            var profile = await _profileService.GetAsync(request.Id);
            var updatedProfile = BuildProfileToUpdate(request, profile);

            await _profileService.UpdateAsync(request.Id, updatedProfile);

            return new UpdateProfileRequestResult { Profile = updatedProfile };
        }

        public Domain.Entities.Profile BuildProfileToUpdate(UpdateProfileRequest request, Entities.Profile currentProfile)
        {
            return new Entities.Profile
            {
                Id = request.Id,
                Nick = currentProfile.Nick,
                Email = string.IsNullOrEmpty(request.Email) ? currentProfile.Email : request.Email,
                Name = string.IsNullOrEmpty(request.Name) ? currentProfile.Name : request.Name, 
                Password = string.IsNullOrEmpty(request.Password) ? currentProfile.Password : request.Password
            };
        }
    }
}
