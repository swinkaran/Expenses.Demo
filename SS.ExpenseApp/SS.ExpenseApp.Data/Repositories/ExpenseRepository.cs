using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using SS.ExpenseApp.BusinessEntities;
using SS.ExpenseApp.Data.Infrastructure;

namespace SS.ExpenseApp.Data.Repositories
{
    public class ExpenseRepository : RepositoryBase<Expense>, IExpenseRepository
    {
        public ExpenseRepository(IDbFactory dbFactory) : base(dbFactory) { }

        public Expense GetExpense(long id)
        {
            return this.DbContext.Expenses.Where(e => e.Id == id).FirstOrDefault();
        }

        public List<Expense> GetExpensesByEmployee(long employeeId)
        {
            return this.DbContext.Expenses.Where(e => e.Employee.Id == employeeId).ToList();
        }
    }

    public interface IExpenseRepository : IRepository<Expense>
    {
        //Get all
        List<Expense> GetExpensesByEmployee(long employeeId);

        //Get a contact by id
        Expense GetExpense(long id);
    }
}
