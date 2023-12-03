using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UncafezinWeb.Entities
{
    [Bind(Exclude = "ProductId")]
    public class Product
    {
        [ScaffoldColumn(false)]
        public int ProductId { get; set; }

        [DisplayName("Categoria")]
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "Nome do Produto obrigatório")]
        [StringLength(160)]
        [DisplayName("Produto")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Preço obrigatório")]
        [Range(1.00, 500.00, ErrorMessage = "Valor não permitido")]
        [DisplayName("Preço")]
        public decimal Price { get; set; }

        [DisplayName("Link da Imagem")]
        public string ImgLink { get; set; }

        [DisplayName("Descrição")]
        public string Description { get; set; }


        public virtual Category Category { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
    }
}