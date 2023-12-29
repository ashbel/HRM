﻿

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Hrm_SystemCore.Models
{

    
    public class HRMEntities : IdentityDbContext<Users>
    {
        public HRMEntities(DbContextOptions<HRMEntities> options)
            : base(options)
        {
        }
        public DbSet<tblBranch> tblBranches { get; set; }
        public DbSet<tblDepartment> tblDepartments { get; set; }
        public DbSet<tblEmployee> tblEmployees { get; set; }
        public DbSet<tblEmployeeStatu> tblEmployeeStatus { get; set; }
        public DbSet<tblJobLevel> tblJobLevels { get; set; }
        public DbSet<tblOrganisation> tblOrganisations { get; set; }
        public DbSet<tblPositionHistory> tblPositionHistories { get; set; }
        public DbSet<tblPosition> tblPositions { get; set; }
        public DbSet<tblUser> tblUsers { get; set; }
        //public DbSet<sysdiagram> sysdiagrams { get; set; }
        public DbSet<tblEmplStatu> tblEmplStatus { get; set; }
        public DbSet<tblImage> tblImages { get; set; }
        public DbSet<tblContract> tblContracts { get; set; }
        public DbSet<tblLeave> tblLeaves { get; set; }
        public DbSet<tblLvType> tblLvTypes { get; set; }
        public DbSet<tblLvUsage> tblLvUsages { get; set; }
        public DbSet<tblMarital> tblMaritals { get; set; }
        public DbSet<tblGender> tblGenders { get; set; }
        public DbSet<tblAllowanceLnk> tblAllowanceLnks { get; set; }
        public DbSet<tblAllowance> tblAllowances { get; set; }
        public DbSet<tblBank> tblBanks { get; set; }
        public DbSet<tblContractType> tblContractTypes { get; set; }
        public DbSet<tblDeductionLnk> tblDeductionLnks { get; set; }
        public DbSet<tblDeduction> tblDeductions { get; set; }
        public DbSet<tblEmployeeContact> tblEmployeeContacts { get; set; }
        public DbSet<tblgrade> tblgrades { get; set; }
        public DbSet<tblPayMethod> tblPayMethods { get; set; }
        public DbSet<tblPayroll> tblPayrolls { get; set; }
        public DbSet<tblSalutation> tblSalutations { get; set; }
        public DbSet<tblWkshftLink> tblWkshftLinks { get; set; }
        public DbSet<tblWorkshift> tblWorkshifts { get; set; }
        public DbSet<tblRelationship> tblRelationships { get; set; }
        public DbSet<tblCity> tblCities { get; set; }
        public DbSet<tblProvince> tblProvinces { get; set; }
        public DbSet<tblCours> tblCourses { get; set; }
        public DbSet<tblCourseType> tblCourseTypes { get; set; }
        public DbSet<tblTraining> tblTrainings { get; set; }
        public DbSet<tblDocument> tblDocuments { get; set; }
        public DbSet<tblContractState> tblContractStates { get; set; }
        public DbSet<tblDependant> tblDependants { get; set; }
        public DbSet<tblEducation> tblEducations { get; set; }
        public DbSet<tblEduLevel> tblEduLevels { get; set; }
        public DbSet<tblWork> tblWorks { get; set; }
        public DbSet<tblAchievement> tblAchievements { get; set; }
        public DbSet<tblKPI> tblKPIs { get; set; }
        public DbSet<tblTrainingSession> tblTrainingSessions { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(HRMEntities).Assembly);
        }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.Properties<decimal>()
                .HavePrecision(18, 6);
        }

    }
}