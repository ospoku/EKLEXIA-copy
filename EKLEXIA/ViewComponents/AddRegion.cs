using EKLEXIA.Data;
using EKLEXIA.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace EKKLESIA.ViewComponents
{
    public class AddRegion:ViewComponent
    {
        public readonly XContext xct;
        public AddRegion(XContext xContext)
        {
            xct = xContext;
        }

        public IViewComponentResult Invoke()
        {
            AddRegionVM addRegionVM = new AddRegionVM
            {
             
             
        
            };

            return View(addRegionVM);
        }
            
    }
}
