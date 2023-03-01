using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BehShop.Domain.Visitors
{
    public class OnlineVisitors
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public DateTime Time { get; set; }
        public string ClientId { get; set; }
    }
}
