using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Data;
using WebApi.Models;
using WebApi.Repositories.Interfaces;

namespace WebApi.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly IServiceScope _scope;
        private readonly ApiContext _produtoContext;

        public ProdutoRepository(IServiceProvider services)
        {
            _scope = services.CreateScope();

            _produtoContext = _scope.ServiceProvider.GetRequiredService<ApiContext>();
        }

        public async Task<bool> Post(Produto produto)
        {
            var success = false;

            _produtoContext.Produtos.Add(produto);

            var ItemsCreated = await _produtoContext.SaveChangesAsync();

            if (ItemsCreated == 1)
                success = true;

            return success;
        }

        public async Task<bool> Put(Produto produto)
        {
            var success = false;

            var existingProduto = Get(produto.sku);

            if (existingProduto != null)
            {
                existingProduto.sku = produto.sku;
                existingProduto.name = produto.name;
                existingProduto.inventory = produto.inventory;
                existingProduto.isMarketable = produto.isMarketable;

                _produtoContext.Produtos.Attach(existingProduto);

                var ItemsUpdated = await _produtoContext.SaveChangesAsync();

                if (ItemsUpdated >= 1)
                    success = true;
            }

            return success;
        }

        public Produto Get(int Id)
        {
            var result = _produtoContext.Produtos
                                .Where(x => x.sku == Id)
                                .FirstOrDefault();

            foreach (var arm in result.inventory.warehouses)
            {
                result.inventory.quantity += arm.quantity;
            }

            result.isMarketable = (result.inventory.quantity > 0);

            return result;
        }

        public IOrderedQueryable<Produto> GetAll()
        {
            var result = _produtoContext.Produtos
                                .OrderByDescending(x => x.sku);

            return result;
        }

        public async Task<bool> Delete(int Id)
        {
            var success = false;

            var existingProduto = Get(Id);

            if (existingProduto != null)
            {
                _produtoContext.Produtos.Remove(existingProduto);

                var ItemsDeleted = await _produtoContext.SaveChangesAsync();

                if (ItemsDeleted >= 1)
                    success = true;
            }

            return success;
        }
    }
}
