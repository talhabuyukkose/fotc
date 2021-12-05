using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileOnTheCloud.Shared.DbModel
{

    [DisplayName("Notlar")]
    public class SavedFile
    {
        public int id { get; set; }
        public int userid { get; set; }
        public string useremail { get; set; }
        public string filename { get; set; }
        public string filesize { get; set; }
        public bool isdelete { get; set; }
        public string filepath { get; set; }
        public string fileextension { get; set; }
        public string department { get; set; }
        public string grade { get; set; }
        public string semester { get; set; }
        public string midtermandfinal { get; set; }
        public DateTime createdate { get; set; }
        public DateTime deletedate { get; set; }
        public string localpath { get; set; }
        public IFormFile formFile { get; set; }
        public string contenttype { get; set; }
    }
}
