using Autofac;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using IdeVerseContracts;
using IdeVerseContracts.UserManager;
using RBCAcademyCore;
using RBCAcademyDb;

namespace RBCAcademy
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
			ConfigurationManager = new ConfigurationManager(configuration);
		}

		public IConfiguration Configuration { get; }
		public IConfigurationManager ConfigurationManager { get; set; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddControllersWithViews();
			services.AddCors();
			services.AddHttpContextAccessor();
			services.AddTransient<IUserIdProvider, UserIdProvider>();

			services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
			{
				options.TokenValidationParameters = new TokenValidationParameters
				{
					ValidateIssuer = true,
					ValidateAudience = true,
					ValidateLifetime = true,
					ValidateIssuerSigningKey = true,
					ValidIssuer = ConfigurationManager.JwtIssuer,
					NameClaimType = ClaimsIdentity.DefaultNameClaimType,
					RoleClaimType = ClaimsIdentity.DefaultRoleClaimType,
					ValidAudience = ConfigurationManager.JwtIssuer,
					IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(ConfigurationManager.JwtKey))
				};
			});

			services.AddAuthorization(auth =>
			{
				auth
				.AddPolicy(
					ConfigurationManager.DefaultAuthPolicy,
					new AuthorizationPolicyBuilder()
						.AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme‌​)
						.RequireAuthenticatedUser()
						.Build()
				);
			});
			// In production, the Angular files will be served from this directory
			services.AddSpaStaticFiles(configuration =>
			{
				configuration.RootPath = "..//RBCFrontend//dist";
			});
			services.AddDbContext<MainContext>(options => options.UseNpgsql(ConfigurationManager.DefaultDbConnection, x => x.MigrationsAssembly("IDEVerse")));
		}

		// ConfigureContainer is where you can register things directly
		// with Autofac. This runs after ConfigureServices so the things
		// here will override registrations made in ConfigureServices.
		// Don't build the container; that gets done for you by the factory.
		public void ConfigureContainer(ContainerBuilder containerBuilder)
		{
			// Получаем Id пользователя со стороны ASP.NET 
			containerBuilder.Register<IUserIdProvider>((context) =>
			{
				var httpContext = context.Resolve<IHttpContextAccessor>();
				var user = httpContext.HttpContext?.User;
				if (user == null)
					return null;
				var claim = user.Claims.FirstOrDefault(x => x.Type == ClaimsIdentity.DefaultNameClaimType);
				var userId = Guid.Empty;
				if (claim != null)
				{
					if (!Guid.TryParse(claim.Value, out userId))
						userId = Guid.Empty;
				}
				return new UserIdProvider(userId);
			});
			// Register your own things directly with Autofac, like:
			containerBuilder.RegisterInstance(ConfigurationManager).SingleInstance().As<IConfigurationManager>();
			containerBuilder.RegisterModule(new CoreModuleLibrary());

			
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

			app.UseHttpsRedirection();
			app.UseStaticFiles();
			app.UseCors();
			app.UseAuthentication();

			if (!env.IsDevelopment())
			{
				app.UseSpaStaticFiles();
			}

			app.UseRouting();
			app.UseAuthorization();
			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllerRoute(
					name: "default",
					pattern: "{controller}/{action=Index}/{id?}");
			});

			app.UseSpa(spa =>
			{
				// To learn more about options for serving an Angular SPA from ASP.NET Core,
				// see https://go.microsoft.com/fwlink/?linkid=864501

				spa.Options.SourcePath = "..\\RBCFrontend";
				
				if (env.IsDevelopment())
				{
					spa.Options.StartupTimeout = TimeSpan.FromSeconds(5);
					spa.UseProxyToSpaDevelopmentServer("http://localhost:4200/");
				}
			});

		


		}

	}
}
