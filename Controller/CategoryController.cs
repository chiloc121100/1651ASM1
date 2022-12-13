using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASM1MVC.Model;
using ASM1MVC.View.Admin;
using MySql.Data.MySqlClient;

namespace ASM1MVC.Controller
{
    class CategoryController : Category
    {
       public List<Category> listCategory = new List<Category>();
       public List<Category> GetListCategory()
       {
            return listCategory;
       }
       public void ClearList()
       {
            listCategory.Clear();
       }
        public void LoadData()
        {
            try
            {
                connectDB.Open();
                MySqlDataReader rd;
                using (var cmd = new MySqlCommand())
                {
                    cmd.CommandText = $"SELECT * from category";
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = connectDB;
                    rd = cmd.ExecuteReader();
                    while (rd.Read())
                    {
                        Category tempCategory = new Category();
                        tempCategory.CategoryID = Convert.ToInt32(rd[0]);
                        tempCategory.CategoryName = rd[1].ToString();
                        listCategory.Add(tempCategory);
                    }
                }
                connectDB.Close();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void Add(Category tempCategory)
        {
            try
            {
                connectDB.Open();
                MySqlDataReader rd;
                using (var cmd = new MySqlCommand())
                {
                    cmd.CommandText = $"INSERT INTO category (CategoryName) " +
                    $"VALUES ('{tempCategory.CategoryName}')";
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = connectDB;
                    rd = cmd.ExecuteReader();
                }
                connectDB.Close();
            }
            catch
            {

            }
        }
        public void Update(Category tempCategory)
        {
            connectDB.Open();
            MySqlDataReader rd;
            using (var cmd = new MySqlCommand())
            {
                cmd.CommandText = $"UPDATE category SET CategoryName = '{tempCategory.CategoryName}' WHERE CategoryID = '{tempCategory.CategoryID}' ";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = connectDB;
                rd = cmd.ExecuteReader();
            }
            connectDB.Close();
        }
        public void Delete(Category tempCategory)
        {
            connectDB.Open();
            MySqlDataReader rd;
            try
            {
                using (var cmd = new MySqlCommand())
                {
                    Console.WriteLine("2" + tempCategory.CategoryID);
                    cmd.CommandText = $"DELETE FROM category WHERE CategoryID = {tempCategory.CategoryID}";
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = connectDB;
                    rd = cmd.ExecuteReader();
                }
            }catch
            {

            }
            connectDB.Close();
        }
        public int getCategoryNameByID(string ID)
        {
            connectDB.Open();
            MySqlDataReader rd;
            try
            {
                using (var cmd = new MySqlCommand())
                {
                    cmd.CommandText = $"SELECT CategoryID from category where CategoryName = '{ID}'";
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = connectDB;
                    rd = cmd.ExecuteReader();
                    while (rd.Read())
                    {
                        return Convert.ToInt32(rd[0].ToString());
                    }
                }
            }
            catch
            {

            }
            connectDB.Close();
            return 0;
        }
    }
}
