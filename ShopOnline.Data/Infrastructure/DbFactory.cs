using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopOnline.Data.Infrastructure
{
    class DbFactory : Disposable, IDbFactory
    {
        private ShopOnLineDBContext dbContext;

        

        public ShopOnLineDBContext Init()
        {
            return dbContext ?? (dbContext = new ShopOnLineDBContext());


        }
        protected override void Disposecore()
        {
            if (dbContext != null)
            {
                dbContext.Dispose();

            }
        }
    }
}
