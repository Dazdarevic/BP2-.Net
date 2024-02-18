using NBP.Domain.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NBP.Domain.Entities;

public class TrainerSalary
{
    [Key]
    public int IdSalary { get; set; }
    [Required]
    public string? SalaryAmount { get; set; }

    [ForeignKey("Trainer")]
    public int? ID { get; set; }
    //navigatio propertie
    public TrainerUser? Trainer { get; set; }
}