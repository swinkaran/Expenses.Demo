using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SS.ExpenseApp.BusinessEntities
{
    public class Notification
    {
        [Key]
        public long Id { get; set; }
        public DateTime NotifyOn { get; set; }
        public Employee NotifyTo { get; set; }
    }
}
