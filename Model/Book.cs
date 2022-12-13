using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASM1MVC.Controller;

namespace ASM1MVC.Model
{
    public class Book : Database
    {
        // properties
        public int BookID { get; set; }
        public string Title { get; set; }
        public string Publisher { get; set; }
        public string Edition { get; set; }
        public string Author { get; set; }
        public string Photo { get; set; }
        public int NumberOfBookLeft { get; set; }
        public double Price { get; set; }
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }

        //constructor
        public Book()
        {

        }
    }
}
