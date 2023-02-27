using MongoDB.Driver;

namespace BehShop.Application.Interfaces.Context
{
    public interface IMongoDbContext<T>
    {
        public IMongoCollection<T> MongoCollection();
    }
}
