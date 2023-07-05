using Students.Data;
using Students.Data.Interfaces;
using Students.Services.AppServices.Interactors;
using Students.Services.AppServices.Interfaces;

namespace StudentsApi.Extensions
{
    public static class AddAppServicesExtension
    {
        public static WebApplicationBuilder AddAppServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddScoped<IStudentInteractor, StudentInteractor>();
            builder.Services.AddScoped<ITeacherInteractor, TeacherInteractor>();

            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            return builder;
        }
    }
}
