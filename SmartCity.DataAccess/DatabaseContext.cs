using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using SmartCity.Domain.Entities;

namespace SmartCity.DataAccess
{
    public class DatabaseContext
    {
        public IMongoCollection<PersonEntity> Persons { get; set; }

        public DatabaseContext(IConfiguration config)
        {
            var connectionString = config.GetSection("ConnectionStrings").Value;
            var databaseName = config.GetSection("DatabaseName").Value;

            var client = new MongoClient(connectionString);
            var database = client.GetDatabase(databaseName);

            Persons = database.GetCollection<PersonEntity>("Persons");
        }
    }
}
