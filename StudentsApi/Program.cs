
using FluentValidation;
using FluentValidation.AspNetCore;
using StudentsApi.Extensions;
using StudentsApi.Validators;

namespace StudentsApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.AddValidation();
            builder.AddDbConfiguration();
            builder.AddAppServices();

            var origiName = "myAllowedOrigin";
            builder.AddCorsConfig(origiName);

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            
            app.UseSwagger();
            app.UseSwaggerUI();
            app.UseCors(origiName);
            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}