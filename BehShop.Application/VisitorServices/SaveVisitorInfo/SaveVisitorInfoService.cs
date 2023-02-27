using BehShop.Application.Interfaces.Context;
using BehShop.Domain.Visitors;
using MongoDB.Driver;

namespace BehShop.Application.VisitorServices.SaveVisitorInfo
{
    public class SaveVisitorInfoService : ISaveVisitorInfoService
    {
        private readonly IMongoDbContext<Visitor> _mongoDbContext;
        private readonly IMongoCollection<Visitor> _collection;

        public SaveVisitorInfoService(IMongoDbContext<Visitor> mongoDbContext)
        {
            _mongoDbContext = mongoDbContext;
            _collection = _mongoDbContext.GetCollection();   
        }

        public void Execute(RequestSaveVisitorInfoDTO request)
        {
            _collection.InsertOne(new Visitor
            {
                Browser = new VisitorVersion
                {
                    Family = request.Browser.Family,
                    Version = request.Browser.Version,
                },
                OperationSystem = new VisitorVersion
                {
                    Family = request.OperationSystem.Family,
                    Version = request.OperationSystem.Version,
                },
                Device = new Device
                {
                    Family = request.Device.Family,
                    Brand = request.Device.Brand,
                    IsSpider = request.Device.IsSpider,
                    Model = request.Device.Model,
                },
                CurrentLink = request.CurrentLink,
                IP = request.IP,
                Method = request.Method,
                PhysicalPath = request.PhysicalPath,
                Protocol = request.Protocol,
                ReferrerLink = request.ReferrerLink,
            });
        }
    }
}
