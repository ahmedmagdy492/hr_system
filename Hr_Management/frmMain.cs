using Hr_Management.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hr_Management
{
    public partial class frmMain : Form
    {
        private string username;
        public ResponseObject Token { get; private set; }
        public frmMain(ResponseObject responseObject, string username)
        {
            InitializeComponent();
            Token = responseObject;
            this.username = username;
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            lblUserName.Text = $"Welcome {username}";
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.OpenForms[0].Close();
        }

        private void lblLogout_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Application.OpenForms[0].Show();
        }

        private void btnAddEmployee_Click(object sender, EventArgs e)
        {
            frmAddEmp frmAddEmp = new frmAddEmp(Token);
            frmAddEmp.ShowDialog();
        }
    }
}
