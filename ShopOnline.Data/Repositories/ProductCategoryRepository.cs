using ShopOnline.Data.Infrastructure;
using ShopOnline.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopOnline.Data.Repositories
{
    public interface IProductCategoryRepository : IRepository<ProductCategory>
    {
        IEnumerable<ProductCategory> getByAlias(string alias); 
    }
    public class ProductCategoryRepository:RepositoryBase<ProductCategory>,IProductCategoryRepository
    {
        public ProductCategoryRepository(IDbFactory dbFactory): base(dbFactory)
        {

        }

        public IEnumerable<ProductCategory> getByAlias(string alias)
        {
            return this.DbContext.ProductCategorys.Where(x => x.Alias == alias);
        }
    }
}
