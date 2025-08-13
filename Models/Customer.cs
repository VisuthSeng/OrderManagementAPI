using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrderManagementAPI.Models
{
    [Table("CUSTOMERS")]
    public class Customer
    {
        [Key]
        [Column("CUSTOMER_ID")]
        public int CustomerId { get; set; }

        [Required]
        [Column("NAME")]
        [StringLength(100)]
        public required string Name { get; set; }

        [Column("ADDRESS")]
        [StringLength(200)]
        public string? Address { get; set; }  // Made nullable since not all customers might have addresses

        [Column("COUNTRY")]
        [StringLength(50)]
        public string? Country { get; set; }  // Made nullable since not all customers might have countries

        // Navigation property
        public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}
