using System.ComponentModel.DataAnnotations;

namespace EmplMngt.Model
{
    public class Employee
    {
        [Required]
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Department { get; set; }
        [Required]
        [Range(0, 9)]
        public long Phone { get; set; }
        [Required]
        [Range(10000, 300000)]
        public long Salary { get; set; }


    }
}
