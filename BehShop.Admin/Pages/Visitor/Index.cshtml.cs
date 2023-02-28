using BehShop.Application.VisitorServices.GetTodayReport;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BehShop.Admin.Pages.Visitor
{
    public class IndexModel : PageModel
    {
        private readonly IGetTodayReportService _reportService;
        public ResultTodayReportDTO resultToday { get; set; }
        public IndexModel(IGetTodayReportService reportService)
        {
            _reportService = reportService;
        }

        public void OnGet()
        {
            resultToday = _reportService.Execute();
        }
    }
}
