using System;
using System.Collections.Generic;
using System.Text;

namespace Maps
{
    public class Coordinates
    {
        //South latitudes are negative, east longitudes are positive
        public const char _kilometers = 'K';

        public const char _miles = 'M';

        public const char _nauticalMiles = 'N';

        public static double Distance(double latitudeStart, double longitudeStart, double latitudeEnd, double longitudeEnd)
        {
            return Distance(latitudeStart, longitudeStart, latitudeEnd, longitudeEnd, _miles);
        }
        public static double Distance(double latitudeStart, double longitudeStart, double latitudeEnd, double longitudeEnd, char unit)
        {
            if ((latitudeStart == latitudeEnd) && (longitudeStart == longitudeEnd))
                return 0;

            double theta = longitudeStart - longitudeEnd;

            double distance = Math.Sin(DegreesToRadians(latitudeStart))
                * Math.Sin(DegreesToRadians(latitudeEnd))
                + Math.Cos(DegreesToRadians(latitudeStart))
                * Math.Cos(DegreesToRadians(latitudeEnd))
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

    }
}
