using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Models;
using WebApi.Repositories.Interfaces;

namespace WebApi.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository _repository;

        public ProdutoService(IProdutoRepository repository)
        {
            _repository = repository;
        }

        public async Task<Produto> Post(Produto produto)
        {            
            var success = await _repository.Post(produto);

            if (success)
                return produto;
            else
                return null;
        }

        public async Task<Produto> Put(Produto produto)
        {
            var success = await _repository.Put(produto);

            if (success)
                return produto;
            else
                return null;
        }

        public Produto Get(int Id)
        {
            var result = _repository.Get(Id);

            return result;
        }

        public IOrderedQueryable<Produto> GetAll()
        {
            var result = _repository.GetAll();

            return result;
        }

        public async Task<bool> Delete(int Id)
        {
            var success = await _repository.Delete(Id);

            return success;
        }
    }
}
