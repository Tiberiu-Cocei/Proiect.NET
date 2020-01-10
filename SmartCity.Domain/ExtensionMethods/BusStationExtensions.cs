using SmartCity.Domain.Entities;
using System;
using System.Collections.Generic;

namespace SmartCity.Domain.ExtensionMethods
{
    public static class BusStationExtensions
    {
        public static List<(string, string, CoordinatesEntity, string, CoordinatesEntity)> ShortestPath(List<BusRouteEntity> busRoutes, string startStation, string endStation, List<(string, string, CoordinatesEntity, string, CoordinatesEntity)> returnList = null)
        {
            int shortestRouteLength = Int32.MaxValue;
            List<(string, string, CoordinatesEntity, string, CoordinatesEntity)> result = null;
            foreach (BusRouteEntity busRoute in busRoutes)
            {
                bool startFlag = false;
                BusStationEntity auxStationEntity = null;
                List<BusRouteEntity> auxBusRoutes = new List<BusRouteEntity>(busRoutes);
                auxBusRoutes.Remove(busRoute);
                foreach (BusStationEntity busStation in busRoute.BusStations)
                {
                    if(!startFlag && busStation.Name == startStation && returnList == null)
                    {
                        startFlag = true;
                        auxStationEntity = busStation;
                    }
                    else if(startFlag && returnList == null)
                    {
                        List<(string, string, CoordinatesEntity, string, CoordinatesEntity)> auxReturnList = new List<(string, string, CoordinatesEntity, string, CoordinatesEntity)>();
                        (string, string, CoordinatesEntity, string, CoordinatesEntity) infoTuple = (busRoute.Name, auxStationEntity.Name, auxStationEntity.Coordinates, busStation.Name, busStation.Coordinates);
                        auxReturnList.Add(infoTuple);
                        if(busStation.Name == endStation)
                        {
                            return auxReturnList;
                        }
                        List<(string, string, CoordinatesEntity, string, CoordinatesEntity)> auxResult = ShortestPath(auxBusRoutes, null, endStation, auxReturnList);
                        if(auxResult.Count < shortestRouteLength)
                        {
                            result = auxResult;
                            shortestRouteLength = auxResult.Count;
                        }
                    }
                    else if(!startFlag && returnList != null)
                    {

                    }
                    else if(startFlag && returnList != null)
                    {

                    }
                }
            }
            return result;
        }
    }
}
