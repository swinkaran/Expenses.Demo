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
        public ExpenseEntities() : base("ExpenseEntities") {
            Database.SetInitializer(new DataSeeder());
        }

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

    internal class DataSeeder : DropCreateDatabaseIfModelChanges<ExpenseEntities>
    {
        protected override void Seed(ExpenseEntities context)
        {
            IList<Employee> employees = new List<Employee>() {
                new Employee() { Id = 1, Name = "Employee 1" },
                 new Employee() { Id = 2, Name = "Employee 2" },
                  new Employee() { Id = 3, Name = "Employee 3" },
                   new Employee() { Id = 4, Name = "Employee 4" },
                    new Employee() { Id = 5, Name = "Manager 1" },
                     new Employee() { Id = 6, Name = "Manager 2" },
                     new Employee() { Id = 6, Name = "Financial 1" },
                      new Employee() { Id = 7, Name = "Financial 2" }
            };

            context.Employees.AddRange(employees);
            context.SaveChanges();

            IList<Expense> expenses = new List<Expense>() {
                new Expense(){ Id=1 ,ReceiptNumber="A111",ReceiptDate=DateTime.Today.AddDays(-3), Description="Myki fare", Amount=15, ApprovalStatus=Expense.Status.Submitted, ReimbursementAmount=15, Employee = employees[0] },
                new Expense(){ Id= 2,ReceiptNumber="B231",ReceiptDate=DateTime.Today.AddDays(-4), Description="Client lunch", Amount=22, ApprovalStatus=Expense.Status.Approved, ReimbursementAmount=18, Employee = employees[0] },
                new Expense(){ Id= 3,ReceiptNumber="B234",ReceiptDate=DateTime.Today.AddDays(-2), Description="Train fare", Amount=14, ApprovalStatus=Expense.Status.Submitted, ReimbursementAmount=14, Employee = employees[0] },
                new Expense(){ Id= 4,ReceiptNumber="A543",ReceiptDate=DateTime.Today.AddDays(-6), Description="Staff tea", Amount=14, ApprovalStatus=Expense.Status.Submitted, ReimbursementAmount=12, Employee = employees[0] },
                new Expense(){ Id= 5,ReceiptNumber="C534",ReceiptDate=DateTime.Today.AddDays(-7), Description="Keyboard", Amount=24, ApprovalStatus=Expense.Status.Submitted, ReimbursementAmount=22, Employee = employees[2] },
                new Expense(){ Id= 6,ReceiptNumber="C456",ReceiptDate=DateTime.Today.AddDays(-12), Description="Monitor", Amount=32, ApprovalStatus=Expense.Status.Approved, ReimbursementAmount=28, Employee = employees[2] },
                new Expense(){ Id= 7,ReceiptNumber="D657",ReceiptDate=DateTime.Today.AddDays(-17), Description="Client calls", Amount=43, ApprovalStatus=Expense.Status.Submitted, ReimbursementAmount=42, Employee = employees[3] },
                new Expense(){ Id= 8,ReceiptNumber="D763",ReceiptDate=DateTime.Today.AddDays(-14), Description="Taxi fare", Amount=23, ApprovalStatus=Expense.Status.Submitted, ReimbursementAmount=23, Employee = employees[0] },
                new Expense(){ Id= 9,ReceiptNumber="E645",ReceiptDate=DateTime.Today.AddDays(-1), Description="Evening dinner", Amount=22, ApprovalStatus=Expense.Status.Submitted, ReimbursementAmount=22, Employee = employees[3] },
                new Expense(){ Id= 10,ReceiptNumber="F432",ReceiptDate=DateTime.Today.AddDays(-9), Description="Stationary", Amount=67, ApprovalStatus=Expense.Status.Submitted, ReimbursementAmount=67, Employee = employees[0] },
                new Expense(){ Id= 11,ReceiptNumber="F786",ReceiptDate=DateTime.Today.AddDays(-8), Description="Cleint spend", Amount=78, ApprovalStatus=Expense.Status.Approved, ReimbursementAmount=75, Employee = employees[0] },
                new Expense(){ Id= 12,ReceiptNumber="F986",ReceiptDate=DateTime.Today.AddDays(-11), Description="Busticket", Amount=76, ApprovalStatus=Expense.Status.Rejected, ReimbursementAmount=75, Employee = employees[1] },
                new Expense(){ Id= 13,ReceiptNumber="S432",ReceiptDate=DateTime.Today.AddDays(-14), Description="Calls made", Amount=54, ApprovalStatus=Expense.Status.Rejected, ReimbursementAmount=54, Employee = employees[1] },
                new Expense(){ Id= 14,ReceiptNumber="S543",ReceiptDate=DateTime.Today.AddDays(-22), Description="Internet usage", Amount=87, ApprovalStatus=Expense.Status.Reimbursed, ReimbursementAmount=87, Employee = employees[3] },
                new Expense(){ Id= 15,ReceiptNumber="S434",ReceiptDate=DateTime.Today.AddDays(-12), Description="home expense", Amount=53, ApprovalStatus=Expense.Status.Reimbursed, ReimbursementAmount=53, Employee = employees[1] },
            };
            context.Expenses.AddRange(expenses);
            context.SaveChanges();
        }
    }
}
