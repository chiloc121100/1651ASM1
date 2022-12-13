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
using ASM1MVC.Model;

namespace ASM1MVC.View.User
{
    public partial class UserRegister : Form
    {
        public UserController listUser = new UserController();
        public UserRegister()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            Boolean tempCheckRegister = false;
            UserModel tempUser = new UserModel();
            tempUser.UserName = txtUserName.Text;
            tempUser.Password = txtPassword.Text;
            tempUser.Fullname = txtFullName.Text;
            tempUser.Address = txtAddress.Text;
            tempUser.PhoneNumber = txtPhoneNumber.Text;
            tempUser.Age = Convert.ToInt16(txtAge.Text);
            tempUser.Money = 0;
            tempCheckRegister = listUser.CheckUserNameRegisted(tempUser);
            if (tempCheckRegister == true)
            {
                listUser.Register(tempUser);
                lblNotice.Text = "      Register sucessfully      ";
            }
            else
            {
                lblNotice.Text = "The UserName has been registed ";
            }

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            this.Hide();
            UserLogin tempUserLogin = new UserLogin();
            tempUserLogin.Show();
        }
    }
}
