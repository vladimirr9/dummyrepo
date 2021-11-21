using HospitalClassLib;
using HospitalClassLib.Schedule.Repository.AllergenRepository;
using HospitalClassLib.Schedule.Repository.AppointmentRepo;
using HospitalClassLib.Schedule.Repository.DoctorRepository;
using HospitalClassLib.Schedule.Repository.FeedbackRepository;
using HospitalClassLib.Schedule.Repository.PatientRepository;
using HospitalClassLib.Schedule.Repository.QuestionRepository;
using HospitalClassLib.Schedule.Repository.SurveyRepository;
using HospitalClassLib.Schedule.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
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

namespace HospitalAPI
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
            services.AddDbContext<MyDbContext>(options => options.UseNpgsql(x => x.MigrationsAssembly("HospitalAPI")));
            services.AddTransient<IAllergenRepository, AllergenRepository>();
            services.AddScoped<AllergenService>();
            services.AddScoped<AllergenRepository>();

            services.AddTransient<IDoctorRepository, DoctorRepository>();
            services.AddScoped<DoctorService>();
            services.AddScoped<DoctorRepository>();

            services.AddTransient<IPatientRepository, PatientRepository>();
            services.AddScoped<PatientService>();
            services.AddScoped<PatientRepository>();

            services.AddTransient<IFeedbackRepository, FeedbackRepository>();
            services.AddScoped<FeedbackService>();
            services.AddScoped<FeedbackRepository>();

            services.AddTransient<ISurveyRepository, SurveyRepository>();
            services.AddScoped<SurveyService>();
            services.AddScoped<SurveyRepository>();

            services.AddTransient<IQuestionRepository, QuestionRepository>();
            services.AddScoped<QuestionService>();
            services.AddScoped<QuestionRepository>();

            services.AddTransient<IAppointmentRepository, AppointmentRepository>();
            services.AddScoped<AppointmentService>();
            services.AddScoped<AppointmentRepository>();

            services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));

            services.AddMvc();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "HospitalAPI", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "HospitalAPI v1"));
            }

            app.UseRouting();
            app.UseCors("MyPolicy");
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

    }
}
