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
    public class NotificationService : INotificationService
    {
        public void NotifyEmployee(Employee emp)
        {
            //Set up an email template
            //throw new NotImplementedException();
        }

        public void SetReminder(Employee emp)
        {
            //Set email reminder to be sent in 48 hours
        }
    }

    public interface INotificationService
    {
        void NotifyEmployee(Employee emp);
        void SetReminder(Employee emp);
    }
}
