using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using SmartCity.Domain.Entities;

namespace SmartCity.DataAccess
{
    public class DatabaseContext
    {
        public IMongoCollection<PersonEntity> Persons { get; set; }

        public IMongoCollection<PointOfInterestEntity> PointOfInterests { get; set; }

        public IMongoCollection<CityEntity> Cities { get; set; }

        public IMongoCollection<BusEntity> Buses { get; set; }

        public IMongoCollection<BusRouteEntity> BusRoutes { get; set; }

        public IMongoCollection<BusStationEntity> BusStations { get; set; }

        public DatabaseContext(IConfiguration config)
        {
            var connectionString = config.GetSection("ConnectionStrings").Value;
            var databaseName = config.GetSection("DatabaseName").Value;

            var client = new MongoClient(connectionString);
            var database = client.GetDatabase(databaseName);

            Persons = database.GetCollection<PersonEntity>("Persons");
            PointOfInterests = database.GetCollection<PointOfInterestEntity>("PointOfInterests");
            Cities = database.GetCollection<CityEntity>("Cities");
            Buses = database.GetCollection<BusEntity>("Buses");
            BusRoutes = database.GetCollection<BusRouteEntity>("BusRoutes");
            BusStations = database.GetCollection<BusStationEntity>("BusStations");
        }
    }
}
