using NBP.Domain.Identity;
using System.ComponentModel.DataAnnotations;

namespace NBP.Domain.Entities;

public class Comment
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string? Text { get; set; }

    public int TrainerId { get; set; }
    public TrainerUser? Trainer { get; set; }

    public int MemberId { get; set; }
    public Member? Member { get; set; }
}