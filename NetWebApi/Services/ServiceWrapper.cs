using AutoMapper;
using NetWebApi.Interfaces;

namespace NetWebApi.Services
{
    public class ServiceWrapper : IServiceWrapper
    {
        private IConnectionFactory _connectionFactory;
        private IMapper _mapper;
        public ServiceWrapper(IMapper mapper, IConnectionFactory connectionFactory) { 
            _mapper = mapper;
            _connectionFactory = connectionFactory;
        }

        public IConnectionFactory ConnectionFactory
        {
            get
            {
                return _connectionFactory;
            }
        }

        public IMapper Mapper
        {
            get
            {
                return _mapper;
            }
        }

        //public UserService UserService => throw new System.NotImplementedException();
        public UserService UserService => new UserService(_mapper,_connectionFactory);
    }
}
