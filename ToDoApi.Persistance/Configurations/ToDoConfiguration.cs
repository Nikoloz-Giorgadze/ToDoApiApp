using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApi.Domain.ToDos;

namespace ToDoApi.Persistance.Configurations;

public class ToDoConfiguration : IEntityTypeConfiguration<ToDo>
{
    public void Configure(EntityTypeBuilder<ToDo> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasQueryFilter(x => x.Status != Domain.Enums.StatusEnum.Deleted);
        builder.Property(x => x.Title).IsRequired();
        builder.Property(x => x.Status).IsRequired();
        builder.Property(x => x.TargetCompilationDate).IsRequired();
        builder.HasMany(x => x.Subtasks)
            .WithOne(x => x.ParentToDo)
            .HasForeignKey(x => x.ToDoItemId);
    }
}
