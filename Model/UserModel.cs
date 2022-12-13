using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASM1MVC.Controller;

namespace ASM1MVC.Model
{
    public class UserModel : Database 
    { 
        // properties
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int Age { get; set; }
        public string Fullname { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public double Money { get; set; }

        //constructor
        public UserModel()
        {
            
        }
    }
}
