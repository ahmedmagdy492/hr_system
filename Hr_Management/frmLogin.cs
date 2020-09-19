using Hr_Management.Models;
using Newtonsoft.Json;
using SharedLib;
using SharedLib.ViewModels;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hr_Management
{
    public partial class frmLogin : Form
    {
        private readonly HttpClient client;
        private HttpContent messageBody;

        public frmLogin()
        {
            InitializeComponent();
            client = new HttpClient();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            txtPass.UseSystemPasswordChar = true;
        }

        private void DimOrUndim(bool dim)
        {
            if(dim)
            {
                btnLogin.Enabled = false;
                btnLogin.Text = "Loading...";
            }
            else
            {
                btnLogin.Enabled = true;
                btnLogin.Text = "Login";
            }
        }

        private async Task<HttpResponseMessage> Login()
        {
            messageBody = new StringContent($"username={txtUsername.Text}&password={txtPass.Text}&grant_type=password", Encoding.Default, "application/x-www-form-urlencoded");
            DimOrUndim(true);
            var responseStatus = await client.PostAsync(SharedStrings.APIURL + "token", messageBody);
            return responseStatus;
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrWhiteSpace(txtUsername.Text.Trim())
                && !string.IsNullOrWhiteSpace(txtPass.Text.Trim())
                )
            {
                var loginResult = await Login();
                if (loginResult.IsSuccessStatusCode)
                {
                    var resObject = JsonConvert.DeserializeObject<ResponseObject>(await loginResult.Content.ReadAsStringAsync());
                    this.Hide();
                    frmMain frm = new frmMain(resObject, txtUsername.Text);
                    frm.Show();
                }
                else if(loginResult.StatusCode == System.Net.HttpStatusCode.BadRequest)
                {
                    MessageBox.Show("Incorrect username or password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                DimOrUndim(false);
            }
            else
            {
                MessageBox.Show("Invalid username or password", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
