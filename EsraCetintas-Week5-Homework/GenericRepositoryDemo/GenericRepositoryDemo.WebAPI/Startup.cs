using GenericRepositoryDemo.Business.Abstract;
using GenericRepositoryDemo.Business.Concrete;
using GenericRepositoryDemo.Business.HttpClients;
using GenericRepositoryDemo.Core.Caching;
using GenericRepositoryDemo.Core.Caching.InMemoryCache;
using GenericRepositoryDemo.Core.Configurations;
using GenericRepositoryDemo.Data.Abstract;
using GenericRepositoryDemo.Data.Concrete.EntityFramework;
using GenericRepositoryDemo.Data.Context;
using Hangfire;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

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

            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("Connection")));
            services.AddScoped(typeof(IRepository<>), typeof(RepositoryBase<>));
            services.AddScoped<IUserService, UserService>();
            //Hangfire
            services.AddHangfire(x => x.UseSqlServerStorage(Configuration.GetConnectionString("Connection")));
            services.AddHangfireServer();
            //Caching
            services.AddMemoryCache();
            services.AddScoped<ICacheService, MemoryCache>();
            services.Configure<CacheConfiguration>(Configuration.GetSection("Caching"));

            services.AddHttpClient();
            services.AddScoped<UserClient>();
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

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.UseHangfireDashboard("/jobs");
        }
    }
}
