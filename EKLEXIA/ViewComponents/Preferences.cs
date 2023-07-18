using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using EKLEXIA.Models;
using EKLEXIA.Data;
using EKLEXIA.ViewModels;

namespace EKLEXIA.ViewComponents
{
    public class Preferences : ViewComponent
    {
        public readonly XContext xct;
        public Preferences(XContext xContext)
        {
            xct = xContext;
        }

        public IViewComponentResult Invoke()
        {
            AddMemberVM addMemberVM = new AddMemberVM
            {

                Genders = new SelectList(xct.Genders.ToList(), nameof(Gender.GenderId), nameof(Gender.Name)),
                MaritalStatuses = new SelectList(xct.MaritalStatuses.ToList(), nameof(MaritalStatus.Id), nameof(MaritalStatus.Name)),
                Careers = new SelectList(xct.Careers.ToList(), nameof(Career.CareerId), nameof(Career.Name)),
                Regions = new SelectList(xct.Regions.ToList(), nameof(Region.RegionId), nameof(Region.Name)),
               // Groups = new SelectList(xct.Groups.ToList(), nameof(Group.Id), nameof(Group.Name)),
                Branches = new SelectList(xct.Branches.ToList(), nameof(Branch.BranchId), nameof(Branch.Name))
            };

            return View(addMemberVM);
        }

    }
}
