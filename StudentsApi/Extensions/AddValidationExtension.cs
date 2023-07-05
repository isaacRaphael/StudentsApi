using FluentValidation.AspNetCore;
using FluentValidation;
using StudentsApi.Validators;

namespace StudentsApi.Extensions
{
    public static class AddValidationExtension
    {
        public static WebApplicationBuilder AddValidation(this WebApplicationBuilder builder)
        {
            builder.Services.AddFluentValidationAutoValidation();
            builder.Services.AddFluentValidationClientsideAdapters();
            builder.Services.AddValidatorsFromAssemblyContaining<AddStudentDtoValidator>();
            builder.Services.AddValidatorsFromAssemblyContaining<AddTeacherDtoValidator>();

            return builder;
        }
    }
}
