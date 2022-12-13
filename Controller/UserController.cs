using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASM1MVC.Model;
using ASM1MVC.Controller;
using MySql.Data.MySqlClient;
using System.Data;
using ASM1MVC.View.User;
using ASM1MVC.View;

namespace ASM1MVC.Controller
{
    public class UserController : UserModel
    {
        public List<UserModel> listUser = new List<UserModel>();
        public List<UserModel> getUser()
        {
            return listUser;
        }
        public void clearList()
        {
            listUser.Clear();
        }
        public void LoadData()
        {
            try
            {
                connectDB.Open();
                MySqlDataReader rd;
                using (var cmd = new MySqlCommand())
                {
                    cmd.CommandText = $"Select * from user";
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = connectDB;
                    rd = cmd.ExecuteReader();
                    while (rd.Read())
                    {
                        UserModel tempUser = new UserModel();
                        tempUser.UserID = Convert.ToInt16(rd[0].ToString());
                        tempUser.UserName = rd[1].ToString();
                        tempUser.Password = rd[2].ToString();
                        tempUser.Age = Convert.ToInt16(rd[3].ToString());
                        tempUser.Fullname = rd[4].ToString();
                        tempUser.Address = rd[5].ToString();
                        tempUser.PhoneNumber = rd[6].ToString();
                        Console.WriteLine(rd[7].ToString());
                        tempUser.Money = Convert.ToDouble(rd[7].ToString());
                        listUser.Add(tempUser);
                    }
                }
                connectDB.Close();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        internal object GetListBook()
        {
            throw new NotImplementedException();
        }

        public Boolean CheckLogin()
        {
            try
            {
                Boolean CheckOnline = false;
                connectDB.Close();
                connectDB.Open();
                MySqlDataReader rd;
                using (var cmd = new MySqlCommand())
                {
                    cmd.CommandText = $"Select * from user where UserName = '{UserName}' and Password = '{Password}'";
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
                    cmd.CommandText = $"Select * from user where UserName = '{UserName}' and Password = '{Password}'";
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = connectDB;
                    rd = cmd.ExecuteReader();
                    while (rd.Read())
                    {
                        string tempCodeUser = rd[0].ToString();
                        UserHome tempHome = new UserHome(rd[1].ToString(), Convert.ToInt32(tempCodeUser));
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
        public Boolean CheckUserNameRegisted(UserModel tempUser)
        {
            connectDB.Close();
            connectDB.Open();
            MySqlDataReader rd;
            using (var cmd = new MySqlCommand())
            {
                cmd.CommandText = $"Select * from user where UserName = '{tempUser.UserName}'";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = connectDB;
                rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    if (rd[1].ToString() == tempUser.UserName)
                    {
                        return false;
                    }
                }
            }
            connectDB.Close();
            return true;
        }
        public void Register(UserModel tempUser)
        {
            connectDB.Close();
            connectDB.Open();
            MySqlDataReader rd;
            using (var cmd = new MySqlCommand())
            {
                cmd.CommandText = $"INSERT INTO user (UserName,Password,Age,Fullname,Address,PhoneNumber,Money) VALUES ('{tempUser.UserName}','{tempUser.Password}', '{tempUser.Age}', '{tempUser.Fullname}', '{tempUser.Address}', '{tempUser.PhoneNumber}', '{tempUser.Money}')";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = connectDB;
                rd = cmd.ExecuteReader();
            }
            connectDB.Close();
        }
        public void Update(UserModel tempUser)
        {
            connectDB.Open();
            MySqlDataReader rd;
            using (var cmd = new MySqlCommand())
            {
                cmd.CommandText = $"UPDATE user SET Password = '{tempUser.Password}',Age = '{tempUser.Age}',Fullname = '{tempUser.Fullname}',Address = '{tempUser.Address}',PhoneNumber = '{tempUser.PhoneNumber}',Money = '{tempUser.Money}' " +
                    $"WHERE UserID = '{tempUser.UserID}'; ";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = connectDB;
                rd = cmd.ExecuteReader();
            }
            connectDB.Close();
        }
        public void Delete(UserModel tempUser)
        {
            connectDB.Open();
            MySqlDataReader rd;
            using (var cmd = new MySqlCommand())
            {
                cmd.CommandText = $"DELETE FROM user WHERE UserID = {tempUser.UserID}";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = connectDB;
                rd = cmd.ExecuteReader();
            }
            connectDB.Close();
        }
    }
}
