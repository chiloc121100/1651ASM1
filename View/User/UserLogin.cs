using ASM1MVC.Controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ASM1MVC.View.User
{
    public partial class UserLogin : Form
    {
        public UserLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                UserController tempUser = new UserController();
                tempUser.UserName = txtUserName.Text;
                tempUser.Password = txtPassword.Text;
                tempUser.CheckLogin();
                if (tempUser.CheckLogin() == true)
                {
                    this.Hide();
                    tempUser.Login();
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

        private void btnRegister_Click(object sender, EventArgs e)
        {
            this.Hide();
            UserRegister tempUserRegister = new UserRegister();
            tempUserRegister.Show();
        }
    }
}
