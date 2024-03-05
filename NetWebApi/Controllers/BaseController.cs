using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System;
using System.Threading.Tasks;
using NetWebApi.Interfaces;
using NetWebApi.Models;

namespace NetWebApi.Controllers
{
    [ApiController]
    public class BaseController<Entity, Request, Response> : ControllerBase, IBaseController<Entity,Request, Response> where Entity : class where Request : class where Response : class
    {
        protected IServiceBase<Entity,Response> _service;
        protected readonly IServiceWrapper Service;
        public BaseController(IServiceBase<Entity,Response> service, IServiceWrapper serviceWrapper)
        {
            _service = service;
            Service = serviceWrapper;
        }

        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public virtual async Task<ActionResult<ApiResponse>> GetAllData()
        {
            try
            {
                ServiceResult result = await _service.GetAllData();
                return GenerateResult(result);
            }
            catch (Exception ex)
            {
                return GenerateException(ex);
            }
        }

        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public virtual async Task<ActionResult<ApiResponse>> Post([FromBody] Request entityRequest)
        {
            try
            {
                ServiceResult result = await _service.Post(entityRequest);
                return GenerateResult(result);
            }
            catch (Exception ex)
            {
                return GenerateException(ex);
            }
        }

        protected ApiResponse GenerateResult(ServiceResult serviceResult)
        {
            ApiResponse result = new ApiResponse();

            if (serviceResult.IsError)
            {
                result.Title = "Error";
                result.StatusCode = (int)HttpStatusCode.BadRequest;
                result.Result = serviceResult;
            }
            else
            {
                result.Title = "Success";
                result.StatusCode = (int)HttpStatusCode.OK;
                result.Result = serviceResult;
            }

            return result;
        }

        protected ApiResponse GenerateException(Exception ex)
        {
            ApiResponse result = new ApiResponse()
            {
                Title = "Error",
                StatusCode = (int)HttpStatusCode.BadRequest,
                Result = new ServiceResult()
                {
                    IsError = true,
                    Message = ex.Message
                }
            };

            return result;
        }

        
    }
}
