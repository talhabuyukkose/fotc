using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileOnTheCloud.Shared.DbModel
{
    [DisplayName("Bildirim")]
    public class Notification
    {
        public int id { get; set; }
        public int replyid { get; set; }
        public int fromuserid { get; set; }
        public string message { get; set; }
        public DateTime createdate { get; set; }
        public bool isitseen { get; set; }
        public bool isdelete { get; set; }
        public int touserid { get; set; }
        public bool sent { get; set; }
    }
}
