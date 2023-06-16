using Microsoft.EntityFrameworkCore;
using EKLEXIA.Models;
using EKLEXIA.ViewComponents;

namespace EKLEXIA.Data
{
    public class XContext : AuditableIdentityContext
    {
        public XContext(DbContextOptions<XContext> options) : base(options)
        {

        }

        public DbSet<Member> Members { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<Month> Months { get; set; }
        public DbSet<Attendance> AttendanceLists { get; set; }
        public DbSet<Welfare> Welfares { get; set; }
        public DbSet<MaritalStatus> MaritalStatuses { get; set; }
        public DbSet<Career> Careers { get; set; }
        public DbSet<Tithe> Tithes { get;  set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Income> Incomes { get;  set; }
        public DbSet<Meeting> Meetings { get; set; }
        public DbSet<Fund> Funds { get; set; }  
        public DbSet<Fundraising> Fundraisings { get;set; }
        public DbSet<MemberGroup>memberGroups { get; set; }
    }


}
