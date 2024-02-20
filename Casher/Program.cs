using Casher.Dal.EfStructures;
using Casher.Dal.Repos;
using Casher.Dal.Repos.Interfaces;
using Casher.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Casher
{
	public static class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.Configure<Config>(builder.Configuration.GetSection("Project"));

			builder.Services.AddScoped<IBankAccountRepo, BankAccountRepo>();
			builder.Services.AddScoped<IOperationTypeRepo, OperationTypeRepo>();
			builder.Services.AddScoped<IOperationRepo, OperationRepo>();
			builder.Services.AddScoped<IPinCodeAttemptRepo, PinCodeAttemptRepo>();
            builder.Services.AddScoped<DataManager>();

            builder.Services.AddDbContext<AppDbContext>((serviceProvider, options) =>
            {
                var config = serviceProvider.GetRequiredService<IOptions<Config>>().Value;
                options.UseSqlServer(config.ConnectionString);
            });

            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
				.AddCookie(opts =>
				{
					opts.LoginPath = "/Account/Login";
					opts.ExpireTimeSpan = TimeSpan.FromMinutes(20);
				});

            builder.Services.AddControllersWithViews();

			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (!app.Environment.IsDevelopment())
			{
				app.UseExceptionHandler("/Error");
			}

			app.UseHttpsRedirection();
			app.UseStaticFiles();

			app.UseRouting();
			
			app.UseAuthentication();
			app.UseAuthorization();

			app.MapAreaControllerRoute(
				name: "default",
				areaName: "User",
				pattern: "{controller=Home}/{action=Index}"
				);

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Account}/{action}");

            app.Run();
		}
	}
}
