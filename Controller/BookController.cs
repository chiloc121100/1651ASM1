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
    public class BookController : Book
    {
        public List<Book> listBook = new List<Book>();
        public List<Book> GetListBook()
        {
            listBook = listBook.OrderBy(q => q.BookID).ToList();
            return listBook;
        }
        public void clearList()
        {
            listBook.Clear();
        }
        public void LoadData()
        {
            try
            {
                connectDB.Close();
                connectDB.Open();
                MySqlDataReader rd;
                using (var cmd = new MySqlCommand())
                {
                    cmd.CommandText = $"SELECT BookID,CategoryName,Title,Publisher,Edition,Author,Photo,NumberOfBookLeft,Price,book.CategoryID FROM category,book WHERE category.CategoryID = book.CategoryID;";
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = connectDB;
                    rd = cmd.ExecuteReader();
                    while (rd.Read())
                    {
                        Book tempBook = new Book();
                        tempBook.BookID = Convert.ToInt32(rd[0]);
                        tempBook.CategoryName = rd[1].ToString();
                        tempBook.Title = rd[2].ToString();
                        tempBook.Publisher = rd[3].ToString();
                        tempBook.Edition = rd[4].ToString();
                        tempBook.Author = rd[5].ToString();
                        tempBook.Photo = rd[6].ToString();
                        tempBook.NumberOfBookLeft = Convert.ToInt16(rd[7]);
                        tempBook.Price = Convert.ToDouble(rd[8]);
                        tempBook.CategoryID = Convert.ToInt32(rd[9]);
                        listBook.Add(tempBook);
                    }
                }
                connectDB.Close();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
       
        public void Add(Book tempBook)
        {
            // de sau
            try
            {
                connectDB.Open();
                MySqlDataReader rd;
                using (var cmd = new MySqlCommand())
                {
                    cmd.CommandText = $"INSERT INTO book (Title,Publisher,Edition,Author,Photo,NumberOfBookLeft,Price,CategoryID) " +
                    $"VALUES ('{tempBook.Title}','{tempBook.Publisher}','{tempBook.Edition}','{tempBook.Author}','{tempBook.Photo}','{tempBook.NumberOfBookLeft}','{tempBook.Price}','{tempBook.CategoryID}')";
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
        public void Update(Book tempBook)
        {
            connectDB.Open();
            MySqlDataReader rd;
            using (var cmd = new MySqlCommand())
            {
                cmd.CommandText = $"UPDATE book SET Title = '{tempBook.Title}',Publisher = '{tempBook.Publisher}',Edition = '{tempBook.Edition}',Author = '{tempBook.Author}',Photo = '{tempBook.Photo}',NumberOfBookLeft = '{tempBook.NumberOfBookLeft}',CategoryID = '{tempBook.CategoryID}' " +
                    $"WHERE BookID = '{tempBook.BookID}'; ";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = connectDB;
                rd = cmd.ExecuteReader();
            }
            connectDB.Close();
        }
        public void Delete(Book tempBook)
        {
            listBook.Remove(tempBook);
            connectDB.Open();
            MySqlDataReader rd;
            using (var cmd = new MySqlCommand())
            {
                cmd.CommandText = $"DELETE FROM book WHERE BookID = {tempBook.BookID};";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = connectDB;
                rd = cmd.ExecuteReader();
            }
            connectDB.Close();
        }
        public void SearchBookByID(Book tempBook2)
        {
            connectDB.Open();
            MySqlDataReader rd;
            using (var cmd = new MySqlCommand())
            {
                cmd.CommandText = $"SELECT BookID,CategoryName,Title,Publisher,Edition,Author,Photo,NumberOfBookLeft,Price,book.CategoryID FROM category,book WHERE category.CategoryID = book.CategoryID and book.BookID Like '%{tempBook2.BookID}%';";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = connectDB;
                rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    Book tempBook = new Book();
                    tempBook.BookID = Convert.ToInt32(rd[0]);
                    tempBook.CategoryName = rd[1].ToString();
                    tempBook.Title = rd[2].ToString();
                    tempBook.Publisher = rd[3].ToString();
                    tempBook.Edition = rd[4].ToString();
                    tempBook.Author = rd[5].ToString();
                    tempBook.Photo = rd[6].ToString();
                    tempBook.NumberOfBookLeft = Convert.ToInt16(rd[7]);
                    tempBook.Price = Convert.ToDouble(rd[8]);
                    tempBook.CategoryID = Convert.ToInt32(rd[9]);
                    listBook.Add(tempBook);
                }
            }
            connectDB.Close();
        }
        public void SearchBookByAuthor(Book tempBook2)
        {
            connectDB.Open();
            MySqlDataReader rd;
            using (var cmd = new MySqlCommand())
            {
                cmd.CommandText = $"SELECT BookID,CategoryName,Title,Publisher,Edition,Author,Photo,NumberOfBookLeft,Price,book.CategoryID FROM category,book WHERE category.CategoryID = book.CategoryID and book.Author Like '%{tempBook2.Author}%';";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = connectDB;
                rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    Book tempBook = new Book();
                    tempBook.BookID = Convert.ToInt32(rd[0]);
                    tempBook.CategoryName = rd[1].ToString();
                    tempBook.Title = rd[2].ToString();
                    tempBook.Publisher = rd[3].ToString();
                    tempBook.Edition = rd[4].ToString();
                    tempBook.Author = rd[5].ToString();
                    tempBook.Photo = rd[6].ToString();
                    tempBook.NumberOfBookLeft = Convert.ToInt16(rd[7]);
                    tempBook.Price = Convert.ToDouble(rd[8]);
                    tempBook.CategoryID = Convert.ToInt32(rd[9]);
                    listBook.Add(tempBook);
                }
            }
            connectDB.Close();
        }
    }
}
