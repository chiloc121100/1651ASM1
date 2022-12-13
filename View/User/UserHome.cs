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
    public partial class UserHome : Form
    {
        public BookController tempListBook = new BookController();
        public RentBookController listUserRentBook = new RentBookController();

        public UserHome()
        {
            InitializeComponent();
        }
        public UserHome(String value, int CodeUser)
        {
            InitializeComponent();
            InitData();
            LoadData();
            LoadCategory();
            lblName.Text = value;
            lblIDUser.Text = CodeUser.ToString();
        }
        public void InitData()
        {
            tempListBook.clearList();
            tempListBook.LoadData();
        }
        public void LoadData()
        {
            InitData();
            datagvBooks.DataSource = null;
            datagvBooks.DataSource = tempListBook.GetListBook();
            //int sizeWidth = 120;
            //for (int i = 0; i < 6; i++)
            //{
            //    datagvBooks.Columns[i].Width = sizeWidth;
            //}
        }
        public void LoadCategory()
        {
            CategoryController tempListCategory = new CategoryController();
            tempListCategory.LoadData();
            foreach (var tempCategory in tempListCategory.listCategory)
            {
                cbCategory.Items.Add(tempCategory.CategoryName);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                RentBook tempBook = new RentBook();
                tempBook.BookIDRentBook = Convert.ToInt32(txtCode.Text);
                tempBook.UserIDRentBook = Convert.ToInt32(lblIDUser.Text);
                //Console.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                tempBook.TimeRentBook = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                string message = $" do you want to rent this book ?\nID Book = '{tempBook.BookIDRentBook}' \nID User = '{tempBook.UserIDRentBook}' \nTime rent book = '{tempBook.TimeRentBook}'";
                string caption = " Confirmation Delete";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                MessageBoxIcon icon = MessageBoxIcon.Question;
                if (txtCode.Text != "")
                {
                    DialogResult result = MessageBox.Show(message, caption, buttons, icon);
                    if (result == DialogResult.Yes)
                    {                     
                        listUserRentBook.Add(tempBook);
                    }
                }
            }
            catch
            {
            }
           
        }

        private void runOptions_Click(object sender, EventArgs e)
        {
            if(cbOptions.SelectedItem.ToString() == "Search By Book ID")
            {
                tempListBook.clearList();
                Book tempBook = new Book();
                tempBook.BookID = Convert.ToInt16(txtOptions.Text);
                tempListBook.SearchBookByID(tempBook);
                datagvBooks.DataSource = null;
                datagvBooks.DataSource = tempListBook.GetListBook();

            } else if (cbOptions.SelectedItem.ToString() == "View All Book")
            {
                LoadData();
            }
            else 
            {
                tempListBook.clearList();
                Book tempBook = new Book();
                tempBook.Author = txtOptions.Text;
                tempListBook.SearchBookByAuthor(tempBook);
                datagvBooks.DataSource = null;
                datagvBooks.DataSource = tempListBook.GetListBook();
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
            txtCode.Text = datagvBooks.CurrentRow.Cells[0].Value.ToString();         // CurrentRow la cai click hien tai. Cell la o^ thu may. lay' value va chuyen sang string  
            txtTitle.Text = datagvBooks.CurrentRow.Cells[1].Value.ToString();
            txtPublisher.Text = datagvBooks.CurrentRow.Cells[2].Value.ToString();
            txtEdition.Text = datagvBooks.CurrentRow.Cells[3].Value.ToString();
            txtAuthor.Text = datagvBooks.CurrentRow.Cells[4].Value.ToString();
            cbCategory.SelectedItem = datagvBooks.CurrentRow.Cells[9].Value.ToString();
            txtNumLeft.Text = datagvBooks.CurrentRow.Cells[6].Value.ToString();
            txtPrice.Text = datagvBooks.CurrentRow.Cells[7].Value.ToString();
            string exePath = Application.StartupPath;
            img1.ImageLocation = exePath + "\\images\\" +
                datagvBooks.CurrentRow.Cells[5].Value.ToString();
            img1.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void cbOptions_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            UserRentBook tempUserRentBook = new UserRentBook(lblName.Text,Convert.ToInt16(lblIDUser.Text));
            tempUserRentBook.Show();
        }

        private void txtOptions_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
