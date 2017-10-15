using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SS.ExpenseApp.Data.Infrastructure
{
    public class Disposable:IDisposable
    {
        private bool isDisposed;

        ~Disposable()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);

            GC.SuppressFinalize(this);
            //throw new NotImplementedException();
        }

        private void Dispose(bool disposing)
        {
            if (!isDisposed && disposing)
            {
                DisposeCore();
            }

            isDisposed = true;
            //throw new NotImplementedException();
        }   

        protected virtual void DisposeCore()
        {
            //Override this method to dispose custom objects
            //throw new NotImplementedException();
        }
    }
}
