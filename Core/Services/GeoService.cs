using GMap.NET;
using GMap.NET.MapProviders;
using smpc_dispatching.Core.Interfaces;

namespace smpc_dispatching.Core.Services {
    public class GeoService : IGeoService {
        public (PointLatLng? Point, string Address) ReverseGeocode(PointLatLng location) {
            GeoCoderStatusCode status;
            var placemark = GMapProviders.GoogleMap.GetPlacemark(location, out status);

            // If Google fails, try OpenStreetMap
            if (status != GeoCoderStatusCode.G_GEO_SUCCESS || placemark == null) {
                placemark = GMapProviders.OpenStreetMap.GetPlacemark(location, out status);
            }

            string address = placemark?.Address ?? $"Lat: {location.Lat:F6}, Lng: {location.Lng:F6}";
            return (location, address);
        }

    }
}
