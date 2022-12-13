using ASM1MVC.Controller;
using ASM1MVC.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ASM1MVC.View.Admin
{
    public partial class AdminUserManagement : Form
    {
        public UserController listUser = new UserController();
        public AdminUserManagement(string value)
        {
            InitializeComponent();
            lblName.Text = value;
            LoadData();
        }
        public void InitData()
        {
            listUser.clearList();
            listUser.LoadData();
        }
        public void LoadData()
        {
            InitData();
            datagvBooks.DataSource = null;
            datagvBooks.DataSource = listUser.getUser();
            //int sizeWidth = 120;
            //for (int i = 0; i < 6; i++)
            //{
            //    datagvBooks.Columns[i].Width = sizeWidth;
            //}
        }
        private void AdminUserManagement_Load(object sender, EventArgs e)
        {

        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            Role tempRole = new Role();
            tempRole.Show();
        }

        private void datagvBooks_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
                lblGetUserID.Text = datagvBooks.CurrentRow.Cells[0].Value.ToString();
                lblGetUserName.Text = datagvBooks.CurrentRow.Cells[1].Value.ToString();
                txtPassword.Text = datagvBooks.CurrentRow.Cells[2].Value.ToString();
                txtAge.Text = datagvBooks.CurrentRow.Cells[3].Value.ToString();
                txtFullname.Text = datagvBooks.CurrentRow.Cells[4].Value.ToString();
                txtAddress.Text = datagvBooks.CurrentRow.Cells[5].Value.ToString();
                txtPhone.Text = datagvBooks.CurrentRow.Cells[6].Value.ToString();
                txtMoney.Text = datagvBooks.CurrentRow.Cells[7].Value.ToString();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminHome tempAdminHome = new AdminHome(lblName.Text);
            tempAdminHome.Show();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            UserModel tempUser = new UserModel();
            tempUser.UserID = Convert.ToInt32(lblGetUserID.Text);
            tempUser.UserName = lblGetUserName.Text;
            tempUser.Password = txtPassword.Text;
            tempUser.Age = Convert.ToInt32(txtAge.Text);
            tempUser.Fullname = txtFullname.Text;
            tempUser.Address = txtAddress.Text;
            tempUser.PhoneNumber = txtPhone.Text;
            tempUser.Money = Convert.ToDouble(txtMoney.Text);
            listUser.Update(tempUser);

            LoadData();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                string message = $" do you want to delete this user ID = '{lblGetUserID.Text}' ?";
                string caption = " Confirmation Delete";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                MessageBoxIcon icon = MessageBoxIcon.Question;
                if (lblGetUserID.Text != "")
                {
                    DialogResult result = MessageBox.Show(message, caption, buttons, icon);
                    if (result == DialogResult.Yes)
                    {
                        UserModel tempUser = new UserModel();
                        tempUser.UserID = Convert.ToInt32(lblGetUserID.Text);
                        listUser.Delete(tempUser);
                        LoadData();
                    }
                }
            }
            catch
            {

            }
        }
    }
}
