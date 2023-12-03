using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UncafezinWeb.Models
{
    public class UsersViewModel
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public List<string> RolesUser { get; set; }

    }
}