﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using EKLEXIA.Data;
using EKLEXIA.Models;
using EKLEXIA.ViewModels;
using System.Diagnostics.CodeAnalysis;
using EKLEXIA.DataProtection;

namespace EKLEXIA.ViewComponents
{
    public class EditMember : ViewComponent
    {
        public readonly XContext xct;
        [SetsRequiredMembers]
        public EditMember(XContext XContext)
        {
            xct = XContext;
        }
        public IViewComponentResult Invoke(string Id)
        {
            Member MemberToEdit = new();
            MemberToEdit = (from a in xct.Members where a.MemberId == Encryption.Decrypt(Id) & a.IsDeleted == false select a).FirstOrDefault();
            EditMemberVM editMemberVM = new()
            {
             
                Genders = new SelectList(xct.Genders.ToList(), nameof(Gender.GenderId), nameof(Gender.Name)),
                Branches= new SelectList (xct.Branches.ToList(),nameof(Branch.BranchId),nameof(Branch.Name)),   
           Regions=new SelectList(xct.Regions.ToList(),nameof(Region.RegionId),nameof(Region.Name)),    
                Address = MemberToEdit.Address,
              
                DoB = MemberToEdit.DoB,
          
                GenderId = MemberToEdit.GenderId,
                RegionId = MemberToEdit.RegionId,
                Residence = MemberToEdit.Hometown,
                Othername = MemberToEdit.Othername,
                BranchId=MemberToEdit.BranchId,
                Surname = MemberToEdit.Surname,
                Telephone = MemberToEdit.Telephone,

            };
            return View(editMemberVM);
        }
    }
}
