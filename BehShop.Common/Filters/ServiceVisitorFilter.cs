using BehShop.Application.VisitorServices.SaveVisitorInfo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using UAParser;

namespace BehShop.Common.Filters
{

    public class ServiceVisitorFilter : IActionFilter
    {
        private readonly ISaveVisitorInfoService _saveVisitorInfo;
        public ServiceVisitorFilter(ISaveVisitorInfoService saveVisitorInfo)
        {
            _saveVisitorInfo = saveVisitorInfo;
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            string IP = context.HttpContext.Request.HttpContext.Connection.LocalIpAddress.ToString();
            var ActionName = ((ControllerActionDescriptor)context.ActionDescriptor).ActionName;
            var ControllerName = ((ControllerActionDescriptor)context.ActionDescriptor).ControllerName;
            var UserAgent = context.HttpContext.Request.Headers["User-Agent"];
            var uaparser = Parser.GetDefault();
            ClientInfo info = uaparser.Parse(UserAgent);
            var Referer = context.HttpContext.Request.Headers["Referer"].ToString();
            var CurrentUrl = context.HttpContext.Request.Path;
            var request = context.HttpContext.Request;
            string VisitorId = context.HttpContext.Request.Cookies["VisitorId"];
            if (VisitorId == null)
            {
                VisitorId = Guid.NewGuid().ToString().Replace("-","");
                context.HttpContext.Response.Cookies.Append("VisitorId", VisitorId, new CookieOptions
                {
                    Path = "/",
                    HttpOnly = true,
                    Expires = DateTime.Now.AddDays(30),
                });
            }

            _saveVisitorInfo.Execute(new RequestSaveVisitorInfoDTO
            {
                Browser = new VisitorVersionDTO
                {
                    Family = info.UA.Family,
                    Version = $"{info.UA.Major}.{info.UA.Minor}.{info.UA.Patch}",
                },
                OperationSystem = new VisitorVersionDTO
                {
                    Family = info.OS.Family,
                    Version = $"{info.OS.Major}.{info.OS.Minor}.{info.OS.Patch}",
                },
                Device = new DeviceDTO
                {
                    Brand = info.Device.Brand,
                    Family = info.Device.Family,
                    IsSpider = info.Device.IsSpider,
                    Model = info.Device.Model,
                },
                CurrentLink = CurrentUrl,
                IP = IP,
                ReferrerLink = Referer,
                Protocol = request.Protocol,
                Method = request.Method,
                PhysicalPath = $"{ControllerName}/{ActionName}",
                VisitorId = VisitorId,             
            });
        }
    }
}
