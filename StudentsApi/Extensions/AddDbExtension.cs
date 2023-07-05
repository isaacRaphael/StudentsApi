using Microsoft.EntityFrameworkCore;
using Students.Data;
using System;

namespace StudentsApi.Extensions
{
    public static class AddDbExtension
    {
        public static WebApplicationBuilder AddDbConfiguration(this WebApplicationBuilder builder)
        {
           builder.Services.AddDbContext<DatabaseContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("Default")));
           return builder;
        }
    }
}
