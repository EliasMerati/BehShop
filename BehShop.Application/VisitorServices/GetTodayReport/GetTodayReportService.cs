using BehShop.Application.Interfaces.Context;
using BehShop.Domain.Visitors;
using MongoDB.Driver;

namespace BehShop.Application.VisitorServices.GetTodayReport
{
    public class GetTodayReportService : IGetTodayReportService
    {
        private readonly IMongoDbContext<Visitor> _mongoDbContext;
        private readonly IMongoCollection<Visitor> _collection;

        public GetTodayReportService(IMongoDbContext<Visitor> mongoDbContext)
        {
            _mongoDbContext = mongoDbContext;
            _collection = _mongoDbContext.GetCollection();
        }

        public ResultTodayReportDTO Execute()
        {
            var Start = DateTime.Now.Date;
            var End = DateTime.Now.Date.AddDays(1);

            var TodayPageViewCount = _collection.AsQueryable()
                .Where(p=> p.Time >= Start && p.Time< End)
                .LongCount();

            var TodayVisitorCount = _collection.AsQueryable()
                .Where(p => p.Time >= Start && p.Time < End)
                .GroupBy(p=>p.VisitorId)
                .LongCount();

            var AllPageView = _collection.AsQueryable()
                .LongCount();

            var AllVisitorCount = _collection.AsQueryable()
                .GroupBy(p=>p.VisitorId)
                .LongCount();

            return new ResultTodayReportDTO
            {
                GeneralState = new GeneralStateDto
                {
                    TotalPagePerViewer = AllPageView / AllVisitorCount,
                    TotalViewer = AllVisitorCount,
                    TotalPageViewer = AllPageView
                },
                Today = new TodayViewDTO
                {
                    TotalPage = TodayPageViewCount,
                    Visitors = TodayVisitorCount,
                    TotalPagePerViewer = TodayPageViewCount / TodayVisitorCount
                };
            }
        }
    }
