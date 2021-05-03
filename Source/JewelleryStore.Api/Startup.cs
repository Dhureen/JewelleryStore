using JewelleryStore.Application;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using MediatR;
using Jewellery.DataAccess;
using JewelleryStore.EntityModel;
using Microsoft.EntityFrameworkCore;
using JewelleryStore.Infrastructure;

namespace JewelleryStore.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "JewelleryStore", Version = "v1" });
            });

            services.AddMediatR(new[] { typeof(ComputeGoldPriceQuery).Assembly});
            services.AddAutoMapper(typeof(MappingProfile));
            services.AddScoped<IUserDataAccess, UserDataAccess>();
            services.AddScoped<IUserDomainFactory, UserDomainFactory>();         
            services.AddSingleton<IApplicationContext, ApplicationContext>();
            services.AddDbContextFactory<JewelleryStoreContext>(options => options.UseSqlServer(Configuration.GetConnectionString("mssql")));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "JewelleryStore v1"));
            }

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
