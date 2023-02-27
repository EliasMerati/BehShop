using BehShop.Application.Interfaces.Context;
using MongoDB.Driver;

namespace BehShop.Persistance.Contexts.MongoDBContext
{
    public class MongoDbContext<T> : IMongoDbContext<T>
    {
        private readonly IMongoDatabase db;
        private readonly IMongoCollection<T> collection;
        public MongoDbContext()
        {
            var client = new MongoClient();
            db = client.GetDatabase("VisitorDB");
            collection = db.GetCollection<T>(typeof(T).Name);
        }
        public IMongoCollection<T> MongoCollection()
        {
            return collection;
        }
    }
}
