using System.ComponentModel.DataAnnotations;

namespace ABCBankingGroup.Models
{
    public class Customer
    {
        [Key]
        public int CustomerID { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public int AccNo { get; set; } = new Random().Next(0, 1000000);
        [Required]
        public string AccType { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public int Mobile { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public DateTime DOB { get; set; }
        public string? Status { get; set; }
        public DateTime CreatedDateTime { get; set; } = DateTime.Now;
    }
}
