using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Mongodb.Models
{
    public class PerfilModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public string Name { get; init; } = default!;
        public string Email { get; init; } = default!;
        public string Nick { get; init; } = default!;
    }
}
