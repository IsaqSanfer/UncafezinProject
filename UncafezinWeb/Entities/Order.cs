using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UncafezinWeb.Entities
{
    [Bind(Exclude = "OrderId")]
    public class Order
    {
        [ScaffoldColumn(false)]
        public int OrderId { get; set; }

        [ScaffoldColumn(false)]
        public DateTime OrderDate { get; set; }

        [ScaffoldColumn(false)]
        public string UserName { get; set; }


        [Required(ErrorMessage = "Nome obrigatório")]
        [DisplayName("Nome")]
        [StringLength(160)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Sobrenome obrigatório")]
        [DisplayName("Sobrenome")]
        [StringLength(160)]
        public string LastName { get; set; }


        [Required(ErrorMessage = "Endereço obrigatório")]
        [DisplayName("Endereço")]
        [StringLength(70)]
        public string Address { get; set; }

        [Required(ErrorMessage = "Bairro obrigatório")]
        [DisplayName("Bairro")]
        [StringLength(40)]
        public string District { get; set; }

        [Required(ErrorMessage = "Estado obrigatório")]
        [DisplayName("UF")]
        [StringLength(2)]
        public string State { get; set; }

        [Required(ErrorMessage = "Cidade obrigatória")]
        [DisplayName("Cidade")]
        [StringLength(40)]
        public string City { get; set; }

        [Required(ErrorMessage = "País obrigatório")]
        [DisplayName("País")]
        [StringLength(40)]
        public string Country { get; set; }

        [Required(ErrorMessage = "CEP obrigatório")]
        [DisplayName("CEP")]
        [StringLength(8, MinimumLength = 8, ErrorMessage = "O CEP deve ter 8 caracteres")]
        [RegularExpression(@"^\d{8}$", ErrorMessage = "CEP inválido")]
        public string PostalCode { get; set; }



        [Required(ErrorMessage = "Telefone obrigatório")]
        [DisplayName("Telefone")]
        [StringLength(24)]
        [RegularExpression(@"^\(?\d{2}\)?[-.\s]?\d{4,5}[-.\s]?\d{4}$", ErrorMessage = "Telefone inválido.")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "E-mail obrigatório")]
        [DisplayName("E-mail")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "E-mail inválido.")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }


        [ScaffoldColumn(false)]
        public decimal Total { get; set; }

        public List<OrderDetail> OrderDetails { get; set; }
    }
}