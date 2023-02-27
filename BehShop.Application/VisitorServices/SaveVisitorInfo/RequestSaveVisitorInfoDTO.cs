namespace BehShop.Application.VisitorServices.SaveVisitorInfo
{
    public class RequestSaveVisitorInfoDTO
    {
        public string IP { get; set; }
        public string CurrentLink { get; set; }
        public string ReferrerLink { get; set; }
        public string Method { get; set; }
        public string Protocol { get; set; }
        public string PhysicalPath { get; set; }
        public VisitorVersionDTO Browser { get; set; }
        public VisitorVersionDTO OperationSystem { get; set; }
        public DeviceDTO Device { get; set; }
        public string VisitorId { get; set; }
    }
}
