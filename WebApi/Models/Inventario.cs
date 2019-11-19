using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Models
{
    public class Inventario
    {
        public int quantity { get; set; }
        [NotMapped]
        public List<Armazem> warehouses { get; set; }

        public Inventario()
        {
        }
    }
}
