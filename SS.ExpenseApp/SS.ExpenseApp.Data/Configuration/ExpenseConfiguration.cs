using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using SS.ExpenseApp.BusinessEntities;

namespace SS.ExpenseApp.Data.Configuration
{
    public class ExpenseConfiguration:EntityTypeConfiguration<Expense>
    {
        public ExpenseConfiguration()
        {
            ToTable("Expenses");

            //Defining the table
            HasKey(e => e.Id);

            // Defining the properties
        }
    }
}
