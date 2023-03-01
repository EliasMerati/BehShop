namespace BehShop.Application.VisitorServices.OnlineVisitor
{
    public interface IOnlineVisitorService
    {
        void ConnectUser(string ClientId);
        void DisconnectUser(string ClientId);
        int GetCount();
    }
}
