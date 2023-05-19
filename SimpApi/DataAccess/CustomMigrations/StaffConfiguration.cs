using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.CustomMigrations
{
    public class StaffConfiguration : IEntityTypeConfiguration<Staff>
    {
        public void Configure(EntityTypeBuilder<Staff> builder)
        {
            
            builder.Property(x=>x.Id).IsRequired(true).UseIdentityColumn();
            builder.Property(x=>x.CreatedBy).IsRequired(false).HasMaxLength(50);
            builder.Property(x=>x.CreatedAt).IsRequired(false);

            builder.Property(x=>x.FirstName).IsRequired(true).HasMaxLength(30);
            builder.Property(x=>x.LastName).IsRequired(true).HasMaxLength(30);
            builder.Property(x=>x.Email).IsRequired(true).HasMaxLength(40);
            builder.Property(x=>x.Phone).IsRequired(true).HasMaxLength(11);
            builder.Property(x=>x.DateOfBirth).IsRequired(true);
            builder.Property(x => x.AddressLine1).IsRequired(true).HasMaxLength(300);
            builder.Property(x => x.City).IsRequired(true).HasMaxLength(14);
            builder.Property(x => x.Country).IsRequired(true).HasMaxLength(40);
            builder.Property(x => x.Province).IsRequired(true).HasMaxLength(17);


            builder.HasIndex(x => x.Email).IsUnique(true);

        }
    }
}
