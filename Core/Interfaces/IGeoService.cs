using GMap.NET;

namespace smpc_dispatching.Core.Interfaces {
    public interface IGeoService {
        (PointLatLng? Point, string Address) ReverseGeocode(PointLatLng location);
    }
}
