using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASM1MVC.Controller;

namespace ASM1MVC.Model
{
    public class Admin : Database
    {
        // properties
        public int AdminID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Fullname { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public int Age { get; set; }

        //constructor
        public Admin()
        {

        }
    }
}
