namespace StudentsApi.Extensions
{
    public static class AddCorsExtension
    {
        public static WebApplicationBuilder AddCorsConfig(this WebApplicationBuilder builder, string originName)
        {

            // cors

            builder.Services.AddCors(options =>
            {
                options.AddPolicy(
                    originName, policy =>
                    {
                        policy.AllowAnyOrigin();
                        policy.AllowAnyHeader();
                        policy.AllowAnyMethod();
                    });
            });

            return builder;

        }
    }
}
