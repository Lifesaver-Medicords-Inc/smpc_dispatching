using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using smpc_dispatching.Core.Interfaces;
using System;
using System.Windows.Forms;

namespace smpc_dispatching.UI.Shared {
    public partial class MapPickerForm : Form {
        private readonly IGeoService _geoService;
        private readonly System.IServiceProvider _serviceProvider;
        private GMapOverlay markersOverlay;

        public PointLatLng? SelectedPoint { get; private set; }
        public string SelectedAddress { get; private set; }

        // ✅ Constructor injection
        public MapPickerForm(IGeoService geoService, IServiceProvider serviceProvider) {
            _geoService = geoService;
            _serviceProvider = serviceProvider;
            InitializeComponent();
            InitializeMap();
        }

        private void InitializeMap() {
            GMaps.Instance.Mode = AccessMode.ServerOnly;
            Gmap.MapProvider = GMapProviders.GoogleMap;
            Gmap.MinZoom = 2;
            Gmap.MaxZoom = 18;
            Gmap.Zoom = 5;
            Gmap.Position = new PointLatLng(12.8797, 121.7740);
            Gmap.ShowCenter = false;

            markersOverlay = new GMapOverlay("markers");
            Gmap.Overlays.Add(markersOverlay);

            Gmap.MouseClick += Gmap_MouseClick;
        }

        private void Gmap_MouseClick(object sender, MouseEventArgs e) {
            if (e.Button != MouseButtons.Left) return;

            var pointClick = Gmap.FromLocalToLatLng(e.X, e.Y);
            markersOverlay.Markers.Clear();

            var marker = new GMarkerGoogle(pointClick, GMarkerGoogleType.red_dot);
            markersOverlay.Markers.Add(marker);

            SelectedPoint = pointClick;

            try {
                // Try to reverse geocode using your IGeoService
                var (point, address) = _geoService.ReverseGeocode(pointClick);
                SelectedAddress = address ?? "Unknown address";
            } catch (Exception ex) {
                MessageBox.Show("Reverse geocode failed: " + ex.Message);
            }
        }

        private void ConfirmBtn_Click(object sender, EventArgs e) {
            if (SelectedPoint == null) {
                MessageBox.Show("Please click a location on the map first.");
                return;
            }

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
