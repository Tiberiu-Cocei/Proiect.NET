using SmartCity.Domain.Entities;
using System;
using System.Collections.Generic;

namespace SmartCity.Domain.Factories
{
    public class BusRouteFactory
    {
        private Guid Id;

        private String Name;

        private ICollection<BusStationEntity> BusStations;

        private DateTime CreationDate;

        private DateTime ModifiedDate;

        public BusRouteFactory() { }

        public BusRouteEntity GetBusRouteEntity(Guid id, string name, List<BusStationEntity> busStations, DateTime creationDate, DateTime modifiedDate)
        {
            if (id == Guid.Empty)
            {
                Id = new Guid();
            }
            else
            {
                Id = id;
            }
            Name = name;
            BusStations = busStations;
            CreationDate = creationDate;
            ModifiedDate = modifiedDate;

            return new BusRouteEntity
            {
                Id = Id,
                Name = Name,
                BusStations = BusStations,
                CreationDate = CreationDate,
                ModifiedDate = ModifiedDate
            };
        }
    }
}
