using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SS.ExpenseApp.BusinessEntities
{
    public class Expense
    {
        public enum Status { Submitted, Approved, Rejected, Reimbursed }

        public long Id { get; set; }

        public string ReceiptNumber { get; set; }

        [DataType(DataType.Date)]
        public DateTime ReceiptDate { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public decimal ReimbursementAmount { get; set; }

        public Status ApprovalStatus { get; set; }
        public virtual Employee Employee { get; set; }
    }
}
