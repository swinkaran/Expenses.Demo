using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SS.ExpenseApp.Data;

namespace SS.ExpenseApp.Data.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        ExpenseEntities dbContext;

        public ExpenseEntities Init()
        {
            return dbContext ?? (dbContext = new ExpenseEntities());    
            //throw new NotImplementedException();
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }
    }
}
