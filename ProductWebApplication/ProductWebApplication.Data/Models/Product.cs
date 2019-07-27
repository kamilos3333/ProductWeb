using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ProductWebApplication.Data.Models
{
    public class Product
    {
        public Product()
        {
            Id = new Guid();
        }

        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}
