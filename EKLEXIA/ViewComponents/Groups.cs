
using EKLEXIA.Data;
using EKLEXIA.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace EKLEXIA.ViewComponents
{
    public class Groups : ViewComponent
    {
        public readonly XContext xct;
        public Groups(XContext XContext)
        {
            xct = XContext;
        }
        public IViewComponentResult Invoke()
        {
            var grps = xct.Groups.Where(r => r.IsDeleted == false).Select(r => new GroupsVM
            {
       Name=r.Name,
Id = r.Id,
      Description=r.Description,





            }).ToList();
            return View(grps);
        }
    }
}
