namespace AboutMe.Backend.Infrastructure.Extensions
{
    public static class MongoExtension
    {
        public static string GetMongoConnectionString(this IConfiguration configuration) =>
        configuration["ConnectionStrings:Mongo:Connection"].Decrypt(AesConfiguration.Key, AesConfiguration.IV);
        public static string GetMongoDatabaseName(this IConfiguration configuration) =>
        configuration["ConnectionStrings:Mongo:Database"].Decrypt(AesConfiguration.Key, AesConfiguration.IV);
    }
}
