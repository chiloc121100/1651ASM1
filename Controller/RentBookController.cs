using ASM1MVC.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASM1MVC.Controller
{
    public class RentBookController : RentBook
    {
        public List<RentBook> listRentBook = new List<RentBook>();
        public List<RentBook> GetListBook()
        {
            listRentBook = listRentBook.OrderBy(q => q.BookIDRentBook).ToList();
            return listRentBook;
        }
        public void clearList()
        {
            listRentBook.Clear();
        }
        public void LoadData(string UserID)
        {
            try
            {
                connectDB.Close();
                connectDB.Open();
                MySqlDataReader rd;
                using (var cmd = new MySqlCommand())
                {
                    cmd.CommandText = $"Select * from userrentbook where UserID = '{UserID}'";
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = connectDB;
                    rd = cmd.ExecuteReader();
                    while (rd.Read())
                    {
                        RentBook tempInfo = new RentBook();
                        tempInfo.TimeRentBook = rd[1].ToString();
                        tempInfo.UserIDRentBook = Convert.ToInt16(rd[2].ToString());
                        tempInfo.BookIDRentBook = Convert.ToInt16(rd[3].ToString());
                        listRentBook.Add(tempInfo);
                    }
                }
                connectDB.Close();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void LoadAllData()
        {
            try
            {
                connectDB.Close();
                connectDB.Open();
                MySqlDataReader rd;
                using (var cmd = new MySqlCommand())
                {
                    cmd.CommandText = $"Select * from userrentbook";
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = connectDB;
                    rd = cmd.ExecuteReader();
                    while (rd.Read())
                    {
                        try
                        {
                            RentBook tempInfo = new RentBook();
                            tempInfo.TimeRentBook = rd[1].ToString();
                            tempInfo.UserIDRentBook = Convert.ToInt16(rd[2].ToString());
                            tempInfo.BookIDRentBook = Convert.ToInt16(rd[3].ToString());
                            listRentBook.Add(tempInfo);
                        }
                        catch
                        {

                        }
                    }
                }
                connectDB.Close();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void Add(RentBook tempBook)
        {
            // de sau
            try
            {
                connectDB.Open();
                MySqlDataReader rd;
                using (var cmd = new MySqlCommand())
                {
                    cmd.CommandText = $"INSERT INTO userrentbook (BookID,UserID,dateRent) " +
                    $"VALUES ('{tempBook.BookIDRentBook}','{tempBook.UserIDRentBook}','{tempBook.TimeRentBook}')";
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
        public void ReturnBook(RentBook tempBook)
        {
            connectDB.Open();
            MySqlDataReader rd;
            using (var cmd = new MySqlCommand())
            {
                cmd.CommandText = $"DELETE FROM userrentbook WHERE BookID = {tempBook.BookIDRentBook};";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = connectDB;
                rd = cmd.ExecuteReader();
            }
            connectDB.Close();
        }
    }
}
