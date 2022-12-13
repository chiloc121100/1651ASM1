using ASM1MVC.Controller;
using ASM1MVC.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ASM1MVC.View.Admin
{
    public partial class AdminHome : Form
    {
        public BookController tempListBook = new BookController();
        public AdminHome()
        {
            InitializeComponent();
            LoadData();
            LoadCategory();
        }
        public AdminHome(String value)
        {
            InitializeComponent();
            LoadData();
            LoadCategory();
            lblName.Text = value;
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
        private void txtTitle_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminCategoryManagement tempAddCategory = new AdminCategoryManagement(lblName.Text);
            tempAddCategory.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string tempName = "";
            SaveFileDialog sf = new SaveFileDialog();
            sf.Filter = "jpg files(*.jpg)|*.jpg| PNG files(*.png)|*.png| All Files(*.*)|*.*";
            if (sf.ShowDialog() == DialogResult.OK)
            {
                img1.Image.Save(sf.FileName);
                tempName = sf.FileName;
            }
            try
            {
                Book tempBook = new Book();
                tempBook.Title = txtTitle.Text;
                tempBook.Publisher = txtPublisher.Text;
                tempBook.Edition = txtEdition.Text;
                tempBook.Author = txtAuthor.Text;
                tempBook.Photo = img1.Text;
                CategoryController tempCa = new CategoryController();
                tempBook.CategoryID = tempCa.getCategoryNameByID(cbCategory.SelectedItem.ToString());
                //tach chuoi
                string strTempName = tempName.Substring(tempName.IndexOf("images")+6); // tempName.IndexOf("images") la` tim chu~ trong chuoi string
                tempBook.Photo = strTempName;//img1.Text;
                tempBook.Price = Convert.ToDouble(txtPrice.Text);
                //tempBook.CategoryName = txtPublisher.Text;
                tempListBook.Add(tempBook);
                LoadData();
            }
            catch

            {

            }
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

        private void AdminHome_Load(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                string message = $" do you want to delete this book ID = '{txtCode.Text}' ?";
                string caption = " Confirmation Delete";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                MessageBoxIcon icon = MessageBoxIcon.Question;
                if (txtCode.Text != "")
                {
                    DialogResult result = MessageBox.Show(message, caption, buttons, icon);
                    if (result == DialogResult.Yes)
                    {
                        Book tempBook = new Book();
                        tempBook.BookID = Convert.ToInt32(txtCode.Text);
                        tempListBook.Delete(tempBook);
                        LoadData();
                    }
                }
            }
            catch
            {

            }
        }

        private void cbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
          
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            String imageLocation = "";
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "jpg files(*.jpg)|*.jpg| PNG files(*.png)|*.png| All Files(*.*)|*.*";

                if(dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    imageLocation = dialog.FileName;
                    img1.ImageLocation = imageLocation;
                }
            }
            catch (Exception)
            {

            }
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string tempName = "";
            SaveFileDialog sf = new SaveFileDialog();
            sf.Filter = "jpg files(*.jpg)|*.jpg| PNG files(*.png)|*.png| All Files(*.*)|*.*";
            try
            {
                if (sf.ShowDialog() == DialogResult.OK)
                {
                    img1.Image.Save(sf.FileName);
                    tempName = sf.FileName;
                }
            }
            catch
            {

            }
            try
            {
                Book tempBook = new Book();
                tempBook.BookID = Convert.ToInt32(txtCode.Text);
                tempBook.Title = txtTitle.Text;
                tempBook.Publisher = txtPublisher.Text;
                tempBook.Edition = txtEdition.Text;
                tempBook.Author = txtAuthor.Text;
                tempBook.Photo = img1.Text;
                tempBook.NumberOfBookLeft = Convert.ToInt16(txtNumLeft.Text);
                CategoryController tempCa = new CategoryController();
                tempBook.CategoryID = tempCa.getCategoryNameByID(cbCategory.SelectedItem.ToString());
                //tach chuoi
                string strTempName = tempName.Substring(tempName.IndexOf("images") + 6); // tempName.IndexOf("images") la` tim chu~ trong chuoi string
                tempBook.Photo = strTempName;//img1.Text;
                tempBook.Price = Convert.ToDouble(txtPrice.Text);
                //tempBook.CategoryName = txtPublisher.Text;
                tempListBook.Update(tempBook);
                LoadData();
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

        private void cbOptions_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminUserRentBookManagement tempRentbook = new AdminUserRentBookManagement(lblName.Text);
            tempRentbook.Show();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminUserManagement tempUserMana = new AdminUserManagement(lblName.Text);
            tempUserMana.Show();
        }

        private void runOptions_Click(object sender, EventArgs e)
        {
            if (cbOptions.SelectedItem.ToString() == "Search By Book ID")
            {
                tempListBook.clearList();
                Book tempBook = new Book();
                tempBook.BookID = Convert.ToInt16(txtOptions.Text);
                tempListBook.SearchBookByID(tempBook);
                datagvBooks.DataSource = null;
                datagvBooks.DataSource = tempListBook.GetListBook();

            }
            else if (cbOptions.SelectedItem.ToString() == "View All Book")
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
    }
}
