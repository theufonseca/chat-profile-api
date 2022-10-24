using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Infra.Mongodb.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Mongodb.Services
{
    public class ProfileService : IProfileDbService
    {
        private readonly IMongoCollection<PerfilModel> _mongoCollection;
        private readonly IMapper _mapper;

        public ProfileService(IOptions<MongoDbConfig> mongoDbConfig, IMapper mapper)
        {
            var mongoClient = new MongoClient(mongoDbConfig.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(mongoDbConfig.Value.DatabaseName);
            _mongoCollection = mongoDatabase.GetCollection<PerfilModel>(mongoDbConfig.Value.ProfileCollection);
            _mapper = mapper;
        }

        public async Task CreateAsync(Domain.Entities.Profile perfil)
        {
            var perfilModel = _mapper.Map<PerfilModel>(perfil);

            if (perfilModel is null)
                throw new ArgumentException();

            await _mongoCollection.InsertOneAsync(perfilModel);
        }

        public async Task<Domain.Entities.Profile> GetAsync(string id)
        {
            var perfilModel = await _mongoCollection.Find(x => x.Id == id)
                .FirstOrDefaultAsync();

            var perfil = _mapper.Map<Domain.Entities.Profile>(perfilModel);

            return perfil;
        }

        public async Task DeleteAsync(string id)
        {
            await _mongoCollection.DeleteOneAsync(x => x.Id == id);
        }

        public async Task UpdateAsync(string id, Domain.Entities.Profile profile)
        {
            var profileModel = await _mongoCollection.Find(x => x.Id == id)
                                        .FirstOrDefaultAsync();

            await _mongoCollection.ReplaceOneAsync(x => x.Id == id, profileModel);
        }
    }
}