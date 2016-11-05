using System;
using System.Linq;
using System.Collections.Generic;

namespace MVC5Course.Models
{
    public class ProductRepository : EFRepository<Product>, IProductRepository
    {
        public object Configuration { get; internal set; }

        public override IQueryable<Product> All()
        {
            return base.All().Where(x => x.IsDeleted == false);
        }

        public Product Find(int id)
        {
            var result = this.All().SingleOrDefault(x => x.ProductId == id);
            return result;
        }

        public List<Product> 我要封裝查詢條件至Repository_取Product前10筆()
        {
            var result = this.All().Where(x => x.IsDeleted == false).OrderByDescending(p => p.ProductId).Take(10).ToList();
            return result;
        }

        public void Repository刪除(Product product) {
            product.IsDeleted = true;
        }

    }

    public interface IProductRepository : IRepository<Product>
    {

    }
}