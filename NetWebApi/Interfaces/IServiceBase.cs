using System.Threading.Tasks;
using NetWebApi.Models;

namespace NetWebApi.Interfaces
{
    public interface IServiceBase<Entity,Response> where Entity : class where Response : class
    {
        Task<ServiceResult> GetAllData();
        Task<ServiceResult> Post(dynamic entityRequest);
    }
}
