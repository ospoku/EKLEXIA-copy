using EKLEXIA.Data;
using EKLEXIA.DataProtection;
using EKLEXIA.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EKLEXIA.ViewComponents
{
    public class ManageBranch : ViewComponent
    {
        public readonly XContext ctx;
        public ManageBranch(XContext xContext)
        { ctx = xContext; }

        public IViewComponentResult Invoke(string Id)
        {
            ManageBMVm manageBMVm = new();

            var branchMembers =   ctx.Members.Where(m=>m.BranchId==Encryption.Decrypt(Id)).Select(m=>new    ManageBMVm 
            {
                Fullname= m.Fullname,
                GenderId= m.GenderId
            }).ToList();


    


            return View(manageBMVm);


        }
    }
}
