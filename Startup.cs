using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TFG_Back.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using TFG_Back.Auth;

namespace TFG_Back
{
    public class Startup
    {
        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var key = "This is the demo key";

            services
               .AddAuthentication(x =>
               {
                   x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                   x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
               })
               .AddJwtBearer(x =>
               {
                   x.RequireHttpsMetadata = false;
                   x.SaveToken = true;
                   x.TokenValidationParameters = new TokenValidationParameters
                   {
                       IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(key)),
                       ValidateAudience = false,
                       ValidateIssuerSigningKey = true,
                       ValidateIssuer = false
                   };
               });

            services.AddAuthorization();
            services.AddAutoMapper(typeof(Startup));
            services.AddMvc();
            services.AddSingleton<IJwtAuthenticationService>(new JwtAuthenticationService(key));
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "TFG_Back", Version = "v1" });
            });

            services.AddCors(options =>
            {
                options.AddPolicy(name: MyAllowSpecificOrigins,
                                  builder =>
                                  {
                                      builder.WithOrigins("http://localhost:8100", "http://localhost:4200").AllowAnyHeader()
                                                  .AllowAnyMethod();
                                  });
            });

            services.AddControllers().AddNewtonsoftJson(options =>
               options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );


            services.AddDbContext<TFG_BackContext>(options =>
                        options.UseNpgsql(Configuration.GetConnectionString("TFG_BackContext")));
            }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "TFG_Back v1"));
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();

            app.UseRouting();

            app.UseCors(MyAllowSpecificOrigins);

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
