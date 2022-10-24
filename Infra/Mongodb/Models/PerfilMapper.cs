using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Mongodb.Models
{
    public class ProfileMapper : AutoMapper.Profile
    {
        public ProfileMapper()
        {
            CreateMap<Domain.Entities.Profile, PerfilModel>();
            CreateMap<PerfilModel, Domain.Entities.Profile>();
        }
    }
}
