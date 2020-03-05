using SmartCity.Domain.Entities;
using System;
using System.Collections.Generic;

namespace SmartCity.Domain.Factories
{
    public class BusStationFactory
    {
        private Guid Id;

        private string Name;

        private CoordinatesEntity Coordinates;

        private ICollection<BusEntity> Buses;

        private DateTime CreationDate;

        private DateTime ModifiedDate;

        public BusStationFactory() {}

        public BusStationEntity GetBusEntity(Guid id, string name, CoordinatesEntity coordinates, List<BusEntity> buses, DateTime creationDate, DateTime modifiedDate)
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
            Coordinates = coordinates;
            Buses = buses;
            CreationDate = creationDate;
            ModifiedDate = modifiedDate;

            return new BusStationEntity
            {
                Id = Id,
                Name = Name,
                Coordinates = Coordinates,
                Buses = Buses,
                CreationDate = CreationDate,
                ModifiedDate = ModifiedDate
            };
        }
    }
}
