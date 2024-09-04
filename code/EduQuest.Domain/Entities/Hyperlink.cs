using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduQuest.Domain.Entities;
public class Hyperlink
{
    public Guid id { get; set; }
    public string Url { get; set; }
    public Guid DomainId { get; set; }
    public DomainInfo DomainInfo { get; set; }
    public Guid CreatedBy { get; set; }
    public DateTimeOffset CreatedOn { get; set; }
    public DateTimeOffset LastUpdated {  get; set; }
    public List<Keyword>? keywords { get; set; }
}

