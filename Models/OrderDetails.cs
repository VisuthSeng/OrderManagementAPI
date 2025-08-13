using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrderManagementAPI.Models
{
    [Table("ORDER_DETAILS")]
    public class OrderDetail
    {
        [Key, Column("ORDER_ID", Order = 0)]
        public int OrderId { get; set; }

        [Key, Column("PRODUCT_ID", Order = 1)]
        public int ProductId { get; set; }

        [Column("UNIT_PRICE")]
        public decimal UnitPrice { get; set; }

        [Column("QUANTITY")]
        public int Quantity { get; set; }

        [ForeignKey("OrderId")]
        public virtual required Order Order { get; set; }

        [ForeignKey("ProductId")]
        public virtual required Product Product { get; set; }
    }
}