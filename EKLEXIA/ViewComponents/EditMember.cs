using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using EKLEXIA.Data;
using EKLEXIA.Models;
using EKLEXIA.ViewModels;
using System.Diagnostics.CodeAnalysis;

namespace EKLEXIA.ViewComponents
{
    public class EditMember : ViewComponent
    {
        public readonly XContext xct;
        [SetsRequiredMembers]
        public EditMember(XContext XContext)
        {
            xct = XContext;
        }
        public IViewComponentResult Invoke(string Id)
        {
            Member MemberToEdit = new();
            MemberToEdit = (from a in xct.Members where a.MemberId == Id & a.IsDeleted == false select a).FirstOrDefault();
            EditMemberVM editMemberVM = new()
            {
             
                Genders = new SelectList(xct.Genders.ToList(), nameof(Gender.Id), nameof(Gender.Name)),
           
                Address = MemberToEdit.Address,
              
                DoB = MemberToEdit.DoB,
          
                GenderId = MemberToEdit.GenderId,
                RegionId = MemberToEdit.RegionId,
                Hometown = MemberToEdit.Hometown,
                Othername = MemberToEdit.Othername,

                Surname = MemberToEdit.Surname,
                Telephone = MemberToEdit.Telephone,

            };
            return View(editMemberVM);
        }
    }
}
