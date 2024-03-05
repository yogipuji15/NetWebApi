using Microsoft.EntityFrameworkCore.Infrastructure;
using NetWebApi.Helper;

namespace NetWebApi.Interfaces
{
    public interface IConnectionFactory
    {
        DBConnection GetDatabase();
    }
}
