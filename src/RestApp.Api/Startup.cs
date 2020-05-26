using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using restapp.Domain.Security;
using restapp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using RestApp.Domain.Services;
using RestApp.Api.Services;
using RestApp.Data;
using RestApp.Domain.Queries.Reports;
using RestApp.Data.Queries.Reports;
using RestApp.Domain.Queries.Admin;
using RestApp.Data.Queries.Admin;

namespace restapp.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Configure CORS
            services.AddCors(options =>
            {
                options.AddPolicy(MyAllowSpecificOrigins,
                    bulder =>
                    {
                        bulder.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader();
                    });
            });

            // Identity role
            services.AddIdentity<RestAppUser, IdentityRole>(cfg =>
            {
                cfg.User.RequireUniqueEmail = true;
            })
            .AddEntityFrameworkStores<SecurityDbContext>();

            // User Admin Context
            services.AddDbContext<SecurityDbContext>(cfg =>
            {
                cfg.UseSqlServer(Configuration.GetConnectionString("AdminDBConnection"));
            });

            // kilaDbConnection Context
            services.AddDbContext<RestAppDbContext>(cfg =>
            {
                cfg.UseSqlServer(Configuration.GetConnectionString("kilaDbConnection"));
            });

            // seeder
            services.AddTransient<SecuritySeeder>();

            /** Services **/
            // reports
            services.AddScoped<IReportsQuery, ReportsQuery>();
            services.AddScoped<IReportsService, ReportsService>();

            // Admin
            services.AddScoped<IProductsQuery, ProductsQuery>();
            services.AddScoped<IAdminService, AdminService>();            

            // Auth
            services.AddScoped<IAuthService, AuthService>();

            // Auth
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options => {
                    options.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidIssuer = Configuration["Token:Issuer"],
                        ValidAudience = Configuration["Token:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Token:Key"]))
                    };
                });

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(MyAllowSpecificOrigins);

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            // seeder security db
            if (env.IsDevelopment())
            {
                using (var scope = app.ApplicationServices.CreateScope())
                {
                    var seeder = scope.ServiceProvider.GetService<SecuritySeeder>();
                    seeder.seed().Wait();
                }
            }
        }
    }
}
