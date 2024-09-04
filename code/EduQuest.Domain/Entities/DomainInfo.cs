using System.ComponentModel.DataAnnotations;

namespace EduQuest.Domain.Entities;

public class DomainInfo
{
    public Guid DomainId { get; set; }
    public string DomainName { get; set; }
    public string? Url { get; set; }

    [MaxLength(200)]
    public string? Description { get; set; }
    public DateTime CreatedOn { get; set; }
    public DateTime? UpdatedOn { get; set; }
    public bool IsActive { get; set; }
    public List<Hyperlink> Hyperlinks { get; set; }
}

