using System.Collections.Generic;
using System.Threading.Tasks;

namespace NetWebApi.Interfaces
{
    public interface IRepositoryBase<Entity> where Entity : class
    {
        Task<IEnumerable<Entity>> GetAllData();
        Task<dynamic> Create(IEnumerable<Entity> entity);
    }
}
