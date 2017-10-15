using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.ComponentModel.DataAnnotations;
//using System.ComponentModel.DataAnnotations.Schema;

namespace SS.ExpenseApp.BusinessEntities
{
    public class Employee
    {
        public Employee()
        {
            Expenses = new HashSet<Expense>();
        }
        
        public long Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Expense> Expenses { get; set; }
    }
}
