using NBP.Domain.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NBP.Domain.Entities;

public class Membership
{

    [Key]
    public int IdMembership { get; set; }
    [Required]
    public string? MembershipAmount { get; set; }
    public int? Month { get; set; } // Dodajte atribut za mesec


    [ForeignKey("Member")]
    public int? ID { get; set; }
    //navigatio properties
    public Member? Member { get; set; }
}