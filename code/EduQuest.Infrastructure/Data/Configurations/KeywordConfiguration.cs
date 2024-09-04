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
    public class KeywordConfiguration: IEntityTypeConfiguration<Keyword>
    {
        public void Configure(EntityTypeBuilder<Keyword> builder)
        {
            builder.HasKey(k=>k.KeywordId);

            builder.Property(k=>k.KeywordName)
                .IsRequired()
                .HasMaxLength(50);

            builder.HasMany(k => k.Hyperlinks)
                .WithMany();
        }
    }
     
}
