using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UncafezinWeb.Models
{
    public class UserRoleViewModel
    {
        public string UserId { get; set; }
        public string RoleName { get; set; }
        public List<string> RolesUser { get; set; }
    }
}