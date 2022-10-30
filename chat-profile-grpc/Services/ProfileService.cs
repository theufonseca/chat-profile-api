using Domain.UseCases.Perfil.GetPerfil;
using Grpc.Core;
using MediatR;

namespace chat_profile_grpc.Services
{
    public class ProfileService : Profile.ProfileBase
    {
        private readonly IMediator mediator;

        public ProfileService(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public override async Task<ProfileResponse> Get(ProfileRequest request, ServerCallContext context)
        {
            ProfileResponse response = null;

            var requestProfile = new GetProfileRequest { Id = request.Id };
            try
            {
                var result = await mediator.Send(requestProfile);
                response = new ProfileResponse
                {
                    Id = result.Perfil.Id,
                    Email = result.Perfil.Email,
                    Name = result.Perfil.Name,
                    Nick = result.Perfil.Nick,
                };

                return response;
            }
            catch (Exception ex)
            {
                //salva log
                return new ProfileResponse()
                {
                    Id = "",
                    Email = "",
                    Name = "",
                    Nick = ""
                };
            }
        }
    }
}