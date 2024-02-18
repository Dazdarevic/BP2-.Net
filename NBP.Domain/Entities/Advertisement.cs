using NBP.Domain.Identity;
using System.ComponentModel.DataAnnotations;

namespace NBP.Domain.Entities;

public class Advertisement
{
    [Key]
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Url { get; set; }
    public bool IsMain { get; set; }
    public string? PublicId { get; set; }
    public int SponsorId { get; set; }
    public Sponsor? Sponsor { get; set; }
}
