public static class OpenApiSetup
{
    public static void AddOpenApiSetup(this WebApplicationBuilder builder)
    {
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new()
            {
                Title = builder.Environment.ApplicationName,
                Version = "v1",
                Contact = new()
                {
                    Name = "An Author",
                    Email = "author@me.com"
                },
                Description = "Here's a Swagger description"
            });
        });
    }

    public static void ConfigureOpenApiForDevelopmentEnvironment(this WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
    }
}