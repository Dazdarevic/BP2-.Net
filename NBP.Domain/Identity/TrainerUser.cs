using NBP.Domain.Entities;
using Sieve.Attributes;

namespace NBP.Domain.Identity;

public class TrainerUser : User
{
    [Sieve(CanSort = true, CanFilter = true)]
    public string? Specialization { get; set; }
    public TrainerSalary? TrainerSalary { get; set; } // Navigation property
    public ICollection<Rating> Ratings { get; set; } = new List<Rating>(); // Član može imati više ocena
    public ICollection<Comment> Comments { get; set; } = new List<Comment>();
}
