using Microsoft.AspNetCore.Mvc;
using EKKLESIA.Models;
using EKLEXIA.Data;

namespace EKKLESIA.ViewComponents
{
    public class EditCareer : ViewComponent
    {
        public readonly XContext xct;
        public EditCareer(XContext XContext)
        {
            xct = XContext;
        }
        public IViewComponentResult Invoke(string Id)
        {
            Career CareerToEdit = new Career();
            CareerToEdit = (from a in xct.Careers where a.Id == Id & a.IsDeleted == false select a).FirstOrDefault();
            EditCareerVM editCareerVM = new EditCareerVM()
            {



                CareerName = CareerToEdit.Name
            
              
            
       

            };
            return View(editCareerVM);
        }
    }
}
