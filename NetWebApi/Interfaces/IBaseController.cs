using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using NetWebApi.Models;
using System.Collections.Generic;

namespace NetWebApi.Interfaces
{
    public interface IBaseController<Entity,Request, Response> where Entity : class where Request : class where Response : class
    {
        Task<ActionResult<ApiResponse>> GetAllData();

        Task<ActionResult<ApiResponse>> Post(IEnumerable<Request> entityRequest);

    }
}
