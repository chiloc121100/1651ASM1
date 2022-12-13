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
    public partial class AdminCategoryManagement : Form
    {
        CategoryController listCategory = new CategoryController();
        public AdminCategoryManagement()
        {
            InitializeComponent();
        }
        public AdminCategoryManagement(String value)
        {
            InitializeComponent();
            LoadData();
            lblName.Text = value;
        }
        public void InitData()
        {
            listCategory.ClearList();
            listCategory.LoadData();
        }
        public void LoadData()
        {
            InitData();
            datagvBooks.DataSource = null;
            datagvBooks.DataSource = listCategory.GetListCategory();
        }
        private void txtCategoryName_TextChanged(object sender, EventArgs e)
        {

        }

        private void AdminCategoryManagement_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Category tempCategory = new Category();
            tempCategory.CategoryName = txtCategoryName.Text;
            listCategory.Add(tempCategory);
            LoadData();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Category tempCategory = new Category();
            tempCategory.CategoryID = Convert.ToInt32(lblID.Text);
            tempCategory.CategoryName = txtCategoryName.Text;
            listCategory.Update(tempCategory);
            LoadData();

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Category tempCategory = new Category();
            tempCategory.CategoryID = Convert.ToInt32(lblID.Text);
            Console.WriteLine("1" + tempCategory.CategoryID);
            listCategory.Delete(tempCategory);
            LoadData();
        }

        private void datagvBooks_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {         
            lblID.Text = datagvBooks.CurrentRow.Cells[0].Value.ToString();
            txtCategoryName.Text = datagvBooks.CurrentRow.Cells[1].Value.ToString();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            Role tempRole = new Role();
            tempRole.Show();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminHome tempAdminHome = new AdminHome(lblName.Text);
            tempAdminHome.Show();
        }
    }
}
