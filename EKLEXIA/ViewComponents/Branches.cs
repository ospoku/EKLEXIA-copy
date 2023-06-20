
using EKLEXIA.Data;
using EKLEXIA.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace EKLEXIA.ViewComponents
{
    public class Branches : ViewComponent
    {
        public readonly XContext xct;
        public Branches(XContext XContext)
        {
            xct = XContext;
        }
        public IViewComponentResult Invoke()
        {
            var branches = xct.Branches.Where(r => r.IsDeleted == false).Select(r => new BranchesVM
            {
       Name=r.Name,
Id = r.Id,
      Description=r.Description,





            }).ToList();
            return View(branches);
        }
    }
}
