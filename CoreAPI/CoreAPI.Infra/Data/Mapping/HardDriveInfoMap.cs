using CoreAPI.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CoreAPI.Infra.Data.Mapping
{
    public class HardDriveInfoMap : IEntityTypeConfiguration<HardDriveInfo>
    {
        public void Configure(EntityTypeBuilder<HardDriveInfo> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Machine)
                .WithMany(e => e.HardDriveInfos)
                .HasForeignKey(s => s.MachineId);
        }
    }
}
