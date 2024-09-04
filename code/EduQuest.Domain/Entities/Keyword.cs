using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduQuest.Domain.Entities
{
    public class Keyword
    {
        public Guid KeywordId { get; set; }

        [MaxLength(100)]
        public string KeywordName { get; set; }
        public List<Hyperlink>? Hyperlinks { get; set; }

    }
}
