using EKLEXIA.Data;
using EKLEXIA.ViewModels;
using Microsoft.AspNetCore.Mvc;
namespace EKLEXIA.ViewComponents
{
    public class Tithes : ViewComponent
    {
        public readonly XContext xct;
        public Tithes(XContext XContext)
        {
            xct = XContext;
        }
        public IViewComponentResult Invoke()
        {
            var Tithes = xct.Tithes.Where(t => t.IsDeleted == false).Select(t => new TithesVM
            {
               
                MemberId=t.Member.Fullname,
                Date=t.TitheDate,
                Description=t.Description,
                Amount= t.Amount,
                MonthId= t.Month,
                TitheId=t.TitheId,



            }).ToList();
            return View(Tithes);
        }
    }
}
