using BehShop.Application.Interfaces.Context;
using BehShop.Domain.Visitors;
using MongoDB.Driver;

namespace BehShop.Application.VisitorServices.OnlineVisitor
{
    public class OnlineVisitorService : IOnlineVisitorService
    {
        private readonly IMongoDbContext<OnlineVisitors> _mongoDbContext;
        private readonly IMongoCollection<OnlineVisitors> mongoCollection;
        public OnlineVisitorService(IMongoDbContext<OnlineVisitors> mongoDbContext)
        {
            this._mongoDbContext = mongoDbContext;
            this.mongoCollection = _mongoDbContext.GetCollection();
        }

        public void ConnectUser(string ClientId)
        {
            var Exist = mongoCollection.AsQueryable().FirstOrDefault(p=> p.Equals(ClientId));
            if (Exist is null)
            {
                mongoCollection.InsertOne(new OnlineVisitors
                {
                    ClientId = ClientId,
                    Time = DateTime.Now,
                });
            }
           
        }

        public void DisconnectUser(string ClientId)
        {
            mongoCollection.FindOneAndDeleteAsync(p => p.ClientId == ClientId);
        }

        public int GetCount()
        {
            return mongoCollection.AsQueryable().Count();
        }
    }
}
