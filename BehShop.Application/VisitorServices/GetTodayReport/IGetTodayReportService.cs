using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BehShop.Application.VisitorServices.GetTodayReport
{
    public interface IGetTodayReportService
    {
        ResultTodayReportDTO Execute();
    }
}
