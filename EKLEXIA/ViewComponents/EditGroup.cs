using Microsoft.AspNetCore.Mvc;
using EKLEXIA.Data;
using EKLEXIA.Models;
using EKLEXIA.ViewModels;
using Microsoft.AspNetCore.DataProtection;
using EKLEXIA.DataProtection;

namespace EKLEXIA.ViewComponents
{
    public class EditGroup : ViewComponent
    {
        public readonly XContext xct;
       
        public EditGroup(XContext xContext)
        {
            xct = xContext;
        
        }
        public IViewComponentResult Invoke(string Id)
        {
         
           
             var grpToEdit= xct.Groups.Where(c => c.Id == Encryption.Decrypt(Id)).FirstOrDefault();
            EditGrpVM editGrpVM = new()
            {

              

                Name = grpToEdit.Name,
            
              
            Description=grpToEdit.Description
       

            };
            return View(editGrpVM);
        }
    }
}
