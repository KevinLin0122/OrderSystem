using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;



namespace HC.Web.Models
{
    public class Operation
    {
        public static Cart GetCurrentCart(Cart OldCart)
        {

            if (OldCart != null)
            {
                var order = new Cart();

                return order;
            }
            else
            {
                return OldCart;
            }

        }

    }
}
