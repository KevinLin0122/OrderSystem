using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HC.Web.Models
{
    [Serializable]
    public class Cart_Model
    {
        public int id { get; set; }
        public string 產品名稱 { get; set; }
        public int 價錢 { get; set; }

        public int 個數 { get; set; }

        public decimal Amount
        {
            get
            {
                return this.價錢 * this.個數;
            }
        }

    }
}
