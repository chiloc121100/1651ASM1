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
    public partial class AdminUserRentBookManagement : Form
    {
        public RentBookController listUserRentBook = new RentBookController();
        public AdminUserRentBookManagement(String value)
        {
            InitializeComponent();
            lblName.Text = value;
            InitData();
            LoadData();
        }
        public void InitData()
        {
            listUserRentBook.clearList();
            RentBook tempRentBook = new RentBook();
            listUserRentBook.LoadAllData();
        }
        public void LoadData()
        {
            InitData();
            datagvBooks.DataSource = null;
            datagvBooks.DataSource = listUserRentBook.GetListBook();
            //int sizeWidth = 120;
            //for (int i = 0; i < 6; i++)
            //{
            //    datagvBooks.Columns[i].Width = sizeWidth;
            //}
        }
        private void AdminUserRentBookManagement_Load(object sender, EventArgs e)
        {

        }

        private void btnReturnBook_Click(object sender, EventArgs e)
        {
            try
            {
                string message = $" do you want to return this book ID = '{lblGetBookID.Text}' ?";
                string caption = " Return book ";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                MessageBoxIcon icon = MessageBoxIcon.Question;
                if (lblGetBookID.Text != "")
                {
                    DialogResult result = MessageBox.Show(message, caption, buttons, icon);
                    if (result == DialogResult.Yes)
                    {
                        RentBook tempRentBook = new RentBook();
                        tempRentBook.BookIDRentBook = Convert.ToInt16(lblGetBookID.Text);
                        listUserRentBook.ReturnBook(tempRentBook);
                        LoadData();
                    }
                }
            }
            catch
            {

            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            Role tempRole = new Role();
            tempRole.Show();
        }

        private void datagvBooks_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            lblGetBookID.Text = datagvBooks.CurrentRow.Cells[0].Value.ToString();         // CurrentRow la cai click hien tai. Cell la o^ thu may. lay' value va chuyen sang string  
            lblGetUserID.Text = datagvBooks.CurrentRow.Cells[1].Value.ToString();
            lblTimeRent.Text = datagvBooks.CurrentRow.Cells[2].Value.ToString();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminHome tempAdminHome = new AdminHome(lblName.Text);
            tempAdminHome.Show();
        }
    }
}
