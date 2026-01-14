using Microsoft.Extensions.DependencyInjection;
using Serilog;
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

        private async void loginBtn_Click(object sender, EventArgs e) {

            try {
                //var employeeId = usernameTextBox.Text;
                //var password = passwordTextBox.Text;

                var employeeId = "PURCH-PO-8";
                var password = "PURCH-PO-8";

                if (string.IsNullOrWhiteSpace(employeeId)) {
                    MessageBox.Show("Employee ID is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(password)) {
                    MessageBox.Show("Password is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var credentials = new Dictionary<string, dynamic>{
                        { "employee_id", employeeId},
                        { "password", password},
                    };

                var res = await _authService.LoginAsync(credentials);

                if (res == null || !res.Success) {

                    MessageBox.Show("Invalid login credentials");
                    return;
                }

                this.Hide();

                var mainLayout = _serviceProvider.GetRequiredService <MainLayout>();

                if (mainLayout != null) {
                    mainLayout.Show();
                }



            } catch (Exception ex) {
                Log.Error($"LOGIN ERROR: {ex.Message}");
                MessageBox.Show("Something went wrong");
            }
        }

    }
}
