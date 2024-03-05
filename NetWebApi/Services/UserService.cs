using AutoMapper;
using System.Threading.Tasks;
using System;
using NetWebApi.Interfaces;
using NetWebApi.Models;
using NetWebApi.Models.Entity;
using NetWebApi.Models.Response;
using Microsoft.AspNetCore.Connections;
using System.ComponentModel;
using NetWebApi.Repositories;
using NetWebApi.Helper;
using IConnectionFactory = NetWebApi.Interfaces.IConnectionFactory;

namespace NetWebApi.Services
{
    public class UserService : ServiceBase<User,GetUserResponse>
    {
        protected IConnectionFactory _connectionFactory;

        public UserService(IMapper mapper, IConnectionFactory connectionFactory) : base(mapper, connectionFactory)
        {
            _connectionFactory = connectionFactory;
            _repository = new UserRepository(connectionFactory);
        }

        public virtual async Task<ServiceResult> GetDataByName(string name)
        {
            try
            {
                var _repo = new UserRepository(_connectionFactory);
                var result = await _repo.GetDataByName(name);


                //Mapping response
                GetUserResponse response = _mapper.Map<GetUserResponse>(result);

                return new ServiceResult
                {
                    Message = "Get data successfully",
                    IsError = false,
                    Content = response,
                };
            }
            catch (Exception ex)
            {
                return new ServiceResult
                {
                    Message = ex.Message,
                    IsError = true
                };
            }
        }
    }
}
