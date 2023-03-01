using BehShop.Application.VisitorServices.OnlineVisitor;
using Microsoft.AspNetCore.SignalR;

namespace BehShop.Web.Hubs
{
    public class SignalROnlineVisitorsHub : Hub
    {
        private readonly IOnlineVisitorService onlineVisitorService;
        public SignalROnlineVisitorsHub(IOnlineVisitorService onlineVisitorService)
        {
            this.onlineVisitorService = onlineVisitorService;
        }

        public override Task OnConnectedAsync()
        {
            var VisitorId = Context.GetHttpContext().Request.Cookies["VisitorId"];
            onlineVisitorService.ConnectUser(VisitorId);
            var Count = onlineVisitorService.GetCount();
            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception? exception)
        {
            var VisitorId = Context.GetHttpContext().Request.Cookies["VisitorId"];
            onlineVisitorService.DisconnectUser(VisitorId);
           var Count = onlineVisitorService.GetCount();
            return base.OnDisconnectedAsync(exception);
        }
    }
}
