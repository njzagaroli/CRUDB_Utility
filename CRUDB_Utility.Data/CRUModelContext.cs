namespace CRUDB_Utility.Data
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using CRUDB_Utility.Domain;

    public partial class CRUModelContext : DbContext
    {
        public CRUModelContext()
            : base("name=CRUModelContext")
        {
        }

        public virtual DbSet<CRUConstant> CRUConstants { get; set; }
        public virtual DbSet<CRUMember> CRUMembers { get; set; }
        public virtual DbSet<CRUNameValue> CRUNameValues { get; set; }
        public virtual DbSet<DataObject> DataObjects { get; set; }
        public virtual DbSet<DataRule> DataRules { get; set; }
        public virtual DbSet<DataRuleValidation> DataRuleValidations { get; set; }
        public virtual DbSet<DataStructure> DataStructures { get; set; }
        public virtual DbSet<DataStructureType> DataStructureTypes { get; set; }
        public virtual DbSet<ProductValidation> ProductValidations { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }

        public override int SaveChanges()
        {
            ApplyLoggingRules();
            return base.SaveChanges();
        }

        public void ApplyLoggingRules()
        {
            var currentDate = DateTime.Today;
            var currentUser = Environment.UserDomainName + "\\" + Environment.UserName;

            foreach (var entry in ChangeTracker.Entries()
                                        .Where(e => e.Entity is ILogInfo &&
                                        (e.State == EntityState.Added || e.State == EntityState.Modified)))
            {
                //var e = entry.Entity as ILogInfo;

                if (entry.State == EntityState.Added)
                {
                    ((ILogInfo)entry.Entity).PD_INS_Date = currentDate;
                    ((ILogInfo)entry.Entity).PD_INS_By = currentUser;
                }

                ((ILogInfo)entry.Entity).PD_UPD_Date = currentDate;
                ((ILogInfo)entry.Entity).PD_UPD_By = currentUser;
            }
        }

    }
}
