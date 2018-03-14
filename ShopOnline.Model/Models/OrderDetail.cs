using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopOnline.Model.Models
{
    [Table("OrderDetail")]
    public class OrderDetail
    {
        [Key]

        public int OrderID { get; set; }
        [Key]
        public int ProductID { get; set; }
        public int Quantity { get; set; }
        [ForeignKey("OrderID")]
        public virtual Order Order { set; get; }
        [ForeignKey("ProductID")]
        public virtual Product Product { set; get; }
    }
}
