using System.ComponentModel.DataAnnotations;

namespace NBP.Application.DTOs
{
    public class AddManagerDto
    {
        public int ID { get; set; }
        //public string? FirstName { get; set; }
        //public string? LastName { get; set; }
        [Required]
        public string? FullName { get; set; }
        public string? BirthDate { get; set; }
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public string? Role { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Password { get; set; }

    }
}
