using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ASM1MVC.Controller;

namespace ASM1MVC.View.Admin
{
    public partial class AdminLogin : Form
    {
        public AdminLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                AdminController tempAdmin = new AdminController();
                tempAdmin.UserName = txtUserName.Text;
                tempAdmin.Password = txtPassword.Text;
                tempAdmin.CheckLogin();
                if (tempAdmin.CheckLogin() == true)
                {
                    this.Hide();
                    tempAdmin.Login();
                }
                else
                {
                    lblCheckIdPassword.Text = "Incorrect account or password.";
                }

            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
