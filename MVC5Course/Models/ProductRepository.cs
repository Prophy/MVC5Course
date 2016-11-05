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

        public List<Product> �ڭn�ʸˬd�߱����Repository_��Product�e10��()
        {
            var result = this.All().Where(x => x.IsDeleted == false).OrderByDescending(p => p.ProductId).Take(10).ToList();
            return result;
        }

        public void Repository�R��(Product product) {
            product.IsDeleted = true;
        }

    }

    public interface IProductRepository : IRepository<Product>
    {

    }
}