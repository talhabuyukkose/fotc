﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileOnTheCloud.Shared.DbModel
{
    [DisplayName("Kullanıcı Logu")]
    public class UserLog
    {
        public int id { get; set; }

        public string email { get; set; }

        public DateTime createdate { get; set; }

        public string description { get; set; }
    }
}
