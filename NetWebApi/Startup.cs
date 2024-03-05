using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NetWebApi.Controllers;
using NetWebApi.Helper;
using NetWebApi.Interfaces;
using NetWebApi.Models.Entity;
using NetWebApi.Models.Request;
using NetWebApi.Models.Response;
using NetWebApi.Repositories;
using NetWebApi.Services;

namespace NetWebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddDbContext<DBConnection>(opt => opt.UseInMemoryDatabase("InMem"));
            //services.AddDbContext<DBConnection>(opt => opt.UseSqlite(Configuration.GetConnectionString("WebApiDatabase")));

            services.AddDbContext<DBConnection>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddScoped<IRepositoryBase<User>, UserRepository>();
            services.AddScoped<IServiceBase<User, GetUserResponse>, UserService>();
            services.AddScoped<IBaseController<User, CreateUserRequest, GetUserResponse>, UserController>();

            //services.AddAutoMapper(typeof(Startup));

            services.AddScoped<IConnectionFactory, ConnectionFactory>();

            services.AddTransient<IServiceWrapper, ServiceWrapper>();

            services.AddControllers();

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebApi", Version = "v1" });
            });
        }



        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebApi v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            PrepDB.PrepPopulation(app);
        }
    }
}
