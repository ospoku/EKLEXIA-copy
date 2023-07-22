using EKLEXIA.Models;
using EKLEXIA.Data;
using EKLEXIA.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace EKLEXIA.Controllers
{
    public class FinanceController : Controller
    {

        public readonly XContext xct;


        public FinanceController(XContext xContext)
        {
            xct = xContext;

        }

        [HttpGet]
        public IActionResult AddMember() => ViewComponent("AddMember");






        public IActionResult DetailMember(string Id)
      => ViewComponent("DetailMember", Id);
        public IActionResult EditMember(string Id)
        => ViewComponent("EditMember", Id);
        
        
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

        [HttpPost]
        public async Task< IActionResult> AddTithe(AddTitheVM addTitheVM)
        {
            if (addTitheVM == null) {
            }

            Tithe addThisTithe = new()
            {
                Amount = addTitheVM.Amount,
                Description = addTitheVM.Description,
                TitheDate = addTitheVM.Date,
                MemberId = addTitheVM.MemberId,
            };
            xct.Add(addThisTithe);
            xct.SaveChanges();
            return View();
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
