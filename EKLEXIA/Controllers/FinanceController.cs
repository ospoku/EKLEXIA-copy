using EKLEXIA.Models;
using EKLEXIA.Data;
using EKLEXIA.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace EKLEXIA.Controllers
{
    public class FinanceController : Controller
    {

        public readonly XContext cxt;


        public FinanceController(XContext xContext)
        {
            cxt = xContext;

        }

        [HttpGet]
        public IActionResult AddMember() => ViewComponent("AddMember");






        public IActionResult DetailMember(string Id)
      => ViewComponent("DetailMember", Id);
        public IActionResult EditMember(string Id)
        => ViewComponent("EditMember", Id);
        [HttpPost]
        
        [HttpGet]
        public IActionResult Tithes()
        {
            return ViewComponent("Tithes");
        }
        [HttpGet]
        public IActionResult AddTithe()
        {
            return ViewComponent("AddTithe");
        }
        [HttpGet]
        public IActionResult WelfareList()
        {
            return ViewComponent("WelfareList");
        }


        [HttpGet]
        public IActionResult AddWelfare()
        {
            return ViewComponent("AddWelfare");
        }

        public IActionResult DeleteMember() => ViewComponent("ViewMembers");

        public IActionResult Fundraisings()
        {
            return ViewComponent("Fundraisings");
        }
        public IActionResult Card(string Id)
        {
            return ViewComponent("Card", Id);
        }






    }
}
