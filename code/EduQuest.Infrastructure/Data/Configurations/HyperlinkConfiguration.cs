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
    public class HyperlinkConfiguration:IEntityTypeConfiguration<Hyperlink>
    {
        public void Configure(EntityTypeBuilder<Hyperlink> builder)
        {
            builder.HasKey(h => h.id);
            builder.Property(h => h.Url).IsRequired();

            builder.HasOne(h => h.DomainInfo)
                .WithOne()
                .HasForeignKey<DomainInfo>(h => h.DomainId);

            //builder.HasOne(h => h.User)
            //    .WithOne()
            //    .HasForeignKey<User>(h => h.UserId);


            builder.Property(h=>h.CreatedOn).IsRequired();

            builder.HasMany(h => h.keywords)
                .WithMany();
        }
    }
}
