using Reposiroty.Entity;
using System;
using System.Collections.Generic;

namespace Service.Services
{
    public class LocationsService
    {
        public double CalculateDistance(double x1, double y1, double x2, double y2)
        {
            // Impalement distance calculation logic (e.g., Haversine formula)
            // Return the distance between two points
            return Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
        }

        public double[,] BuildDistanceMatrix(List<Locations> locations)
        {
            int numLocations = locations.Count;
            double[,] distanceMatrix = new double[numLocations, numLocations];

            for (int i = 0; i < numLocations; i++)
            {
                for (int j = 0; j < numLocations; j++)
                {         
                    distanceMatrix[i, j] = CalculateDistance(locations[i].CurrentX, locations[i].CurrentY, locations[j].XStore, locations[j].YStore);
                }
            }

            return distanceMatrix;
        }
    }
}
