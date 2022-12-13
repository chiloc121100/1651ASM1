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

namespace ASM1MVC.View.User
{
    public partial class UserRentBook : Form
    {
        //public BookController tempListBook = new BookController();
        public RentBookController listUserRentBook = new RentBookController();
        public UserRentBook(String value,int code)
        {
            InitializeComponent();
            lblUserID.Text = code.ToString();
            lblName.Text = value;
            InitData();
            LoadData();
        }
        public void InitData()
        {
            listUserRentBook.clearList();
            RentBook tempRentBook = new RentBook();
            Console.WriteLine(lblUserID.Text);
            listUserRentBook.LoadData(lblUserID.Text);
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
        private void button1_Click(object sender, EventArgs e)
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

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void lblUserID_Click(object sender, EventArgs e)
        {

        }

        private void datagvBooks_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            lblGetBookID.Text = datagvBooks.CurrentRow.Cells[0].Value.ToString();
            lblGetUserID.Text = datagvBooks.CurrentRow.Cells[1].Value.ToString();
            lblTimeRent.Text = datagvBooks.CurrentRow.Cells[2].Value.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            UserHome tempUserHome = new UserHome(lblName.Text, Convert.ToInt16(lblUserID.Text));
            tempUserHome.Show();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            Role tempRole = new Role();
            tempRole.Show();
        }

        private void UserRentBook_Load(object sender, EventArgs e)
        {

        }
    }
}
