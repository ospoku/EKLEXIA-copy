﻿using EKLEXIA.Data;
using EKLEXIA.ViewModels;
using Microsoft.AspNetCore.Mvc;
namespace EKLEXIA.ViewComponents
{
    public class ViewTithes : ViewComponent
    {
        public readonly XContext xct;
        public ViewTithes(XContext XContext)
        {
            xct = XContext;
        }
        public IViewComponentResult Invoke()
        {
            var Tithes = xct.Tithes.Where(t => t.IsDeleted == false).Select(t => new ViewTithesVM
            {
               





            }).ToList();
            return View(Tithes);
        }
    }
}
