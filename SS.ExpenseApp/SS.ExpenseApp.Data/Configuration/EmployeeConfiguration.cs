using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using SS.ExpenseApp.BusinessEntities;

namespace SS.ExpenseApp.Data.Configuration
{
    public class EmployeeConfiguration:EntityTypeConfiguration<Employee>
    {
        public EmployeeConfiguration()
        {
            ToTable("Employees");

            //Defining the table
            HasKey(e => e.Id);


            Property(e => e.Name).IsRequired().HasMaxLength(100);
        }
    }
}
