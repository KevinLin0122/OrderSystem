using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HC.Web.Models
{
    [Serializable]
    public class Cart
    {
        public Cart()
        {
            this.cartItems = new List< Cart_Model >();
        }
        public List<Cart_Model> cartItems;

        public decimal TotalAoumt
        {
            get
            {
                decimal totalAmount = 0.0m;
                foreach(var carItem in this.cartItems)
                {
                    totalAmount = totalAmount + carItem.Amount;
                }

                return totalAmount;
            }
        }
    }
}
