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
using SmartCity.Business.Bus;
using SmartCity.Business.City;
using SmartCity.Business.Person;
using SmartCity.Business.PointOfInterest;
using SmartCity.DataAccess;
using SmartCity.DataAccess.Repositories.Bus;
using SmartCity.DataAccess.Repositories.City;
using SmartCity.DataAccess.Repositories.Person;
using SmartCity.DataAccess.Repositories.PointOfInterest;
using SmartCity.WebApi.Mappers;
using SmartCity.WebApi.Models.Bus;
using SmartCity.WebApi.Models.BusRoute;
using SmartCity.WebApi.Models.BusStation;
using SmartCity.WebApi.Models.City;
using SmartCity.WebApi.Models.Coordinates;
using SmartCity.WebApi.Models.Person;
using SmartCity.WebApi.Models.PointOfInterest;
using SmartCity.WebApi.Models.User;
using SmartCity.WebApi.ModelValidators.Bus;
using SmartCity.WebApi.ModelValidators.BusRoute;
using SmartCity.WebApi.ModelValidators.BusStation;
using SmartCity.WebApi.ModelValidators.City;
using SmartCity.WebApi.ModelValidators.Coordinates;
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

            services.AddTransient<IValidator<BusModel>, BusModelValidator>();
            services.AddTransient<IValidator<CreateBusModel>, CreateBusModelValidator>();
            services.AddTransient<IValidator<UpdateBusModel>, UpdateBusModelValidator>();

            services.AddTransient<IValidator<BusRouteModel>, BusRouteModelValidator>();
            services.AddTransient<IValidator<CreateBusRouteModel>, CreateBusRouteModelValidator>();
            services.AddTransient<IValidator<UpdateBusRouteModel>, UpdateBusRouteModelValidator>();

            services.AddTransient<IValidator<BusStationModel>, BusStationModelValidator>();
            services.AddTransient<IValidator<CreateBusStationModel>, CreateBusStationModelValidator>();
            services.AddTransient<IValidator<UpdateBusStationModel>, UpdateBusStationModelValidator>();

            services.AddTransient<IValidator<CityModel>, CityModelValidator>();
            services.AddTransient<IValidator<CreateCityModel>, CreateCityModelValidator>();
            services.AddTransient<IValidator<UpdateCityModel>, UpdateCityModelValidator>();

            services.AddTransient<IValidator<CoordinatesModel>, CoordinatesModelValidator>();

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
            services.AddScoped<ICityService, CityService>();
            services.AddScoped<IBusService, BusService>();

            services.AddScoped<IPersonRepository, PersonRepository>();
            services.AddScoped<IPointOfInterestRepository, PointOfInterestRepository>();
            services.AddScoped<ICityRepository, CityRepository>();
            services.AddScoped<IBusRepository, BusRepository>();

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
