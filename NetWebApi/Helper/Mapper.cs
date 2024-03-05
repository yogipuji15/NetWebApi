using AutoMapper;
using NetWebApi.Models.Entity;
using NetWebApi.Models.Request;
using NetWebApi.Models.Response;

namespace NetWebApi.Helper
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<User, CreateUserRequest>();
            CreateMap<CreateUserRequest, User>();
            CreateMap<GetUserResponse, User>();
            CreateMap<User, GetUserResponse>();
        }
    }
}
