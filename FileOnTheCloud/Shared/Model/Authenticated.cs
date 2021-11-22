using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileOnTheCloud.Shared.Model
{
    public class Authenticated
    {
        public string email { get; set; }

        public string role { get; set; }

        public DateTime expiritontime { get; set; }

        public string token { get; set; }
    }
}
