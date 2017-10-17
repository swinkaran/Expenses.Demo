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
            Employee employee = employeeRepository.GetById(UserId);
            expense.Employee = employee;
            expense.ApprovalStatus = Expense.Status.Submitted; // Always 'Submitted' when creating

            expenseRepository.Add(expense);

            //  Send Email to the managers

            //  Add a notification to be triggered in 48 hours

        }

        public Expense GetExpense(long id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Expense> GetExpenses()
        {
            IList<Expense> expenses = expenseRepository.GetAll().ToList();

            return expenses;
        }

        public void SaveExpense()
        {
            unitOfWork.Commit();
        }

        public void UpdateExpense(Expense expense)
        {
            expenseRepository.Update(expense);

            if (expense.ApprovalStatus == Expense.Status.Reimbursed)
            {
                // Notify the employee via email

            }
        }
    }

    public interface IExpenseService
    {
        IEnumerable<Expense> GetExpenses();
        Expense GetExpense(long id);
        void CreateExpense(Expense expense, long userId);
        void UpdateExpense(Expense expense);
        void SaveExpense();
    }
}
