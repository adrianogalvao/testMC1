using System.Linq;
using System.Threading.Tasks;
using WebApi.Models;

namespace WebApi.Repositories.Interfaces
{
    public interface IProdutoService
    {
        Task<Produto> Post(Produto produto);

        Task<Produto> Put(Produto produto);

        Produto Get(int Id);

        IOrderedQueryable<Produto> GetAll();

        Task<bool> Delete(int Id);
    }
}