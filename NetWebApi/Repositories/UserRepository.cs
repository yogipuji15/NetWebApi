using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using NetWebApi.Helper;
using NetWebApi.Models.Entity;
using NetWebApi.Interfaces;

namespace NetWebApi.Repositories
{
    public class UserRepository : RepositoryBase<User>
    {

        public UserRepository(IConnectionFactory connectionFactory) : base(connectionFactory) 
        { 
            
        }

        public virtual async Task<User> GetDataByName(string name)
        {
            //return await _dbConnection.Set<T>().ToListAsync();

            return await _database.Users.FirstAsync(x => x.Name == name);

            //string tableName = _dbConnection.Model.FindEntityType(typeof(Entity)).GetTableName();
            //Console.WriteLine(tableName);
            //return await _dbConnection.Set<Entity>().FromSqlRaw($"SELECT * FROM {tableName}").ToListAsync();
        }
    }
}
