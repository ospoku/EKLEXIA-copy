using EKLEXIA.Data;
using EKLEXIA.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace EKLEXIA.ViewComponents
{
    public class AddGroup : ViewComponent
    {
        public readonly XContext xct;
        public AddGroup(XContext xContext)
        {
            xct = xContext;
        }

        public IViewComponentResult Invoke()
        {
            AddGroupVM addGroupVM = new()
            {



            };

            return View(addGroupVM);
        }

    }
}


  
