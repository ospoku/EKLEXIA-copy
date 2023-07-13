using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using EKLEXIA.Models;
using EKLEXIA.Data;
using EKLEXIA.ViewModels;
using System.Collections.Generic;

namespace EKLEXIA.ViewComponents
{
    public class AddMember : ViewComponent
    {
        public readonly XContext xct;
        public AddMember(XContext xContext)
        {
            xct = xContext;
        }

        public IViewComponentResult Invoke()
        {
            AddMemberVM addMemberVM = new AddMemberVM
            {

                Genders = new SelectList(xct.Genders.ToList(), nameof(Gender.Id), nameof(Gender.Name)),
                MaritalStatuses = new SelectList(xct.MaritalStatuses.ToList(), nameof(MaritalStatus.Id), nameof(MaritalStatus.Name)),
                Careers = new SelectList(xct.Careers.ToList(), nameof(Career.Id), nameof(Career.Name)),
                Regions = new SelectList(xct.Regions.ToList(), nameof(Region.Id), nameof(Region.Name)),
<<<<<<< HEAD

                Groups = new SelectList(xct.Groups.ToList()),
=======
                Groups = new SelectList(xct.Groups.ToList(),nameof(Group.Id), nameof(Group.Name)),
           
             
>>>>>>> 8a9db862277e6e9344738b61c746aff30cb31f45
                Branches = new SelectList(xct.Branches.ToList(), nameof(Branch.Id), nameof(Branch.Name))
            };

            return View(addMemberVM);
        }

    }
}
