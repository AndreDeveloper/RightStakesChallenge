using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RightStakes.Challenge.Domain.Entities;

namespace RightStakes.Challenge.Infra.Data.EntityConfiguration
{
    public class CryptoCurrencyConfiguration : IEntityTypeConfiguration<CryptoCurrency>
    {
        public void Configure(EntityTypeBuilder<CryptoCurrency> builder)
        {
            builder.ToTable("CryptoCurrency");

            builder.HasKey(_ => _.Uid);
        }
    }
}
