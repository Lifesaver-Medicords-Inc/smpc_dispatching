using Microsoft.Extensions.DependencyInjection;
using Serilog;
using smpc_dispatching.Core.Enum;
using smpc_dispatching.Core.Helpers;
using smpc_dispatching.Core.Interfaces;
using smpc_dispatching.UI.Layout;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace smpc_dispatching.UI.Forms {
    public partial class LoginForm : Form {

        private readonly IAuthService _authService;
        private readonly IServiceProvider _serviceProvider;
        public LoginForm(IAuthService authService, IServiceProvider serviceProvider) {
            _authService = authService;

            InitializeComponent();
            _serviceProvider = serviceProvider;
        }

        // Phase 4.6 (UI uniformity): converged onto the same ShowDialog()/
        // DialogResult.OK pattern the other 4 non-DI apps already use - this form no
        // longer resolves and shows MainLayout itself (see Program.cs, which now does
        // that only after this returns DialogResult.OK). Validation/error text now goes
        // through the shared Helpers.ShowDialogMessage (already used elsewhere in this
        // app, just not here) instead of raw MessageBox, so it matches the other 5
        // apps' dialog style (title, icon) instead of looking like a different app.
        private async void loginBtn_Click(object sender, EventArgs e) {

            var employeeId = usernameTextBox.Text;
            var password = passwordTextBox.Text;

            // Logistics
            //var employeeId = "LOG-D-29";
            //var password = "LOG-D-29";

            // WH Manager
            //var employeeId = "im-im-25";
            //var password = "im-im-25";

            // WH Manager
            //var employeeId = "IT-WD-1";
            //var password = "IT-WD-1";

            if (string.IsNullOrWhiteSpace(employeeId)) {
                Helpers.ShowDialogMessage("error", "Employee ID is required.");
                return;
            }

            if (string.IsNullOrWhiteSpace(password)) {
                Helpers.ShowDialogMessage("error", "Password is required.");
                return;
            }

            try {
                var credentials = new Dictionary<string, dynamic>{
                        { "employee_id", employeeId},
                        { "password", password},
                    };

                var res = await _authService.LoginAsync(credentials);

                if (res == null || !res.Success) {
                    Helpers.ShowDialogMessage("error", string.IsNullOrWhiteSpace(res?.Message) ? "Invalid Credentials" : res.Message);
                    return;
                }

                // Cache current user data
                CacheData.CurrentUser = res.Data;

                this.DialogResult = DialogResult.OK;

            } catch (Exception ex) {
                Log.Error($"LOGIN ERROR: {ex.Message}");
                Helpers.ShowDialogMessage("error", "Something went wrong. Please try again.");
            }
        }

        private void cancelBtn_Click(object sender, EventArgs e) {
            Application.Exit();
        }

    }
}
