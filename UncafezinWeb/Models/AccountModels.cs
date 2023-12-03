using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UncafezinWeb.Models
{
    public class ChangePasswordModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Senha atual")]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "A {0} deve ter pelo menos {2} caracteres.", MinimumLength = 8)]
        [DataType(DataType.Password)]
        [Display(Name = "Nova Senha")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirme a nova senha")]
        [Compare("NewPassword", ErrorMessage = "A nova senha e a confirmação de senha não coincidem.")]
        public string ConfirmPassword { get; set; }
    }

    public class LogOnModel
    {
        [Required]
        [Display(Name = "Nome de Usuário")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string Password { get; set; }

        [Display(Name = "Lembrar?")]
        public bool RemembreMe { get; set; }
    }

    public class RegisterModel
    {
        [Required]
        [Display(Name = "Nome de Usuário")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "E-mail de Acesso")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "A {0} deve ter pelo menos {2} caracteres.", MinimumLength = 8)]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirme a nova senha")]
        [Compare("NewPassword", ErrorMessage = "A nova senha e a confirmação de senha não coincidem.")]
        public string ConfirmPassword { get; set; }
    }
}