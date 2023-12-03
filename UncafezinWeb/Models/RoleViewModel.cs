using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UncafezinWeb.Models
{
    public class RoleViewModel
    {
        public string RoleName { get; set; }
        public List<RolesLista> RolesLista { get; set; }
    }
    public class RolesLista
    {
        public string RoleId { get; set; }
        public string RoleName { get; set; }
    }
}