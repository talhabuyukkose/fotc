using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileOnTheCloud.Shared.Model
{
    [DisplayName("Bildirim")]
    public class GetNotification_WithEmail
    {
        public int id { get; set; }
        public string frommail { get; set; }
        public string tomail { get; set; }
        public string message { get; set; }
        public DateTime createdate { get; set; }
        public bool isitseen { get; set; }
        
    }
}
