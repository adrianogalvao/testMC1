using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WebApi.Data
{
    public class ApiContext : DbContext
    {
        public DbSet<Produto> Produtos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Armazem>().HasNoKey();
            modelBuilder.Entity<Inventario>().HasNoKey();
        }

        public ApiContext(DbContextOptions<ApiContext> options) : base(options)
        {            
            ProdutoDadosTeste();
        }

        private void ProdutoDadosTeste()
        {
            var produto = new Produto()
            {
                sku = 43264,
                name = "Batata frita Ruffles Cebola & Salsa",
                inventory = new Inventario()
                {
                    quantity = 15,
                    warehouses = new List<Armazem>()
                        {
                            new Armazem()
                            {
                                locality = "SP",
                                quantity = 12,
                                type = "ECOMMERCE"
                            },
                            new Armazem()
                            {
                                locality = "MOEMA",
                                quantity = 3,
                                type = "PHYSICAL_STORE"
                            }
                        }
                },
                isMarketable = true
            };

            Produtos.Add(produto);

            produto = new Produto()
            {
                sku = 43265,
                name = "Batata doce frita",
                inventory = new Inventario()
                {
                    quantity = 15,
                    warehouses = new List<Armazem>()
                    {
                        new Armazem()
                        {
                            locality = "SP",
                            quantity = 12,
                            type = "ECOMMERCE"
                        },
                        new Armazem()
                        {
                            locality = "MOEMA",
                            quantity = 3,
                            type = "PHYSICAL_STORE"
                        }
                    }
                },
                isMarketable = true
            };

            Produtos.Add(produto);            
        }
    }
}
