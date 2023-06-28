using Microsoft.AspNetCore.Mvc;
using EKLEXIA.Data;
using EKLEXIA.ViewModels;

using EKLEXIA.DataProtection;

namespace EKLEXIA.ViewComponents
{
    public class EditCareer : ViewComponent
    {
        public readonly XContext xct;
        
        public EditCareer(XContext xContext)
        {
            xct = xContext;
         
        }
        public IViewComponentResult Invoke(string Id)
        {
         
           
             var careerToEdit= xct.Careers.Where(c => c.Id == Encryption.Decrypt(Id)).FirstOrDefault();
            EditCareerVM editCareerVM = new()
            {



                Name = careerToEdit.Name,
            
              
            Description=careerToEdit.Description
       

            };
            return View(editCareerVM);
        }
    }
}
