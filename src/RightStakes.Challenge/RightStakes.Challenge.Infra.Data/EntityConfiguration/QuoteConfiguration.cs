using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RightStakes.Challenge.Domain.Entities;

namespace RightStakes.Challenge.Infra.Data.EntityConfiguration
{
    public class QuoteConfiguration : IEntityTypeConfiguration<Quote>
    {
        public void Configure(EntityTypeBuilder<Quote> builder)
        {
            builder.ToTable("Quote");

            builder.HasKey(_ => _.Uid);
        }
    }
}
