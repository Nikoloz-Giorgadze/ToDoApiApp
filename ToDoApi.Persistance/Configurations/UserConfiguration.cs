using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApi.Domain.Users;

namespace ToDoApi.Persistance.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Username)
            .IsRequired()
            .HasMaxLength(50)
            .IsUnicode();
        builder.Property(x => x.Password)
            .IsRequired()
            .HasMaxLength(512);

        builder.HasMany(x => x.ToDos)
            .WithOne(x => x.Owner)
            .HasForeignKey(x => x.OwnerId);
    }
}
