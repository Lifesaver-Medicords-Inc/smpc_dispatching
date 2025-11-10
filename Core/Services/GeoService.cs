using GMap.NET;
using smpc_dispatching.Core.Interfaces;
using System.Globalization;
using System.Net.Http;
using System.Text.Json;

namespace smpc_dispatching.Core.Services {
    public class GeoService : IGeoService {
        private static readonly HttpClient http = new HttpClient();

        public (PointLatLng? Point, string Address) ReverseGeocode(PointLatLng location) {
            string address = $"Lat: {location.Lat:F6}, Lng: {location.Lng:F6}";

            try {
                string latStr = location.Lat.ToString(CultureInfo.InvariantCulture);
                string lngStr = location.Lng.ToString(CultureInfo.InvariantCulture);

                string url = $"https://nominatim.openstreetmap.org/reverse?format=jsonv2&lat={latStr}&lon={lngStr}";

                // Nominatim requires User-Agent
                http.DefaultRequestHeaders.UserAgent.ParseAdd("MyApp/1.0 (your-email@example.com)");

                string response = http.GetStringAsync(url).Result;

                using (JsonDocument doc = JsonDocument.Parse(response)) {
                    JsonElement root = doc.RootElement;
                    JsonElement displayName;
                    if (root.TryGetProperty("display_name", out displayName)) {
                        string result = displayName.GetString();
                        if (!string.IsNullOrWhiteSpace(result))
                            address = result;
                    }
                }
            } catch {
                // fallback: coordinates only
            }

            return (location, address);
        }
    }
}
