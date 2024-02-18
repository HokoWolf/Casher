using Casher.Dal.EfStructures;
using Casher.Dal.Repos;
using Casher.Dal.Repos.Interfaces;
using Casher.Services;
using Microsoft.EntityFrameworkCore;

namespace Casher
{
	public static class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			builder.Services.Configure<Config>(builder.Configuration.GetSection("Project"));
			var config = builder.Configuration.Get<Config>();

			builder.Services.AddScoped<IBankAccountRepo, BankAccountRepo>();
			builder.Services.AddScoped<IOperationTypeRepo, OperationTypeRepo>();
			builder.Services.AddScoped<IOperationRepo, OperationRepo>();
			builder.Services.AddScoped<IPinCodeAttemptRepo, PinCodeAttemptRepo>();
			
			builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(config?.ConnectionString));

			// Add services to the container.
			builder.Services.AddControllersWithViews();

			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (!app.Environment.IsDevelopment())
			{
				app.UseExceptionHandler("/Home/Error");
				app.UseHsts();
			}

			app.UseHttpsRedirection();
			app.UseStaticFiles();

			app.UseRouting();

			app.UseAuthorization();

			app.MapControllerRoute(
				name: "default",
				pattern: "{controller=Home}/{action=Index}/{id?}");

            app.MapControllerRoute(
                name: "login",
                pattern: "{controller=Account}/{action=Login}");

            app.Run();
		}
	}
}
