using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApi.Domain.Subtasks;

namespace ToDoApi.Persistance.Configurations;

public class SubtaskConfiguration : IEntityTypeConfiguration<Subtask>
{
    public void Configure(EntityTypeBuilder<Subtask> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Title)
            .IsRequired().HasMaxLength(100);
        builder.HasQueryFilter(x => x.Status != Domain.Enums.StatusEnum.Deleted);
        builder.Property(x => x.TargetCompilationDate)
            .IsRequired();


    }
}
