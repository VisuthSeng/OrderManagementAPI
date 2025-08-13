using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrderManagementAPI.Models
{
    [Table("EMPLOYEES")]
    public class Employee
    {
        [Key]
        [Column("EMPLOYEE_ID")]
        public int EmployeeId { get; set; }

        [Required]
        [Column("NAME")]
        [StringLength(100)]
        public required string Name { get; set; }

        public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}