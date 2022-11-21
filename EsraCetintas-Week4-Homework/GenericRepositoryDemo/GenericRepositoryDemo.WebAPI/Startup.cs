using GenericRepositoryDemo.Business.Abstract;
using GenericRepositoryDemo.Business.Concrete;
using GenericRepositoryDemo.Business.MappingProfile;
using GenericRepositoryDemo.Data.Abstract;
using GenericRepositoryDemo.Data.Concrete.Dapper;
using GenericRepositoryDemo.Data.Concrete.EntityFramework;
using GenericRepositoryDemo.Data.Context;
using GenericRepositoryDemo.WebAPI.Middlewares;
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

namespace GenericRepositoryDemo.WebAPI
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

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "GenericRepositoryDemo.WebAPI", Version = "v1" });
            });
            //services.AddDbContext<AppDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("Connection")));
            services.AddDbContext<AppDbContext>();
            //services.AddTransient(typeof(IRepository<>), RepositoryBase<>);
            services.AddTransient<IOrderService, OrderService>();
            services.AddAutoMapper(typeof(OrderProfile));
            //services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddTransient<IOrderDal, DapperOrderDal>();
            //services.AddTransient<IOrderDal, EfOrderDal>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "GenericRepositoryDemo.WebAPI v1"));
            }

            app.UseLogMiddleware();
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
