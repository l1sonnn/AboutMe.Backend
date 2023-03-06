using AboutMe.Backend.Infrastructure.Repositories.SkillTries;
using AboutMe.Backend.Infrastructure.Services;
using Microsoft.AspNetCore.Cors.Infrastructure;

namespace AboutMe.Backend.Infrastructure.Extensions
{
    internal static class ApplicationExtension
    {
        internal static void RegisterBuilder(this WebApplicationBuilder builder)
        {
            #region Grpc protocol
            builder.Services.AddGrpc();
            builder.Services.AddGrpcReflection(); 
            #endregion

            #region AutoMapper
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            #endregion

            #region Database
            builder.AddMongoDbContext();
            #endregion

            #region Swagger
            builder.Services.AddSwaggerGen();
            #endregion

            #region JWT
            builder.AddJwtBearerAuth();
            #endregion

            builder.Services.AddScoped<ISkillTriesRepository, SkillTriesRepository>();
        }

        internal static void RegisterApplication(this WebApplication app)
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseStatusCodePages();
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();
            app.UseAuthentication();
            app.MapGrpcService<SkillTriesService>();
            app.MapGrpcReflectionService();
        }
    }
}
