using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using smpc_dispatching.Core.Interfaces;
using System;
using System.Windows.Forms;

namespace smpc_dispatching.UI.Shared {
    public partial class MapLocPinForm : Form {
        private readonly IGeoService _geoService;
        private GMapOverlay markersOverlay;

        public PointLatLng? SelectedPoint { get; private set; }
        public string SelectedAddress { get; private set; }

        public MapLocPinForm(IGeoService geoService) {
            _geoService = geoService;


            GMaps.Instance.Mode = AccessMode.ServerOnly;

            InitializeComponent();
            InitializeMap();
        }

        private void InitializeMap() {
            try {
                // Ensure modern TLS for OpenStreetMap
                System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12;

                // ✅ Set your preferred map provider (you can change to Google if needed)
                MapControl.MapProvider = OpenStreetMapProvider.Instance;

                // ✅ Basic map configuration
                MapControl.MinZoom = 2;
                MapControl.MaxZoom = 20;
                MapControl.Zoom = 8;
                MapControl.ShowCenter = false;

                // Center on Philippines by default
                MapControl.Position = new PointLatLng(12.8797, 121.7740);

                // ✅ Initialize marker overlay
                markersOverlay = new GMapOverlay("markers");
                MapControl.Overlays.Add(markersOverlay);

                // ✅ Attach map click handler
                MapControl.MouseClick += GMapControl1_MouseClick;
            } catch (Exception ex) {
                MessageBox.Show("Map failed to initialize: " + ex.Message,
                    "Map Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GMapControl1_MouseClick(object sender, MouseEventArgs e) {
            if (e.Button != MouseButtons.Left) return;

            var point = MapControl.FromLocalToLatLng(e.X, e.Y);
            markersOverlay.Markers.Clear();

            var marker = new GMarkerGoogle(point, GMarkerGoogleType.red_dot);
            markersOverlay.Markers.Add(marker);

            SelectedPoint = point;

            try {
                var (latLng, address) = _geoService.ReverseGeocode(point);
                SelectedAddress = address ?? "Unknown address";
            } catch (Exception ex) {
                SelectedAddress = "Unknown address";
                MessageBox.Show("Reverse geocode failed: " + ex.Message,
                    "Geo Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void ConfirmButton_Click(object sender, EventArgs e) {
            if (SelectedPoint == null) {
                MessageBox.Show("Please click a location on the map first.");
                return;
            }

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
