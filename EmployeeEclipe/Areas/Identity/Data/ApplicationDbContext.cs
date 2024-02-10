#nullable disable
using EmployeeEclipe.Areas.Identity.Data;
using EmployeeEclipe.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EmployeeEclipe.Areas.Identity.Data;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Department> Departments { get; set; }
    public DbSet<EmployeLeave> EmployeLeaves { get; set; }
    public DbSet<EmplyeeLeaveRecord> EmplyeeLeaveRecords { get; set; }  
    public DbSet<ChatRecord> ChatRecords { get; set; }  
    public DbSet<NoticBorad> NoticBorads { get; set; }  


    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }
}
