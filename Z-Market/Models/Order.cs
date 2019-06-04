using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Z_Market.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }


        public DateTime DateOrder { get; set; }

        public Statu StatuOrder { get; set; }


        public int CustumerId { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        public virtual Custumer Custumer { get; set; }
    }
}
