using EKLEXIA.Data;
using EKLEXIA.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace EKLEXIA.ViewComponents
{
    public class DetailMember:ViewComponent
    {
        public readonly XContext xct;
        public DetailMember(XContext XContext)
        {
            xct = XContext;
        }

        public IViewComponentResult Invoke(string Id)
        {
            var MemberDetail = xct.Members.Include("Gender").Where(a => a.IsDeleted == false & a.MemberId == Id).Select(a => new DetailMemberVM

       

           
            {
             Insurance=a.Hometown,
                ClinicNumber = a.RegionId,
                Address = a.Address,
           
                DoB = a.DoB,
               
                GenderId = a.Gender.Name,
             
                Othername = a.Othername,
             
                Surname = a.Surname,
                Telephone = a.Telephone,
                
            }).FirstOrDefault();

            return View(MemberDetail);
        }
            
    }
}
