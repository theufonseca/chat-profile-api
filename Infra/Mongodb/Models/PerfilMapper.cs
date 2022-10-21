using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Mongodb.Models
{
    public class ProfileMapper : Profile
    {
        public ProfileMapper()
        {
            CreateMap<Perfil, PerfilModel>();
            CreateMap<PerfilModel, Perfil>();
        }
    }
}
