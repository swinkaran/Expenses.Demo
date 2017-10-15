using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SS.ExpenseApp.BusinessEntities;
using SS.ExpenseApp.Data.Infrastructure;

namespace SS.ExpenseApp.Data.Repositories
{
    public class EmployeeRepository : RepositoryBase<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(IDbFactory dbFactory) : base(dbFactory) { }

        public List<Expense> GetExpensesByEmployee(long id)
        {
            return this.DbContext.Expenses.Where(e => e.Id == id).ToList();
        }
    }
    
    public interface IEmployeeRepository : IRepository<Employee>
    {
        //Get all expenses
        List<Expense> GetExpensesByEmployee(long id);
    }

}
