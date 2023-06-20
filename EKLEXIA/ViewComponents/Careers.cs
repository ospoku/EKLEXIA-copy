using EKLEXIA.Data;
using EKLEXIA.ViewModels;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EKLEXIA.ViewComponents
{
    public class Careers : ViewComponent
    {
        public readonly XContext xct;
        public readonly IDataProtector protector;
        public Careers(XContext XContext, IDataProtectionProvider provider)
        {
            xct = XContext;
            protector = provider.CreateProtector("EKLEXIA.Careers");
        }
        public IViewComponentResult Invoke()
        {
            var Careers = xct.Careers.Where(c => c.IsDeleted == false).Select(c => new CareersVM
            {
               CareerName =c.Name,
                CareerId = c.Id,
                Description = c.Description,
                EncryptedId= c.EncryptedId,
                
            }).ToList();

            foreach(var car in Careers)
            {
                var stringId=car.CareerId.ToString();
                car.EncryptedId = protector .Protect(stringId);
            }
            return View(Careers);
        }
    }
}
