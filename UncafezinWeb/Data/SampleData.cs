using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using UncafezinWeb.Entities;

namespace UncafezinWeb.Data
{
    public class SampleData : DropCreateDatabaseIfModelChanges<UncafezinContext>
    {
        protected override void Seed(UncafezinContext context)
        {
            var categories = new List<Category>
            {
                new Category {Name = "Cafés"},
                new Category {Name = "Chás"}
            };

            new List<Product>
            {
                new Product {Name = "Espresso Tradicional", Category = categories.Single(c => c.Name == "Cafés"), Price = 9.90M, Description = "Café puro e feito sob pressão, sem adição de leite ou qualquer outro ingrediente.", ImgLink = "/Content/Images/placeholder.gif"},
                new Product {Name = "Espresso com Chantilly", Category = categories.Single(c => c.Name == "Cafés"), Price = 9.90M, Description = "Café puro e feito sob pressão com uma cobertura de chantilly.", ImgLink = "/Content/Images/placeholder.gif"},
                new Product {Name = "Latte", Category = categories.Single(c => c.Name == "Cafés"), Price = 9.90M, Description = "Café espresso com leite vaporizado.", ImgLink = "/Content/Images/placeholder.gif"},
                new Product {Name = "Cappuccino", Category = categories.Single(c => c.Name == "Cafés"), Price = 12.90M, Description = "Café espresso com leite vaporizado, resultando em um creme bem consistente.", ImgLink = "/Content/Images/placeholder.gif"},
                new Product {Name = "Chá preto com pêssego (com ou sem gás)", Category = categories.Single(c => c.Name == "Chás"), Price = 12.90M, Description = "A combinação perfeita entre o chá preto e o suco de pêssego.", ImgLink = "/Content/Images/placeholder.gif"},
                new Product {Name = "Chá preto com frutas vermelhas", Category = categories.Single(c => c.Name == "Chás"), Price = 12.90M, Description = "Notas de chá preto, frutas vermelhas como mirtilo e cranberry.", ImgLink = "/Content/Images/placeholder.gif"},
            }.ForEach(p => context.Products.Add(p));
        }
    }
}