using System;
using System.Collections.Generic;
using System.Text;

namespace Maps
{
    public class CoordinatesCalc
    {
        //South latitudes are negative, east longitudes are positive
        public const char _kilometers = 'K';

        public const char _miles = 'M';

        public const char _nauticalMiles = 'N';

        public const int _low = 3;

        public const int _medium = 4;

        public const int _high = 5;

        public static double Distance(Coordinate start, Coordinate end)
        {
            return Distance(start, end, _miles);
        }
        public static double Distance(Coordinate start, Coordinate end, char unit)
        {
            if ((start.Latitude == end.Latitude) && (start.Longitude == end.Longitude))
                return 0;

            double theta = start.Longitude - end.Longitude;

            double distance = Math.Sin(DegreesToRadians(start.Latitude))
                * Math.Sin(DegreesToRadians(end.Latitude))
                + Math.Cos(DegreesToRadians(start.Latitude))
                * Math.Cos(DegreesToRadians(end.Latitude))
                * Math.Cos(DegreesToRadians(theta));

            distance = Math.Acos(distance);

            distance = RadiansToDegrees(distance);

            distance = distance * 60 * 1.1515;

            switch (unit)
            {
                case _kilometers:
                    distance *= 1.609344;
                    break;
                case _nauticalMiles:
                    distance *= 0.8684;
                    break;
            }
            return (distance);
        }

        public static double DegreesToRadians(double deg)
        {
            return (deg * Math.PI / 180.0);
        }

        public static double RadiansToDegrees(double rad)
        {
            return (rad / Math.PI * 180.0);
        }

        public static bool Match(Coordinate start, Coordinate end)
        {
            return Match(start, end, _medium);
        }

        public static bool Match(Coordinate start, Coordinate end, int precision)
        {
            start.Latitude = Math.Round(start.Latitude, precision);
            start.Longitude = Math.Round(start.Longitude, precision);
            end.Latitude = Math.Round(end.Latitude, precision);
            end.Longitude = Math.Round(end.Longitude, precision);

            return start.Latitude == end.Latitude && start.Longitude == end.Longitude;
        }

        public static Coordinate MatchList(Coordinate start, IList<Coordinate> list, int precision)
        {
            foreach (Coordinate end in list)
            {

            }
        }


    }
}
