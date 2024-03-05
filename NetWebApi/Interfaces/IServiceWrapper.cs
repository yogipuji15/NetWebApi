using NetWebApi.Services;

namespace NetWebApi.Interfaces
{
    public interface IServiceWrapper
    {
        IConnectionFactory ConnectionFactory { get; }
        UserService UserService { get; }
    }
}
