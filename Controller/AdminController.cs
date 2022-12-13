using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASM1MVC.Model;
using ASM1MVC.View;
using ASM1MVC.View.Admin;
using MySql.Data.MySqlClient;

namespace ASM1MVC.Controller
{
    public class AdminController : Admin
    {
        public Boolean CheckLogin()
        {
            try
            {
                connectDB.Close();
                Boolean CheckOnline = false;
                connectDB.Open();
                MySqlDataReader rd;
                using (var cmd = new MySqlCommand())
                {
                    cmd.CommandText = $"Select * from admin where UserName = '{UserName}' and PassWord = '{Password}'";
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = connectDB;

                    rd = cmd.ExecuteReader();
                    while (rd.Read())
                    {
                        if (rd[1].ToString() == UserName && rd[2].ToString() == Password)
                        {
                            CheckOnline = true;
                        }
                    }
                }
                connectDB.Close();
                return CheckOnline;
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        public void Login()
        {
            try
            {
                connectDB.Open();
                MySqlDataReader rd;
                using (var cmd = new MySqlCommand())
                {
                    cmd.CommandText = $"Select * from admin where UserName = '{UserName}' and PassWord = '{Password}'";
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = connectDB;
                    rd = cmd.ExecuteReader();
                    while (rd.Read())
                    {
                        AdminHome tempHome = new AdminHome(rd[1].ToString());
                        tempHome.Show();
                    }
                }
                connectDB.Close();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void Logout()
        {
            try
            {
                Role tempRole = new Role();
                tempRole.Show();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
