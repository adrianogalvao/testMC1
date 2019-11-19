using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApi.Data;

namespace WebApi.Models
{
    public class Produto
    {
        [Key]
        public int sku { get; set; }
        public string name { get; set; }
        [NotMapped]
        public Inventario inventory { get; set; }
        public bool isMarketable { get; set; }

        public Produto()
        {

        }
    }
}
