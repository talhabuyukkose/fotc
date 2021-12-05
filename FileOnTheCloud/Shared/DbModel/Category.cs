using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileOnTheCloud.Shared.DbModel
{

    [DisplayName("Kategori")]
    public class Category
    {
        public int id { get; set; }
        public int userid { get; set; }
        public string useremail { get; set; }
        public int parentid { get; set; }
        public string categoryname { get; set; }
        public string categoryparentname { get; set; }
        public DateTime createdate { get; set; }
        public DateTime deletedate { get; set; }
        public string categorypath { get; set; }
        public bool isdelete { get; set; }
        public string categoryparentpath { get; set; }
        public int parentlevel { get; set; }
    }
}
