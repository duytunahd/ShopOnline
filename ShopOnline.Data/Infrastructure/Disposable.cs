using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopOnline.Data.Infrastructure
{
    class Disposable: IDisposable
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
        }
        private void Dispose(bool disposing)
        {
            if(!isDisposed && disposing)
            {
                Disposecore();
            }
            isDisposed = true;
        }
        protected virtual void Disposecore()
        {

        }
    }
}
