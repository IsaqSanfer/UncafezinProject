using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UncafezinWeb.Entities
{
    public class Account
    {
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
        public string ConfirmPassword { get; set; }
    }

    public class LogOnModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool RemembreMe { get; set; }
    }

    public class RegisterModel
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}