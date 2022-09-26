using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using MileStone.Context;
using MileStone.Models;
using MileStone.Services.BeneficiariesandStakeholdersServices;
using MileStone.Services.ProjectServices;
using MileStone.Services.BusinessCaseServices;
using MileStone.Services.BusinessCaseWithProjectsServices;
using MileStone.Services.RisksServices;
using MileStone.Services.CommentServices;
using MileStone.Services.ProjectCashFlowServices;
using MileStone.Services.SectorsServices;
using MileStone.Services.DepartmentServices;

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using MileStone.Services.AttachmentServices;
using MileStone.Services.ProjectCharterServices;
using MileStone.Services.StrategicObjectivesServices;
using MileStone.Services.ProjectRolesAndResourcesServices;
using MileStone.Services.ProjectManagementPlanServices;
using MileStone.Services.BenefitRealizationPlanServices;
using MileStone.Services.CommunicationPlanServices;
using MileStone.Services.ImplementationTimelineServices;
using MileStone.Services.LimitationsAndAssumptionsServices;
using MileStone.Services.ProjectOutputsAndCostServices;
using MileStone.Services.ResourceAndCadreManagementServices;

namespace MileStone
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

            services.AddControllers().AddNewtonsoftJson(options => {
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            });

            /*services.AddDbContext<DBContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DBConnection")));*/
            services.AddDbContext<DBContext>(options =>
             options.UseNpgsql(Configuration.GetConnectionString("DBConnection")));

            

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "MileStone", Version = "v1" });
            });
            services.AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<DBContext>();
            services.AddAuthentication(e => {
                e.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;

                e.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                e.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(e =>
            {
                e.SaveToken = true;
                e.RequireHttpsMetadata = false;
                e.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
                {

                    ValidateIssuer = true,
                    ValidIssuer = Configuration["JWT:ValidIssuer"],
                    ValidateAudience = true,
                    ValidAudience = Configuration["JWT:ValidAudience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JWT:SecretKey"]))
                };
            });
            services.AddScoped<IProjectServicecs, ProjectService>();
            services.AddScoped<IBeneficiariesandStakeholdersService, BeneficiariesandStakeholdersService>();
            services.AddScoped<IBusinessCaseService, BusinessCaseService>();
            services.AddScoped<ICommentService, CommentService>();
            services.AddScoped<IBusinessCaseWithProjectsService, BusinessCaseWithProjectsService>();
            services.AddScoped<IRisksService, RiskService>();
            services.AddScoped<ISectorsService, SectorsService>();
            services.AddScoped<IDepartmentService, DepartmentService>();
            services.AddScoped<IProjectCashFlowService, ProjectCashFlowService>();
            services.AddScoped<IAttachmentService, AttachmentService>();
            services.AddScoped<IProjectCharterService, ProjectCharterService>();
            services.AddScoped<IStrategicObjectivesService, StrategicObjectivesService>();
            services.AddScoped<IProjectRolesAndResourcesService, ProjectRolesAndResourcesService>();
            services.AddScoped<IProjectManagementPlanService , ProjectManagementPlanService>();
            services.AddScoped<IBenefitRealizationPlanService, BenefitRealizationPlanService>();
            services.AddScoped<ICommunicationPlanService, CommunicationPlanService>();
            services.AddScoped<IImplementationTimelineService, ImplementationTimelineService>();
            services.AddScoped<ILimitationsAndAssumptionsService, LimitationsAndAssumptionsService>();
            services.AddScoped<IProjectOutputsAndCostService, ProjectOutputsAndCostService>();
            services.AddScoped<IResourceAndCadreManagementService, ResourceAndCadreManagementService>();
            services.AddSwaggerGen(setup =>
            {
                // Include 'SecurityScheme' to use JWT Authentication
                var jwtSecurityScheme = new OpenApiSecurityScheme
                {
                    Scheme = "bearer",
                    BearerFormat = "JWT",
                    Name = "JWT Authentication",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Description = "Put **_ONLY_** your JWT Bearer token on textbox below!",

                    Reference = new OpenApiReference
                    {
                        Id = JwtBearerDefaults.AuthenticationScheme,
                        Type = ReferenceType.SecurityScheme
                    }
                };

                setup.AddSecurityDefinition(jwtSecurityScheme.Reference.Id, jwtSecurityScheme);

                setup.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        { jwtSecurityScheme, Array.Empty<string>() }
    });

            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MileStone v1"));
            }
            app.UseAuthentication();
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
