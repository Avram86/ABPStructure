
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Structure.API.Models;
using Structure.Application;
using Structure.Application.Consultatii;
using Structure.Application.Patients;
using Structure.Application.ResourceAppointments;
using Structure.Application.Resources;
using Structure.Domain;
using Structure.Domain.Consultatii;
using Structure.Domain.Consultatii.Dto;
using Structure.Domain.LabelObjects;
using Structure.Domain.LabelObjects.Dto;
using Structure.Domain.Patients;
using Structure.Domain.Patients.Dto;
using Structure.Domain.Resource.Dto;
using Structure.Domain.ResourceAppointments;
using Structure.Domain.ResourceAppointments.Dto;
using Structure.Domain.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Structure.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        private const string DefaultCorsPolicyName = "Default";
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //The configuration instance to which the appsettings.json file's BookstoreDatabaseSettings section binds is registered in the Dependency Injection (DI) container.
            //For example, a BookstoreDatabaseSettings object's ConnectionString property is populated with the BookstoreDatabaseSettings:ConnectionString property in appsettings.json.
            services.Configure<DataBaseSettings>(Configuration.GetSection(nameof(DataBaseSettings)));

            //The IBookstoreDatabaseSettings interface is registered in DI with a singleton service lifetime.
            //When injected, the interface instance resolves to a BookstoreDatabaseSettings object.
            services.AddSingleton<IDataBaseSettings>(sp=>sp.GetRequiredService<IOptions<DataBaseSettings>>().Value);


            //adding services to DI
            
            services.AddScoped<IConsultatieAppService, ConsultatieAppService>();
            services.AddScoped<IConsultatiiforchartAppService, ConsultatiiforchartAppService>();
            services.AddScoped<IConsultatiWithCodAppService, ConsultatiWithCodAppService>();

            services.AddScoped<ILabelObjectAppService, LabelObjectAppService>();

            services.AddScoped<IPatientAppService, PatientAppService>();
            services.AddScoped<IPatientIdsAppService, PatientIdsAppService>();
            services.AddScoped<IPatientsForChartsAppService, PatientsForChartsAppService>();
            services.AddScoped<IPatientSexAppService, PatientSexAppService>();

            services.AddScoped<IResourceAppointmentAppService, ResourceAppointmentAppService>();

            services.AddScoped<IResourceAppService, ResourceAppService>();


            services.AddScoped<IConsultatieRepository,ConsultatiiRepository>();
            services.AddScoped<ILabelObjectRepository, LabelObjectRepository>();
            services.AddScoped<IPatientRepository, PatientRepository>();
            services.AddScoped<IResourceAppointmentRepository, ResourceAppointmentRepository>();
            services.AddScoped<IResourceRepository, ResourceRepository>();


            //adding the ProfileMappingFile to the configuration of AutoMapper
            var config = new AutoMapper.MapperConfiguration(cfg=>
            {
                cfg.AddProfile(new AutoMapperProfile());
            });
            var mapper = config.CreateMapper();
            services.AddSingleton(mapper);
            


            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Structure.API", Version = "v1" });
            });

            services.AddCors(options=>
            {
                options.AddPolicy(DefaultCorsPolicyName, builder =>
                {
                    builder
                        .AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors(DefaultCorsPolicyName);
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Structure.API v1"));
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
