using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using NetWebApi.Interfaces;
using NetWebApi.Models;
using NetWebApi.Models.Entity;
using NetWebApi.Models.Request;
using NetWebApi.Models.Response;
using NetWebApi.Services;

namespace NetWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : BaseController<User,CreateUserRequest,GetUserResponse>
    {
        public UserController(IServiceBase<User,GetUserResponse> service, IServiceWrapper serviceWrapper) : base(service, serviceWrapper)
        {
            _service = serviceWrapper.UserService;
        }

        [HttpGet("get_by_name")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public virtual async Task<ActionResult<ApiResponse>> GetByName([FromQuery] string name)
        {
            try
            {
                ServiceResult result = await ((UserService)_service).GetDataByName(name);
                return GenerateResult(result);
            }
            catch (Exception ex)
            {
                return GenerateException(ex);
            }
        }
    }
}
