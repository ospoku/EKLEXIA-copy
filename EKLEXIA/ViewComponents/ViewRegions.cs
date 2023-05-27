
using EKLEXIA.Data;
using EKLEXIA.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace EKLEXIA.ViewComponents
{
    public class ViewRegions : ViewComponent
    {
        public readonly XContext xct;
        public ViewRegions(XContext XContext)
        {
            xct = XContext;
        }
        public IViewComponentResult Invoke()
        {
            var RegionList = xct.Regions.Where(r => r.IsDeleted == false).Select(r => new ViewRegionsVM
            {
       Name=r.Name,
RegionId = r.Id,
      





            }).ToList();
            return View(RegionList);
        }
    }
}
