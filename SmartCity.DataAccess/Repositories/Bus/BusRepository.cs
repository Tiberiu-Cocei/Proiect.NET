using MongoDB.Driver;
using SmartCity.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Vanguard;

namespace SmartCity.DataAccess.Repositories.Bus
{
    public class BusRepository : IBusRepository
    {
        private readonly IMongoCollection<BusEntity> _buses;

        public BusRepository(DatabaseContext databaseContext)
        {
            Guard.ArgumentNotNull(databaseContext, nameof(databaseContext));

            _buses = databaseContext.Buses;
        }
    }
}
