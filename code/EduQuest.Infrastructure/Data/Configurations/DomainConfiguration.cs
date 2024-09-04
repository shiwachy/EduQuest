using EduQuest.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduQuest.Infrastructure.Data.Configurations
{
    public class DomainConfiguration: IEntityTypeConfiguration<DomainInfo>
    {
        public void Configure(EntityTypeBuilder<DomainInfo> builder) 
        {
            builder.HasKey(d => d.DomainId);
            builder.Property(d => d.DomainName).IsRequired();
            builder.Property(d => d.Description).HasMaxLength(200);
            builder.Property(d=>d.CreatedOn).IsRequired();
        }
    }
}
