using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASM1MVC.Controller;

namespace ASM1MVC.Model
{
    public class RentBook : Database
    {
        public int BookIDRentBook { get; set; }
        public int UserIDRentBook { get; set; }
        public string TimeRentBook { get; set; }
        public RentBook()
        {

        }
    }
}
