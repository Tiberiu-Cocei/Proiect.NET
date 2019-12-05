using AutoMapper;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using SmartCity.Business.Person;
using SmartCity.Business.PointOfInterest;
using SmartCity.DataAccess;
using SmartCity.DataAccess.Repositories.Person;
using SmartCity.DataAccess.Repositories.PointOfInterest;
using SmartCity.WebApi.Mappers;
using SmartCity.WebApi.Models.Person;
using SmartCity.WebApi.Models.PointOfInterest;
using SmartCity.WebApi.Models.User;
using SmartCity.WebApi.ModelValidators.Person;
using SmartCity.WebApi.ModelValidators.PointOfInterest;
using SmartCity.WebApi.ModelValidators.User;

namespace SmartCity.WebApi
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
            //services.AddRazorPages();
            services.AddCors(options =>
            {
                options.AddPolicy(MyAllowSpecificOrigins,
                builder =>
                {
                    builder.WithOrigins("http://localhost:3000",
                                        "http://www.contoso.com")
                                    .AllowAnyHeader()
                                    .AllowAnyMethod();
                });
            });

            services.AddTransient<IValidator<CreatePersonModel>, CreatePersonModelValidation>();
            services.AddTransient<IValidator<UpdatePersonModel>, UpdatePersonModelValidator>();
            services.AddTransient<IValidator<PersonModel>, PersonModelValidator>();

            services.AddTransient<IValidator<CreatePointOfInterestModel>, CreatePointOfInterestModelValidator>();
            services.AddTransient<IValidator<UpdatePointOfInterestModel>, UpdatePointOfInterestModelValidator>();
            services.AddTransient<IValidator<PointOfInterestModel>, PointOfInterestModelValidator>();

            services.AddTransient<IValidator<UserModel>, UserModelValidatior>();

            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_3_0)
                .AddFluentValidation();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
            });

            services.AddScoped<DatabaseContext>();
            services.AddScoped<IPersonService, PersonService>();
            services.AddScoped<IPointOfInterestService, PointOfInterestService>();
            services.AddScoped<IPersonRepository, PersonRepository>();
            services.AddScoped<IPointOfInterestRepository, PointOfInterestRepository>();

            services.AddAutoMapper(typeof(AutoMapperConfig));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseCors(MyAllowSpecificOrigins);

            app.UseHttpsRedirection();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                c.RoutePrefix = string.Empty;
            });

            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
