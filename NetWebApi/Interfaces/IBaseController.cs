using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using NetWebApi.Models;

namespace NetWebApi.Interfaces
{
    public interface IBaseController<Entity,Request, Response> where Entity : class where Request : class where Response : class
    {
        Task<ActionResult<ApiResponse>> GetAllData();

        Task<ActionResult<ApiResponse>> Post(Request entityRequest);

    }
}
