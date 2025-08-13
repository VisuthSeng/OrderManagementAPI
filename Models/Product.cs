using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrderManagementAPI.Models
{
    [Table("PRODUCTS")]
    public class Product
    {
        [Key]
        [Column("PRODUCT_ID")]
        public int ProductId { get; set; }

        [Required]
        [Column("PRODUCT_NAME")]
        [StringLength(100)]
        public required string ProductName { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
    }
}