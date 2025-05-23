using FCG.Model;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace FCG.Connection
{
    public class MongoDBContext
    {
        private readonly IMongoDatabase _database;

        public MongoDBContext(IConfiguration configuration)
        {
            var client = new MongoClient(configuration["MongoDB:ConnectionString"]);
            _database = client.GetDatabase(configuration["MongoDB:DatabaseName"]);
        }

        public IMongoCollection<Usuario> Usuarios =>
            _database.GetCollection<Usuario>("Usuarios");
    }
}
