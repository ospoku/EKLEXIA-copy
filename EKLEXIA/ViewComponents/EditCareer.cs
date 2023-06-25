using Microsoft.AspNetCore.Mvc;
using EKLEXIA.Data;
using EKLEXIA.Models;
using EKLEXIA.ViewModels;
using Microsoft.AspNetCore.DataProtection;
using EKLEXIA.DataProtection;

namespace EKLEXIA.ViewComponents
{
    public class EditCareer : ViewComponent
    {
        public readonly XContext xct;
        public readonly IDataProtector protector;
        public EditCareer(XContext xContext, IDataProtectionProvider provider)
        {
            xct = xContext;
            protector = provider.CreateProtector("");
        }
        public IViewComponentResult Invoke(string Id)
        {
         
           
             var CareerToEdit= xct.Careers.Where(c => c.Id == Encryption.Decrypt(Id)).FirstOrDefault();
            EditCareerVM editCareerVM = new()
            {



                Name = CareerToEdit.Name,
            
              
            Description=CareerToEdit.Description
       

            };
            return View(editCareerVM);
        }
    }
}
