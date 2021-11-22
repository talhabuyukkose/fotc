using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileOnTheCloud.Shared.DbModel
{
    public class User
    {
        public int id { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public string title { get; set; }
        public string password { get; set; }
        public string emailaddress { get; set; }
        public string department { get; set; }
        public string role { get; set; }
    }
}
