using MongoDB.Driver;

namespace AboutMe.Backend.Infrastructure.Helpers;
public static class MongoHelper
{
    public static IMongoDatabase GetMongoDatabaseContext(string connection, string databaseName)
    {
        var mongoClient = new MongoClient(connection);
        var databaseContext = mongoClient.GetDatabase(databaseName);
        return databaseContext;
    }
}