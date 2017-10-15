using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SS.ExpenseApp.BusinessEntities;
using SS.ExpenseApp.Data.Repositories;
using SS.ExpenseApp.Data.Infrastructure;

namespace SS.ExpenseApp.Service
{
    public class ExpenseService:IExpenseService
    {
        private readonly IEmployeeRepository employeeRepository;
        private readonly IExpenseRepository expenseRepository;
        private readonly IUnitOfWork unitOfWork;

        public ExpenseService() { }

        public ExpenseService(IExpenseRepository _expenseRepository, IEmployeeRepository _employeeRepository, IUnitOfWork _unitOfWork)
        {
            this.expenseRepository = _expenseRepository;
            this.employeeRepository = _employeeRepository;
            this.unitOfWork = _unitOfWork;
        }

        public void CreateExpense(Expense expense, long UserId)
        {
            // Get the employee
            Employee employee = employeeRepository.GetById(1);

            expense.Employee = employee;
            expense.ApprovalStatus = Expense.Status.Submitted;

            expenseRepository.Add(expense);
        }

        public Expense GetExpense(long id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Expense> GetExpenses(long employeeId)
        {
            IList<Expense> expenses = expenseRepository.GetAll().ToList();

            return expenses;
        }

        public void SaveExpense()
        {
            unitOfWork.Commit();
            throw new NotImplementedException();
        }

        public void UpdateExpense(Expense expense)
        {
            throw new NotImplementedException();
        }
    }

    public interface IExpenseService
    {
        IEnumerable<Expense> GetExpenses(long employeeId);
        Expense GetExpense(long id);
        void CreateExpense(Expense expense, long userId);
        void UpdateExpense(Expense expense);
        void SaveExpense();
    }
}
