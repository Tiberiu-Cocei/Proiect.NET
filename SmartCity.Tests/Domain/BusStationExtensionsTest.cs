using Microsoft.VisualStudio.TestTools.UnitTesting;
using SmartCity.Domain.ExtensionMethods;
using SmartCity.Domain.Entities;
using SmartCity.Domain.Factories;
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
            BusStationFactory busStationFactory = new BusStationFactory();
            CoordinatesFactory coordinatesFactory = new CoordinatesFactory();
            BusRouteFactory busRouteFactory = new BusRouteFactory();
            List<BusStationEntity> busStationList = new List<BusStationEntity>
            {
                busStationFactory.GetBusEntity(Guid.Empty, "Station_One", coordinatesFactory.GetCoordinatesEntity(3.452, 3.567), null, DateTime.Now, DateTime.Now),
                busStationFactory.GetBusEntity(Guid.Empty, "Station_Two", coordinatesFactory.GetCoordinatesEntity(4.452, 4.567), null, DateTime.Now, DateTime.Now),
                busStationFactory.GetBusEntity(Guid.Empty, "Station_Three", coordinatesFactory.GetCoordinatesEntity(5.452, 5.567), null, DateTime.Now, DateTime.Now)
            };
            BusRouteEntity firstBusRouteEntity = busRouteFactory.GetBusRouteEntity(Guid.Empty, "30", busStationList, DateTime.Now, DateTime.Now);
            busRoutes.Add(firstBusRouteEntity);

            // Act
            List<(string, string, CoordinatesEntity, string, CoordinatesEntity)> result = BusStationExtensions.ShortestPath(busRoutes, "Station_One", "Station_Three");
            List<(string, string, CoordinatesEntity, string, CoordinatesEntity)> realResult = new List<(string, string, CoordinatesEntity, string, CoordinatesEntity)>();
            CoordinatesEntity firstStationStartCoordinates = coordinatesFactory.GetCoordinatesEntity(3.452, 3.567);
            CoordinatesEntity firstStationEndCoordinates = coordinatesFactory.GetCoordinatesEntity(5.452, 5.567);
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
            BusStationFactory busStationFactory = new BusStationFactory();
            CoordinatesFactory coordinatesFactory = new CoordinatesFactory();
            BusRouteFactory busRouteFactory = new BusRouteFactory();
            List<BusStationEntity> firstBusStationList = new List<BusStationEntity>
            {
                busStationFactory.GetBusEntity(Guid.Empty, "Station_One", coordinatesFactory.GetCoordinatesEntity(3.452, 3.567), null, DateTime.Now, DateTime.Now),
                busStationFactory.GetBusEntity(Guid.Empty, "Station_Two", coordinatesFactory.GetCoordinatesEntity(4.452, 4.567), null, DateTime.Now, DateTime.Now),
                busStationFactory.GetBusEntity(Guid.Empty, "Station_Three", coordinatesFactory.GetCoordinatesEntity(5.452, 5.567), null, DateTime.Now, DateTime.Now)
            };
            BusRouteEntity firstBusRouteEntity = busRouteFactory.GetBusRouteEntity(Guid.Empty, "30", firstBusStationList, DateTime.Now, DateTime.Now);
            List<BusStationEntity> secondBusStationList = new List<BusStationEntity>
            {
                busStationFactory.GetBusEntity(Guid.Empty, "Station_Five", coordinatesFactory.GetCoordinatesEntity(33.452, 33.567), null, DateTime.Now, DateTime.Now),
                busStationFactory.GetBusEntity(Guid.Empty, "Station_Six", coordinatesFactory.GetCoordinatesEntity(12.452, 12.567), null, DateTime.Now, DateTime.Now),
                busStationFactory.GetBusEntity(Guid.Empty, "Station_Seven", coordinatesFactory.GetCoordinatesEntity(13.452, 13.567), null, DateTime.Now, DateTime.Now)
            };
            BusRouteEntity secondBusRouteEntity = busRouteFactory.GetBusRouteEntity(Guid.Empty, "31", secondBusStationList, DateTime.Now, DateTime.Now);
            List<BusStationEntity> thirdBusStationList = new List<BusStationEntity>
            {
                busStationFactory.GetBusEntity(Guid.Empty, "Station_Four", coordinatesFactory.GetCoordinatesEntity(15.452, 15.567), null, DateTime.Now, DateTime.Now),
                busStationFactory.GetBusEntity(Guid.Empty, "Station_Three", coordinatesFactory.GetCoordinatesEntity(5.452, 5.567), null, DateTime.Now, DateTime.Now),
                busStationFactory.GetBusEntity(Guid.Empty, "Station_Five", coordinatesFactory.GetCoordinatesEntity(33.452, 33.567), null, DateTime.Now, DateTime.Now)
            };
            BusRouteEntity thirdBusRouteEntity = busRouteFactory.GetBusRouteEntity(Guid.Empty, "32", thirdBusStationList, DateTime.Now, DateTime.Now);
            busRoutes.Add(firstBusRouteEntity);
            busRoutes.Add(secondBusRouteEntity);
            busRoutes.Add(thirdBusRouteEntity);

            // Act
            List<(string, string, CoordinatesEntity, string, CoordinatesEntity)> result = BusStationExtensions.ShortestPath(busRoutes, "Station_One", "Station_Six");
            List<(string, string, CoordinatesEntity, string, CoordinatesEntity)> realResult = new List<(string, string, CoordinatesEntity, string, CoordinatesEntity)>();
            CoordinatesEntity firstStationStartCoordinates = coordinatesFactory.GetCoordinatesEntity(3.452, 3.567);
            CoordinatesEntity firstStationEndCoordinates = coordinatesFactory.GetCoordinatesEntity(5.452, 5.567);
            CoordinatesEntity secondStationStartCoordinates = coordinatesFactory.GetCoordinatesEntity(5.452, 5.567);
            CoordinatesEntity secondStationEndCoordinates = coordinatesFactory.GetCoordinatesEntity(33.452, 33.567);
            CoordinatesEntity thirdStationStartCoordinates = coordinatesFactory.GetCoordinatesEntity(33.452, 33.567);
            CoordinatesEntity thirdStationEndCoordinates = coordinatesFactory.GetCoordinatesEntity(12.452, 12.567);
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
            BusStationFactory busStationFactory = new BusStationFactory();
            CoordinatesFactory coordinatesFactory = new CoordinatesFactory();
            BusRouteFactory busRouteFactory = new BusRouteFactory();
            List<BusStationEntity> busStationList = new List<BusStationEntity>
            {
                busStationFactory.GetBusEntity(Guid.Empty, "Station_One", coordinatesFactory.GetCoordinatesEntity(3.452, 3.567), null, DateTime.Now, DateTime.Now),
                busStationFactory.GetBusEntity(Guid.Empty, "Station_Two", coordinatesFactory.GetCoordinatesEntity(4.452, 4.567), null, DateTime.Now, DateTime.Now),
                busStationFactory.GetBusEntity(Guid.Empty, "Station_Three", coordinatesFactory.GetCoordinatesEntity(5.452, 5.567), null, DateTime.Now, DateTime.Now)
            };
            BusRouteEntity firstBusRouteEntity = busRouteFactory.GetBusRouteEntity(Guid.Empty, "30", busStationList, DateTime.Now, DateTime.Now);
            busRoutes.Add(firstBusRouteEntity);

            // Act
            List<(string, string, CoordinatesEntity, string, CoordinatesEntity)> result = BusStationExtensions.ShortestPath(busRoutes, "Station_One", "Station_Four");

            // Assert
            Assert.IsNull(result);
        }
    }
}
