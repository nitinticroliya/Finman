﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Finman.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class FinManEntities : DbContext
    {
        public FinManEntities()
            : base("name=FinManEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<AdminLogin> AdminLogins { get; set; }
        public virtual DbSet<investmentPlansSuggested> investmentPlansSuggesteds { get; set; }
        public virtual DbSet<Login> Logins { get; set; }
        public virtual DbSet<retirementPlansSuggested> retirementPlansSuggesteds { get; set; }
        public virtual DbSet<profilesData> profilesDatas { get; set; }
        public virtual DbSet<Question> Questions { get; set; }
        public virtual DbSet<QuestionOption> QuestionOptions { get; set; }
    }
}
