using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NetWebApi.Helper;
using NetWebApi.Interfaces;
using NetWebApi.Models.Entity;

namespace NetWebApi.Repositories
{
    public class RepositoryBase<Entity> : IRepositoryBase<Entity> where Entity : class
    {
        //protected readonly DBConnection _dbConnection;
        protected readonly DBConnection _database;
        protected readonly IConnectionFactory _connectionFactory;


        public RepositoryBase(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
            _database = connectionFactory.GetDatabase();
        }

        public virtual async Task<IEnumerable<Entity>> GetAllData()
        {
            return await _database.Set<Entity>().ToListAsync();
            //return await _dbConnection.Set<Entity>().ToListAsync();

            //string tableName = _dbConnection.Model.FindEntityType(typeof(Entity)).GetTableName();
            //Console.WriteLine(tableName);
            //return await _dbConnection.Set<Entity>().FromSqlRaw($"SELECT * FROM {tableName}").ToListAsync();
        }

        public virtual async Task<dynamic> Create(IEnumerable<Entity>  entity)
        {
            //await _dbConnection.Set<T>().AddAsync(entity);
            //await _dbConnection.SaveChangesAsync();

            await _database.Set<Entity>().AddRangeAsync(entity);
            await _database.SaveChangesAsync();

            return null;


            //string tableName = _dbConnection.Model.FindEntityType(typeof(Entity)).GetTableName();
            //var properties = typeof(Entity).GetProperties();
            //var columnNames = new List<string>();
            //var columnValues = new List<string>();

            //foreach (var property in properties)
            //{
            //    if (property.Name == "Id")
            //    {
            //        continue;
            //    }
            //    columnNames.Add(property.Name);
                

            //    var value = property.GetValue(entity);
            //    columnValues.Add(value != null ? $"'{value}'" : "NULL");
            //}

            //string insertSql = $"INSERT INTO {tableName} ({string.Join(", ", columnNames)}) " +
            //                   $"VALUES ({string.Join(", ", columnValues)});";

            //Console.WriteLine(insertSql);

            //await _dbConnection.Database.ExecuteSqlRawAsync(insertSql);



            //return null;
        }
    }
}
