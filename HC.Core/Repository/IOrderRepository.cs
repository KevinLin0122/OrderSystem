using HC.Core.Models;
using System.Collections.Generic;

namespace HC.Core.Repository
{
    public interface IOrderRepository
    {
        void Delete(int id);
        void Insert(Product item);
        List<Product> SelectAll(string name);
        void Update(Product item);
    }
}
