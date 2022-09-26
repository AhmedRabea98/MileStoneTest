using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using  MileStone.Models;
namespace MileStone.Context
{
    public class DBContext:IdentityDbContext<User>
    {
        public DBContext()
        {

        }
        public DBContext(DbContextOptions<DBContext> options):base(options)
        {

        }
        public DbSet<BusinessCase> BusinessCases { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Sector> Sectors { get; set; }
        public DbSet<BeneficiariesandStakeholders> BeneficiariesandStakeholders { get; set; }
        public DbSet<Risk> Risks { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Comments> Comments { get; set; }
        public DbSet<Attachment> Attachment { get; set; }
        public DbSet<ProjectCharter> ProjectCharters { get; set; }
        public DbSet<ProjectRolesAndResources> ProjectRolesAndResources { get; set; }
        public DbSet<StrategicObjectives> StrategicObjectives { get; set; }
        public DbSet<BusinessCaseWithProjects> BusinessCaseWithProjects { get; set; }
        public DbSet<ProjectCashFlow> ProjectCashFlows { get; set; }
        public DbSet<ProjectManagementPlan> ProjectManagementPlans { get; set; }
        public DbSet<ProjectOutputsAndCost> ProjectOutputsAndCosts { get; set; }
        public DbSet<ImplementationTimeline> ImplementationTimeline { get; set; }
        public DbSet<LimitationsAndAssumptions> LimitationsAndAssumptions { get; set; }
        public DbSet<ResourceAndCadreManagement> ResourceAndCadreManagement { get; set; }
        public DbSet<CommunicationPlan> CommunicationPlans { get; set; }
        public DbSet<BenefitRealizationPlan> BenefitRealizationPlans { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<BusinessCaseWithProjects>().
                HasKey(b => new { b.BusienssCaseID , b.ProjectID});
            builder.Entity<BusinessCaseWithProjects>().HasOne(b => b.BusinessCase).WithMany(p => p.BusinessCasesWihtProjects)
                .HasForeignKey(B=>B.BusienssCaseID);

            builder.Entity<BusinessCaseWithProjects>().HasOne(b => b.Project).WithMany(p => p.BusinessCasesWihtProjects)
           .HasForeignKey(B => B.ProjectID);
            base.OnModelCreating(builder);
        }
    }
}
