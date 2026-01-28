using Pustok.Business.ServiceRegistrations;

using Pustok.DataAccess.ServiceRegistrations;
using Pustok.Presentation.Middlewares;
namespace Pustok.Presentation;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        builder.Services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
        {
            //builder.WithOrigins("http://127.0.0.1:5500", "http://localhost:5500")
            builder.AllowAnyOrigin()
            .AllowAnyMethod()
                   .AllowAnyHeader();
        }));
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        //builder.Services.AddScoped<IEmployeeService, EmployeeService>();
        builder.Services.AddBusinessServices();
        builder.Services.AddDataAccessServices(builder.Configuration);
        var app = builder.Build();
        app.UseMiddleware<GlobalExceptionHandler>();

        app.UseCors("MyPolicy");
        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}
