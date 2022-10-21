using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IProfileDbService
    {
        Task CreateAsync(Perfil perfil);

        Task<Perfil> GetAsync(string id);
    }
}
