using System.Linq;
using System.Threading.Tasks;
using WebApi.Models;

namespace WebApi.Repositories.Interfaces
{
    public interface IProdutoRepository
    {
        Task<bool> Post(Produto produto);

        Task<bool> Put(Produto produto);

        Produto Get(int Id);

        IOrderedQueryable<Produto> GetAll();        

        Task<bool> Delete(int Id);
    }
}
