using SmartCity.Domain.Entities;
using System;

namespace SmartCity.WebApi.Models.Bus
{
    public class CreateBusModel
    {
        public Guid Id { get; set; }

        public CoordinatesEntity Coordinates { get; set; }

        public bool GoingToGarrage { get; set; }
    }
}
