using AboutMe.Backend.Infrastructure.Helpers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;

namespace AboutMe.Backend.Infrastructure.Extensions
{
    public static class BuilderExtension
    {
        public static void SetSettingFile(this WebApplicationBuilder builder, string relativePath, string fileName)
        {
            var absolutePath = Path.GetFullPath(relativePath);
            builder.Configuration.SetBasePath(absolutePath)
                                 .AddJsonFile(fileName);
        }
        public static void AddMongoDbContext(this WebApplicationBuilder builder)
        {
#if !DEBUG
        builder.SetSettingFile(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), "appsettings.json");
#endif
            var dbConnectionString = builder.Configuration.GetMongoConnectionString();
            var dbName = builder.Configuration.GetMongoDatabaseName();
            var databaseContext = MongoHelper.GetMongoDatabaseContext(dbConnectionString, dbName);

            builder.Services.AddSingleton(databaseContext);
        }

        public static void AddJwtBearerAuth(this WebApplicationBuilder builder)
        {
            builder.Services.AddAuthorization();
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                            .AddJwtBearer(options => JwtHelper.GenerateConfig(ref options, builder.Configuration.GetValidationParameter()));
        }
    }
}
