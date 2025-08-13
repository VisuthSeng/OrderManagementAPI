using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrderManagementAPI.Models
{
    [Table("ORDERS")]
    public class Order
    {
        [Key]
        [Column("ORDER_ID")]
        public int OrderId { get; set; }

        [Column("CUSTOMER_ID")]
        public int CustomerId { get; set; }

        [Column("EMPLOYEE_ID")]
        public int EmployeeId { get; set; }

        [Column("ORDER_DATE")]
        public DateTime OrderDate { get; set; }

        [ForeignKey("CustomerId")]
        public virtual required Customer Customer { get; set; }

        [ForeignKey("EmployeeId")]
        public virtual required Employee Employee { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
    }
}