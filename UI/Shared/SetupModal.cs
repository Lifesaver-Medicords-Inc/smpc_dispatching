using smpc_dispatching.Core.Helpers;
using smpc_dispatching.Core.Interfaces;
using smpc_dispatching.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace smpc_dispatching.UI.Shared
{
    // Generic "code + name" setup CRUD screen, docked into a tab like the
    // other nav views. Reusable for any simple lookup table by pointing it
    // at a REST resource that returns SetupModel-shaped records
    // (id, code, name), e.g. "calendar-cost-types".
    public partial class SetupModal : UserControl
    {
        private readonly IHttpService _httpService;
        private readonly string _apiUrl;

        public SetupModal(string setupTitle, string apiUrl, IHttpService httpService)
        {
            InitializeComponent();
            lbl_setup_title.Text = setupTitle;
            _apiUrl = apiUrl.Trim('/');
            _httpService = httpService;
        }

        private async void SetupModal_Load(object sender, EventArgs e)
        {
            BtnToogle(false);
            await LoadSetup();
        }

        private async Task LoadSetup()
        {
            var response = await _httpService.Get<HttpResponseModel<IEnumerable<SetupModel>>>($"/api/{_apiUrl}/");
            var items = response?.Data?.ToList() ?? new List<SetupModel>();
            dg_setup.DataSource = Helpers.ToDataTable(items);
        }

        private void BtnToogle(bool isEdit)
        {
            btn_new.Visible = !isEdit;
            btn_edit.Visible = !isEdit;
            btn_save.Visible = isEdit;
            btn_cancel.Visible = isEdit;
            panel_records.Enabled = isEdit;
            dg_setup.Enabled = !isEdit;
        }

        private bool HasValidationErrors(out string messages)
        {
            bool hasError = false;
            messages = string.Empty;

            if (string.IsNullOrWhiteSpace(txt_code.Text))
            {
                messages += "Code cannot be empty\n";
                hasError = true;
            }

            if (string.IsNullOrWhiteSpace(txt_name.Text))
            {
                messages += "Name cannot be empty\n";
                hasError = true;
            }

            return hasError;
        }

        private void ClearRecordFields()
        {
            Helpers.ResetControls(panel_records);
            txt_id.Text = string.Empty;
        }

        private void btn_new_Click(object sender, EventArgs e)
        {
            ClearRecordFields();
            dg_setup.ClearSelection();
            BtnToogle(true);
            txt_code.Focus();
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            if (dg_setup.CurrentRow == null)
            {
                Helpers.ShowDialogMessage("warning", "Please select a record to edit.");
                return;
            }

            var row = dg_setup.CurrentRow;
            txt_id.Text = row.Cells["id"].Value?.ToString();
            txt_code.Text = row.Cells["code"].Value?.ToString();
            txt_name.Text = row.Cells["name"].Value?.ToString();

            BtnToogle(true);
            txt_code.Focus();
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            ClearRecordFields();
            BtnToogle(false);
        }

        private async void btn_save_Click(object sender, EventArgs e)
        {
            if (HasValidationErrors(out string errorMessage))
            {
                Helpers.ShowDialogMessage("error", errorMessage);
                return;
            }

            btn_save.Enabled = false;
            try
            {
                var model = new SetupModel
                {
                    code = txt_code.Text.Trim(),
                    name = txt_name.Text.Trim(),
                };

                bool isNew = string.IsNullOrWhiteSpace(txt_id.Text);
                HttpResponseModel<SetupModel> response;

                if (isNew)
                {
                    response = await _httpService.Post<HttpResponseModel<SetupModel>>($"/api/{_apiUrl}/", model);
                }
                else
                {
                    model.id = int.Parse(txt_id.Text);
                    response = await _httpService.Put<HttpResponseModel<SetupModel>>($"/api/{_apiUrl}/{model.id}", model);
                }

                if (response == null || !response.Success)
                {
                    Helpers.ShowDialogMessage("error", $"Failed to save {lbl_setup_title.Text}.\n{response?.Message}");
                    return;
                }

                Helpers.ShowDialogMessage("success", $"{lbl_setup_title.Text} saved successfully.");
                ClearRecordFields();
                BtnToogle(false);
                await LoadSetup();
            }
            finally
            {
                btn_save.Enabled = true;
            }
        }

        private void dg_setup_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Row selection only — editing is entered explicitly via btn_edit_Click.
        }
    }
}
