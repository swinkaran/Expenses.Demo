using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SS.ExpenseApp.BusinessEntities;
using SS.ExpenseApp.Data.Repositories;
using SS.ExpenseApp.Data.Infrastructure;
using System.ComponentModel.DataAnnotations;

namespace SS.ExpenseApp.Web.Models
{
    public class IndexVM
    {
        [DataType(DataType.Date)]
        public DateTime? StartDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime? EndDate { get; set; }

        public virtual ICollection<Expense> Expenses { get; set; }
    }
}