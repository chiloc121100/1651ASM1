using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ASM1MVC.View.Admin;
using ASM1MVC.View.User;

namespace ASM1MVC.View
{
    public partial class Role : Form
    {
        public Role()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            UserLogin tempUserLogin = new UserLogin();
            tempUserLogin.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminLogin tempAdminLogin = new AdminLogin();
            tempAdminLogin.Show();
        }
    }
}
