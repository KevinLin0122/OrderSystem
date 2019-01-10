using HC.Core.DataBase;
using HC.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HC.Core.Repository
{
    public class EFOrderRepository : IOrderRepository
    {
        private OrderDbContext OrderDbContext { get; set; }

        public EFOrderRepository()
        {
            OrderDbContext = new OrderDbContext();
        }

        public List<Product> SelectAll(string name)
        {
            var result = new List<Product>();
            var query = OrderDbContext.Product.AsQueryable();
            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(x => x.產品名稱 == name);
            }
            return query.ToList();
        }
        public void Insert(Product item)
        {
            OrderDbContext.Product.Add(item);
            OrderDbContext.SaveChanges();
        }
        public void Update(Product item)
        {
            var exist = OrderDbContext.Product
                .Where(x => x.id == item.id).SingleOrDefault();
            if (exist == null)
                return;
            exist.產品名稱 = item.產品名稱;
            exist.價錢 = item.價錢;
            OrderDbContext.SaveChanges();
        }
        public void Delete(int id)
        {
            var exist = OrderDbContext.Product
                .Where(x => x.id == id).SingleOrDefault();
            if (exist == null)
                return;
            OrderDbContext.Product.Remove(exist);
            OrderDbContext.SaveChanges();

        }


    }
}
