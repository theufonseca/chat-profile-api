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
        Task CreateAsync(Profile perfil);
        Task<Profile> GetAsync(string id);
        Task DeleteAsync(string id);
        Task UpdateAsync(string id, Profile profile);
    }
}
