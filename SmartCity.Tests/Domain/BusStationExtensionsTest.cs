using Microsoft.VisualStudio.TestTools.UnitTesting;
using SmartCity.Domain.ExtensionMethods;
using SmartCity.Domain.Entities;
using System;
using System.Collections.Generic;

namespace SmartCity.Tests
{
    [TestClass]
    public class BusStationExtensionsTest
    {
        [TestMethod]
        public void WhenShortestPathIsCalledWithGivenParameters_ThenReturnCorrectList()
        {
            // Arrange
            List<BusRouteEntity> busRoutes = new List<BusRouteEntity>();
            BusRouteEntity firstBusRouteEntity = new BusRouteEntity
            {
                Id = new Guid(),
                Name = "30",
                BusStations = new List<BusStationEntity>
                {
                   new BusStationEntity
                   {
                       Id = new Guid(),
                       Name = "Station_One",
                       Coordinates = new CoordinatesEntity
                       {
                           Longitude = 3.452,
                           Latitude = 3.567
                       },
                       Buses = null,
                       CreationDate = DateTime.Now,
                       ModifiedDate = DateTime.Now
                   },
                   new BusStationEntity
                   {
                       Id = new Guid(),
                       Name = "Station_Two",
                       Coordinates = new CoordinatesEntity
                       {
                           Longitude = 4.452,
                           Latitude = 4.567
                       },
                       Buses = null,
                       CreationDate = DateTime.Now,
                       ModifiedDate = DateTime.Now
                   },
                   new BusStationEntity
                   {
                       Id = new Guid(),
                       Name = "Station_Three",
                       Coordinates = new CoordinatesEntity
                       {
                           Longitude = 5.452,
                           Latitude = 5.567
                       },
                       Buses = null,
                       CreationDate = DateTime.Now,
                       ModifiedDate = DateTime.Now
                   }
                },
                CreationDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };
            busRoutes.Add(firstBusRouteEntity);

            // Act
            List<(string, string, CoordinatesEntity, string, CoordinatesEntity)> result = BusStationExtensions.ShortestPath(busRoutes, "Station_One", "Station_Three");
            List<(string, string, CoordinatesEntity, string, CoordinatesEntity)> realResult = new List<(string, string, CoordinatesEntity, string, CoordinatesEntity)>();
            CoordinatesEntity firstStationStartCoordinates = new CoordinatesEntity
            {
                Longitude = 3.452,
                Latitude = 3.567
            };
            CoordinatesEntity firstStationEndCoordinates = new CoordinatesEntity
            {
                Longitude = 5.452,
                Latitude = 5.567
            };
            (string, string, CoordinatesEntity, string, CoordinatesEntity) realResultTupleOne = ("30", "Station_One", firstStationStartCoordinates, "Station_Three", firstStationEndCoordinates);
            realResult.Add(realResultTupleOne);

            // Assert
            bool flag = true;
            for(int i = 0; i < result.Count; i++)
            {
                if(!result[i].Item1.Equals(realResult[i].Item1) || !result[i].Item2.Equals(realResult[i].Item2) || !result[i].Item3.Equals(realResult[i].Item3) || !result[i].Item4.Equals(realResult[i].Item4) || !result[i].Item5.Equals(realResult[i].Item5))
                {
                    flag = false;
                }
            }
            if(result.Count != realResult.Count)
            {
                flag = false;
            }
            Assert.IsTrue(flag);
        }

        [TestMethod]
        public void WhenShortestPathIsCalledWithGivenParameters_ThenReturnCorrectList_Two()
        {
            // Arrange
            List<BusRouteEntity> busRoutes = new List<BusRouteEntity>();
            BusRouteEntity firstBusRouteEntity = new BusRouteEntity
            {
                Id = new Guid(),
                Name = "30",
                BusStations = new List<BusStationEntity>
                {
                   new BusStationEntity
                   {
                       Id = new Guid(),
                       Name = "Station_One",
                       Coordinates = new CoordinatesEntity
                       {
                           Longitude = 3.452,
                           Latitude = 3.567
                       },
                       Buses = null,
                       CreationDate = DateTime.Now,
                       ModifiedDate = DateTime.Now
                   },
                   new BusStationEntity
                   {
                       Id = new Guid(),
                       Name = "Station_Two",
                       Coordinates = new CoordinatesEntity
                       {
                           Longitude = 4.452,
                           Latitude = 4.567
                       },
                       Buses = null,
                       CreationDate = DateTime.Now,
                       ModifiedDate = DateTime.Now
                   },
                   new BusStationEntity
                   {
                       Id = new Guid(),
                       Name = "Station_Three",
                       Coordinates = new CoordinatesEntity
                       {
                           Longitude = 5.452,
                           Latitude = 5.567
                       },
                       Buses = null,
                       CreationDate = DateTime.Now,
                       ModifiedDate = DateTime.Now
                   }
                },
                CreationDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };
            BusRouteEntity secondBusRouteEntity = new BusRouteEntity
            {
                Id = new Guid(),
                Name = "31",
                BusStations = new List<BusStationEntity>
                {
                   new BusStationEntity
                   {
                       Id = new Guid(),
                       Name = "Station_Five",
                       Coordinates = new CoordinatesEntity
                       {
                           Longitude = 33.452,
                           Latitude = 33.567
                       },
                       Buses = null,
                       CreationDate = DateTime.Now,
                       ModifiedDate = DateTime.Now
                   },
                   new BusStationEntity
                   {
                       Id = new Guid(),
                       Name = "Station_Six",
                       Coordinates = new CoordinatesEntity
                       {
                           Longitude = 12.452,
                           Latitude = 12.567
                       },
                       Buses = null,
                       CreationDate = DateTime.Now,
                       ModifiedDate = DateTime.Now
                   },
                   new BusStationEntity
                   {
                       Id = new Guid(),
                       Name = "Station_Seven",
                       Coordinates = new CoordinatesEntity
                       {
                           Longitude = 13.452,
                           Latitude = 13.567
                       },
                       Buses = null,
                       CreationDate = DateTime.Now,
                       ModifiedDate = DateTime.Now
                   }
                },
                CreationDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };
            BusRouteEntity thirdBusRouteEntity = new BusRouteEntity
            {
                Id = new Guid(),
                Name = "32",
                BusStations = new List<BusStationEntity>
                {
                   new BusStationEntity
                   {
                       Id = new Guid(),
                       Name = "Station_Four",
                       Coordinates = new CoordinatesEntity
                       {
                           Longitude = 15.452,
                           Latitude = 15.567
                       },
                       Buses = null,
                       CreationDate = DateTime.Now,
                       ModifiedDate = DateTime.Now
                   },
                   new BusStationEntity
                   {
                       Id = new Guid(),
                       Name = "Station_Three",
                       Coordinates = new CoordinatesEntity
                       {
                           Longitude = 5.452,
                           Latitude = 5.567
                       },
                       Buses = null,
                       CreationDate = DateTime.Now,
                       ModifiedDate = DateTime.Now
                   },
                   new BusStationEntity
                   {
                       Id = new Guid(),
                       Name = "Station_Five",
                       Coordinates = new CoordinatesEntity
                       {
                           Longitude = 33.452,
                           Latitude = 33.567
                       },
                       Buses = null,
                       CreationDate = DateTime.Now,
                       ModifiedDate = DateTime.Now
                   }
                },
                CreationDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };
            busRoutes.Add(firstBusRouteEntity);
            busRoutes.Add(secondBusRouteEntity);
            busRoutes.Add(thirdBusRouteEntity);

            // Act
            List<(string, string, CoordinatesEntity, string, CoordinatesEntity)> result = BusStationExtensions.ShortestPath(busRoutes, "Station_One", "Station_Six");
            List<(string, string, CoordinatesEntity, string, CoordinatesEntity)> realResult = new List<(string, string, CoordinatesEntity, string, CoordinatesEntity)>();
            CoordinatesEntity firstStationStartCoordinates = new CoordinatesEntity
            {
                Longitude = 3.452,
                Latitude = 3.567
            };
            CoordinatesEntity firstStationEndCoordinates = new CoordinatesEntity
            {
                Longitude = 5.452,
                Latitude = 5.567
            };
            CoordinatesEntity secondStationStartCoordinates = new CoordinatesEntity
            {
                Longitude = 5.452,
                Latitude = 5.567
            };
            CoordinatesEntity secondStationEndCoordinates = new CoordinatesEntity
            {
                Longitude = 33.452,
                Latitude = 33.567
            };
            CoordinatesEntity thirdStationStartCoordinates = new CoordinatesEntity
            {
                Longitude = 33.452,
                Latitude = 33.567
            };
            CoordinatesEntity thirdStationEndCoordinates = new CoordinatesEntity
            {
                Longitude = 12.452,
                Latitude = 12.567
            };
            (string, string, CoordinatesEntity, string, CoordinatesEntity) realResultTupleOne = ("30", "Station_One", firstStationStartCoordinates, "Station_Three", firstStationEndCoordinates);
            (string, string, CoordinatesEntity, string, CoordinatesEntity) realResultTupleTwo = ("32", "Station_Three", secondStationStartCoordinates, "Station_Five", secondStationEndCoordinates);
            (string, string, CoordinatesEntity, string, CoordinatesEntity) realResultTupleThree = ("31", "Station_Five", thirdStationStartCoordinates, "Station_Six", thirdStationEndCoordinates);
            realResult.Add(realResultTupleOne);
            realResult.Add(realResultTupleTwo);
            realResult.Add(realResultTupleThree);

            // Assert
            bool flag = true;
            for (int i = 0; i < result.Count; i++)
            {
                if (!result[i].Item1.Equals(realResult[i].Item1) || !result[i].Item2.Equals(realResult[i].Item2) || !result[i].Item3.Equals(realResult[i].Item3) || !result[i].Item4.Equals(realResult[i].Item4) || !result[i].Item5.Equals(realResult[i].Item5))
                {
                    flag = false;
                }
            }
            if (result.Count != realResult.Count)
            {
                flag = false;
            }
            Assert.IsTrue(flag);
        }

        [TestMethod]
        public void WhenShortestPathIsCalledWithNoPossiblePath_ThenReturnNull()
        {
            // Arrange
            List<BusRouteEntity> busRoutes = new List<BusRouteEntity>();
            BusRouteEntity firstBusRouteEntity = new BusRouteEntity
            {
                Id = new Guid(),
                Name = "30",
                BusStations = new List<BusStationEntity>
                {
                   new BusStationEntity
                   {
                       Id = new Guid(),
                       Name = "Station_One",
                       Coordinates = new CoordinatesEntity
                       {
                           Longitude = 3.452,
                           Latitude = 3.567
                       },
                       Buses = null,
                       CreationDate = DateTime.Now,
                       ModifiedDate = DateTime.Now
                   },
                   new BusStationEntity
                   {
                       Id = new Guid(),
                       Name = "Station_Two",
                       Coordinates = new CoordinatesEntity
                       {
                           Longitude = 4.452,
                           Latitude = 4.567
                       },
                       Buses = null,
                       CreationDate = DateTime.Now,
                       ModifiedDate = DateTime.Now
                   },
                   new BusStationEntity
                   {
                       Id = new Guid(),
                       Name = "Station_Three",
                       Coordinates = new CoordinatesEntity
                       {
                           Longitude = 5.452,
                           Latitude = 5.567
                       },
                       Buses = null,
                       CreationDate = DateTime.Now,
                       ModifiedDate = DateTime.Now
                   }
                },
                CreationDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };
            busRoutes.Add(firstBusRouteEntity);

            // Act
            List<(string, string, CoordinatesEntity, string, CoordinatesEntity)> result = BusStationExtensions.ShortestPath(busRoutes, "Station_One", "Station_Four");

            // Assert
            Assert.IsNull(result);
        }
    }
}
