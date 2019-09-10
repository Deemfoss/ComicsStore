using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ComicsStores.Models
{
    public class User
    {
        public string Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

    }

    public class Log
    {

        public string Login { get; set; }
        public string Password { get; set; }

    }
}