using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace PersonalBlog.Application.Utils
{
    public static class LocationUtils
    {
        public static (double Lat, double Lng, double Radius) ParseLocation(string location)
        {
            var parts = location.Split(',');
            if (parts.Length < 3)
                throw new ValidationException("فرمت موقعیت مکانی نامعتبر است");

            return (
                double.Parse(parts[0], CultureInfo.InvariantCulture),
                double.Parse(parts[1], CultureInfo.InvariantCulture),
                double.Parse(parts[2], CultureInfo.InvariantCulture)
            );
        }

        public static bool IsInRange(string userLocation, IEnumerable<string> officeLocations)
        {
            var (userLat, userLng, _) = ParseLocation(userLocation);

            return officeLocations.Any(loc =>
            {
                var (officeLat, officeLng, officeRadius) = ParseLocation(loc);
                return HaversineDistance(userLat, userLng, officeLat, officeLng) <= officeRadius / 1000.0;
            });
        }

        private static double HaversineDistance(double lat1, double lng1, double lat2, double lng2)
        {
            const double R = 6371;
            var dLat = ToRad(lat2 - lat1);
            var dLng = ToRad(lng2 - lng1);
            var a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
                    Math.Cos(ToRad(lat1)) * Math.Cos(ToRad(lat2)) *
                    Math.Sin(dLng / 2) * Math.Sin(dLng / 2);
            return R * 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
        }

        private static double ToRad(double deg) => deg * Math.PI / 180;

    }
}
