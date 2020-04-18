using CoreAPI.Domain.Entities;
using CoreAPI.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CoreAPI.Infra.Data.Mapping
{
    public class MachineMap : IEntityTypeConfiguration<Machine>
    {
        public void Configure(EntityTypeBuilder<Machine> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.AntivirusInfo)
                .WithOne(av => av.Machine)
                .HasForeignKey<AntivirusInfo>(av => av.MachineId);
        }
    }
}
