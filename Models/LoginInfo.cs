using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ORMS_WebService.Models
{
    public class LoginInfo
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }

    public class LoginStatus
    {
        public int Status { get; set; }
        public string Role { get; set; }
        public string CustomerID { get; set; }
    }
}