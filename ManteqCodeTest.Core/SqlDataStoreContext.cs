using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ManteqCodeTest.Core.Domain;

namespace ManteqCodeTest.Core
{
    public class SqlDataStoreContext : DbContext
    {
        public SqlDataStoreContext()
            : base("SqlDataStoreContext")
        {
            Database.SetInitializer<SqlDataStoreContext>(null);
        }
        public static SqlDataStoreContext Create()
        {
            return new SqlDataStoreContext();
        }
        public DbSet<ManteqEvent> ManteqEvents { get; set; }
        public DbSet<ManteqApprovalRequest> ManteqApprovalRequests { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.
                Conventions.
                Remove<System.Data.Entity.ModelConfiguration.Conventions.PluralizingTableNameConvention>();
        }
    }
}
