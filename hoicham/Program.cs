using hoicham.Infrastructure.AppDbContext;
using Microsoft.EntityFrameworkCore;

public class Program
{
	public static void Main(string[] args)
	{
		var builder = WebApplication.CreateBuilder(args);
		builder.Services.AddDbContext<AppDbContext>(options =>
			options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
		// Add services to the container.
		builder.Services.AddControllers();
		builder.Services.AddControllersWithViews();
		builder.Services.AddEndpointsApiExplorer();
		builder.Services.AddSwaggerGen();

		var app = builder.Build();

		// Configure the HTTP request pipeline.
		if (app.Environment.IsDevelopment())
		{
			// Enable Swagger UI in development
			app.UseSwagger();
			app.UseSwaggerUI(c =>
			{
				c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
			});
		}
		else
		{
			app.UseHsts();
		}

		app.UseHttpsRedirection();
		app.UseStaticFiles();
		app.UseRouting();


		app.MapControllerRoute(
			name: "default",
			pattern: "{controller}/{action=Index}/{id?}");

		app.MapFallbackToFile("index.html"); ;

		app.Run();
	}
}