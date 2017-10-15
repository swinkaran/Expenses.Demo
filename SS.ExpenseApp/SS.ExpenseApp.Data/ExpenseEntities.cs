using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using SS.ExpenseApp.BusinessEntities;

namespace SS.ExpenseApp.Data
{
    public class ExpenseEntities:DbContext
    {
        public ExpenseEntities() : base("ExpenseEntities") { }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<Notification> Motifications { get; set; }


        public virtual void Commit()
        {
            base.SaveChanges();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // This will create the tables in singular
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Configurations.Add(new Configuration.EmployeeConfiguration());
            modelBuilder.Configurations.Add(new Configuration.ExpenseConfiguration());
            
        }
    }
}
