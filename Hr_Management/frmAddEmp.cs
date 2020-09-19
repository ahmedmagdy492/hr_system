using Hr_Management.Models;
using Newtonsoft.Json;
using SharedLib.Models;
using SharedLib.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hr_Management
{
    public partial class frmAddEmp : Form
    {
        private readonly HttpClient client;
        private ResponseObject token;
        private Regex regex;
        public frmAddEmp(ResponseObject token)
        {
            InitializeComponent();
            client = new HttpClient();
            this.token = token;
        }

        private void ToggleControlsEnable(bool key)
        {
            if(key)
            {
                foreach(Control control in groupBox1.Controls)
                {
                    control.Enabled = true;
                }
            }
            else
            {
                foreach (Control control in groupBox1.Controls)
                {
                    control.Enabled = false;
                }
            }
        }

        private async void frmAddEmp_Load(object sender, EventArgs e)
        {
            txtPass.UseSystemPasswordChar = true;
            txtCpass.UseSystemPasswordChar = true;

            ToggleControlsEnable(false);

            // getting the roles
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer " + token.access_token);
            var result = await client.GetAsync(SharedLib.SharedStrings.APIURL + "api/EmployeeRole");

            if(result.IsSuccessStatusCode)
            {
                string response = await result.Content.ReadAsStringAsync();
                List<EmployeeRole> roles = JsonConvert.DeserializeObject<IEnumerable<EmployeeRole>>(response).ToList();

                cmbRoles.DataSource = roles;
                cmbRoles.DisplayMember = "RoleName";
                cmbRoles.ValueMember = "Id";
                ToggleControlsEnable(true);
            }
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            bool isValid = true;
            foreach(Control control in groupBox1.Controls)
            {
                if(control is TextBox)
                {
                    TextBox txt = ((TextBox)control);
                    if (string.IsNullOrWhiteSpace(txt.Text.Trim()))
                    {
                        isValid = false;
                        MessageBox.Show($"No Fields Can be empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    }
                }
                else if(control is MaskedTextBox)
                {
                    MaskedTextBox txtbox = (MaskedTextBox)control;
                    if(string.IsNullOrWhiteSpace(txtbox.Text.Trim()))
                    {
                        isValid = false;
                        MessageBox.Show($"No Fields Can be empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

            regex = new Regex("^[A-Za-z0-9]+@[A-Za-z]+.[A-Za-z]{1,3}$");

            if(isValid)
            {
                // TODO: send a post request to api/auth/register

                if(txtPass.Text != txtCpass.Text)
                {
                    MessageBox.Show("Password and Comfirm Password do not match", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if(!regex.IsMatch(txtEmail.Text))
                {
                    MessageBox.Show("Email is not in a correct format", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    var model = new RegisterViewModel
                    {
                        SSN = txtSsn.Text,
                        FirstName = txtFirstname.Text,
                        LastName = txtLname.Text,
                        Address = txtAddress.Text,
                        DateOfBirth = dateOfBirth.Value,
                        Password = txtPass.Text,
                        ConfirmPassword = txtCpass.Text,
                        EmailAddress = txtEmail.Text,
                        RoleId = (int)cmbRoles.SelectedValue,
                        UserName = txtEmail.Text,
                        PhoneNumbers = new List<string>()
                    };

                    var strContent = JsonConvert.SerializeObject(model);
                    btnSave.Enabled = false;
                    btnSave.Text = "Loading ...";

                    var result = await client.PostAsync(SharedLib.SharedStrings.APIURL + "api/auth/register", new StringContent(strContent, Encoding.UTF8, "application/json"));

                    if(result.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Employee has been added successfully", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    btnSave.Enabled = true;
                    btnSave.Text = "Save";
                }
            }
        }
    }
}
