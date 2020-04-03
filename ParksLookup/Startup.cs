using ParksLookup.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ParksLookup.Helpers;
using ParksLookup.Services;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc.Versioning;


namespace ParksLookup
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
			services.AddDbContext<ParksLookupContext>(opt =>
					opt.UseMySql(Configuration.GetConnectionString("DefaultConnection")));
			
			services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

			services.AddSwaggerDocument();
			
			services.AddCors();

			var appSettingsSection = Configuration.GetSection("AppSettings");
				services.Configure<AppSettings>(appSettingsSection);

			// configure jwt authentication
			var appSettings = appSettingsSection.Get<AppSettings>();
			var key = Encoding.ASCII.GetBytes(appSettings.Secret);
			services.AddAuthentication(x =>
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
					ValidateIssuerSigningKey = true,
					IssuerSigningKey = new SymmetricSecurityKey(key),
					ValidateIssuer = false,
					ValidateAudience = false
				};
			});

			// configure DI for application services
			services.AddScoped<IUserService, UserService>();

			// services.AddIdentity<ApplicationUser, IdentityRole>()
			//   .AddEntityFrameworkStores<ParksLookupContext>()
			//   .AddDefaultTokenProviders();

			// services.Configure<IdentityOptions>(options =>
			// {
			//   options.Password.RequireDigit = false;
			//   options.Password.RequiredLength = 0;
			//   options.Password.RequireLowercase = false;
			//   options.Password.RequireNonAlphanumeric = false;
			//   options.Password.RequireUppercase = false;
			//   options.Password.RequiredUniqueChars = 0;
			// });  

			services.AddApiVersioning(config =>
			{
					// Specify the default API Version as 1.0
					config.DefaultApiVersion = new ApiVersion(1, 0);
					// If the client hasn't specified the API version in the request, use the default API version number 
					config.AssumeDefaultVersionWhenUnspecified = true;
					config.ReportApiVersions = true;
			});      

		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}

			// global cors policy
			app.UseCors(x => x
					.AllowAnyOrigin()
					.AllowAnyMethod()
					.AllowAnyHeader());

			app.UseAuthentication();

			// Incorporate Swagger
			app.UseStaticFiles();
			app.UseOpenApi();
    	app.UseSwaggerUi3();

			app.UseMvc();
		}
	}
}