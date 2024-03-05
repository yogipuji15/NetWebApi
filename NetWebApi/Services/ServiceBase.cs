using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NetWebApi.Interfaces;
using NetWebApi.Models;
using IConnectionFactory = NetWebApi.Interfaces.IConnectionFactory;

namespace NetWebApi.Services
{
    public class ServiceBase<Entity,Response> : IServiceBase<Entity, Response> where Entity : class where Response : class
    {
        protected IRepositoryBase<Entity> _repository;
        protected IMapper _mapper;
        public ServiceBase(IMapper mapper, IConnectionFactory connectionFactory)
        {
            _mapper = mapper;
        }
        public virtual async Task<ServiceResult> GetAllData()
        {
            try
            {
                var result = await _repository.GetAllData();

                //Mapping response
                IEnumerable<Response> response = _mapper.Map<IEnumerable<Response>>(result);

                return new ServiceResult
                {
                    Message = "Get data successfully",
                    IsError = false,
                    Content = response
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

        public virtual async Task<ServiceResult> Post(dynamic entityRequest)
        {
            Entity entity = _mapper.Map<Entity>(entityRequest);

            try
            {
                var result = await _repository.Create(entity);

                return new ServiceResult
                {
                    Message = "Data created successfully",
                    IsError = false,
                    Content = result
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
