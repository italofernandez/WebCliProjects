using CoreAPI.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreAPI.Infra.Data.Mapping
{
    public class AntivirusInfoMap : IEntityTypeConfiguration<AntivirusInfo>
    {
        public void Configure(EntityTypeBuilder<AntivirusInfo> builder)
        {
            builder.HasKey(x => x.Id);
        }
    }
}
