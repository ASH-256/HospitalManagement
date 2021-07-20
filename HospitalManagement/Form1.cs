using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HospitalManagement
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            
            if (username == "hms" && password ==  "pass")
            {
                //MessageBox.Show("Login Succesful");
                this.Hide();
                Dashboard dashboard = new Dashboard();
                dashboard.Show();

            }
            else
            {
                MessageBox.Show("Incorrect Credentials");
            }
        }
    }
}
