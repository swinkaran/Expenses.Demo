using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using SS.ExpenseApp.BusinessEntities;
using SS.ExpenseApp.Service;
using System.Security.Claims;

namespace SS.ExpenseApp.Web.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        static List<Expense> expenses;
        private readonly IExpenseService expenseService;
        private long currentUser;
        private string currentRole;

        public HomeController(IExpenseService _expenseService)
        {
            expenseService = _expenseService;
            expenses = InitExpenses();
        }

        private List<Expense> InitExpenses()
        {
            return expenseService.GetExpenses().ToList();
        }

        // GET: List all Expense
        public ActionResult Index()
        {
            currentRole = this.GetCurrentRole();
            ViewBag.Role = currentRole;

            SS.ExpenseApp.Web.Models.IndexVM ivm = new Models.IndexVM();
            
            if (currentRole == "Manager")
            {
                // Filter only the Status = Submitted
                ivm.Expenses = expenses.
                    Where(e => e.ApprovalStatus == Expense.Status.Submitted).ToList();
            }

            else if (currentRole == "Finance")
            {
                // Filter only the Status = Submitted
                ivm.Expenses = expenses.
                    Where(e => e.ApprovalStatus == Expense.Status.Approved).ToList();
            }
            else
            {
                ivm.Expenses = expenses.
                    Where(e => e.Employee.Id == this.GetCurrentUserId()).ToList();
            }

            return View(ivm);
        }

        [HttpPost]
        public ActionResult Index(FormCollection collection)
        {
            currentRole = this.GetCurrentRole();
            ViewBag.Role = currentRole;

            expenses = String.IsNullOrEmpty(collection["StartDate"]) ? expenses: expenses.Where(e => e.ReceiptDate > Convert.ToDateTime(collection["StartDate"])).ToList();
            expenses = String.IsNullOrEmpty(collection["EndDate"]) ? expenses: expenses.Where(e => e.ReceiptDate < Convert.ToDateTime(collection["EndDate"])).ToList();
            
            SS.ExpenseApp.Web.Models.IndexVM ivm = new Models.IndexVM();

            if (currentRole == "Manager")
            {
                // Filter only the Status = Submitted
                ivm.Expenses = expenses.
                    Where(e => e.ApprovalStatus == Expense.Status.Submitted).ToList();
            }

            else if (currentRole == "Finance")
            {
                // Filter only the Status = Submitted
                ivm.Expenses = expenses.
                    Where(e => e.ApprovalStatus == Expense.Status.Approved).ToList();
            }
            else
            {
                ivm.Expenses = expenses.
                    Where(e => e.Employee.Id == this.GetCurrentUserId()).ToList();
            }

            return View(ivm);
        }

        // Employee
        // GET: Expense/Create
        public ActionResult Create()
        {
            currentRole = this.GetCurrentRole();
            return View();
        }

        [Authorize]
        // POST: Expense/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                Expense expense = new Expense();

                expense.ReceiptNumber = collection["ReceiptNumber"].ToString();
                expense.ReceiptDate = Convert.ToDateTime(collection["ReceiptDate"].ToString());
                expense.Description = collection["Description"].ToString();
                expense.Amount = Convert.ToDecimal(collection["Amount"].ToString());
                expense.ReimbursementAmount = Convert.ToDecimal(collection["ReimbursementAmount"].ToString());

                //expenseService.CreateExpense(expense);
                expenseService.CreateExpense(expense, this.GetCurrentUserId());
                expenseService.SaveExpense();

                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [Authorize]
        // GET: Home/Details/5
        public ActionResult Details(int id)
        {
            var expense = expenses.Where(e => e.Id == id).ToList().FirstOrDefault();
            if (expense != null)
            {
                currentRole = this.GetCurrentRole();
                ViewBag.Role = currentRole;
                return View(expense);
            }
            return View();
        }

        // POST: Approve/5
        [Authorize]
        public ActionResult Approve(long id)
        {
            try
            {
                var expense = expenses.Where(e => e.Id == id).ToList().FirstOrDefault();
                if (expense != null)
                {
                    expense.ApprovalStatus = Expense.Status.Approved;
                    expenseService.UpdateExpense(expense);
                    expenseService.SaveExpense();
                }

                // TODO: Add update logic here
                return RedirectToAction("Index");
            }
            catch(Exception e)
            {
                return View();
            }
        }

        // POST: Approve/5
        [Authorize]
        public ActionResult Reject(long id)
        {
            try
            {
                var expense = expenses.Where(e => e.Id == id).ToList().FirstOrDefault();
                if (expense != null)
                {
                    expense.ApprovalStatus = Expense.Status.Rejected;
                    expenseService.UpdateExpense(expense);
                    expenseService.SaveExpense();
                }

                // TODO: Add update logic here
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // POST: Approve/5
        [Authorize]
        public ActionResult Reimburse(long id)
        {
            try
            {
                var expense = expenses.Where(e => e.Id == id).ToList().FirstOrDefault();
                if (expense != null)
                {
                    expense.ApprovalStatus = Expense.Status.Reimbursed;
                    expenseService.UpdateExpense(expense);
                    expenseService.SaveExpense();
                }

                // TODO: Add update logic here
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return View();
            }
        }

        [NonAction]
        private long GetCurrentUserId()
        {
            string Id;

            if (User != null)
            {
                Id = User.Identity.GetUserId();
                if (Id != null)
                {
                    return Convert.ToInt64(Id);
                }
            }
            return 0;
        }

        [NonAction]
        private string GetCurrentRole()
        {
            string role = null;
            var identity = (ClaimsIdentity)User.Identity;
            if (identity.FindFirst(ClaimTypes.Role) != null)
                role = identity.FindFirst(ClaimTypes.Role).Value;

            if (role != null)
            {
                return role;
            }
            return null;
        }
    }
}