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
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using JewelleryStore.Model;
using Microsoft.IdentityModel.Tokens;
using System.Text;

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
            services.AddCors();
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
            services.AddSingleton<IAuthenticationTokenProvider, AuthenticationTokenProvider>();
            services.AddSingleton<IAuthenticationTokenGenerator, AuthenticationTokenGenerator>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddDbContextFactory<JewelleryStoreContext>(options => options.UseSqlServer(Configuration.GetConnectionString("mssql")));
            services.Configure<AuthSettings>(Configuration.GetSection("AuthSettings"));
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options => {
                    options.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["AuthSettings:Secret"])),
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ValidateLifetime = true,
                        SaveSigninToken = true
                    };
                });
                ;
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "JewelleryStore v1"));
            }

            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
