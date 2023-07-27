﻿using EKLEXIA.Data;
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


            var branchMembers = ctx.Members.Where(m=>m.BranchId == Encryption.Decrypt(Id)).Select(m => m.Fullname);


            ManageBMVm manageBMVm = new()
            {
              
            };


            return View(manageBMVm);


        }
    }
}
