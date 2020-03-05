using SmartCity.Domain.Entities;
using System;
using System.Collections.Generic;

namespace SmartCity.Domain.ExtensionMethods
{
    public static class BusStationExtensions
    {
        private static int shortestRouteLength;

        public static List<(string, string, CoordinatesEntity, string, CoordinatesEntity)> ShortestPath(List<BusRouteEntity> busRoutes, string startStation, string endStation, List<(string, string, CoordinatesEntity, string, CoordinatesEntity)> returnList = null)
        {
            if(returnList == null)
            {
                shortestRouteLength = Int32.MaxValue;
            }
            else
            {
                if(returnList.Count > shortestRouteLength)
                {
                    return returnList;
                }
            }
            List<(string, string, CoordinatesEntity, string, CoordinatesEntity)> result = null;
            foreach (BusRouteEntity busRoute in busRoutes)
            {
                bool startFlag = false;
                BusStationEntity auxStationEntity = null;
                List<BusRouteEntity> auxBusRoutes = new List<BusRouteEntity>(busRoutes);
                auxBusRoutes.Remove(busRoute);
                foreach (BusStationEntity busStation in busRoute.BusStations)
                {
                    if (!startFlag && busStation.Name == startStation)
                    {
                        startFlag = true;
                        auxStationEntity = busStation;
                    }
                    else if (startFlag)
                    {
                        List<(string, string, CoordinatesEntity, string, CoordinatesEntity)> auxReturnList = null;
                        if (returnList == null)
                        {
                            auxReturnList = new List<(string, string, CoordinatesEntity, string, CoordinatesEntity)>();
                        }
                        else
                        {
                            auxReturnList = new List<(string, string, CoordinatesEntity, string, CoordinatesEntity)>(returnList);
                        }
                        (string, string, CoordinatesEntity, string, CoordinatesEntity) infoTuple = (busRoute.Name, auxStationEntity.Name, auxStationEntity.Coordinates, busStation.Name, busStation.Coordinates);
                        auxReturnList.Add(infoTuple);
                        if (busStation.Name == endStation)
                        {
                            return auxReturnList;
                        }
                        List<(string, string, CoordinatesEntity, string, CoordinatesEntity)> auxResult = ShortestPath(auxBusRoutes, busStation.Name, endStation, auxReturnList);
                        if (auxResult != null && auxResult.Count <= shortestRouteLength)
                        {
                            result = auxResult;
                            shortestRouteLength = auxResult.Count;
                        }
                    }
                }
            }
            return result;
        }
    }
}
