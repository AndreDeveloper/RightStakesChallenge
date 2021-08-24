﻿using Microsoft.EntityFrameworkCore;
using RightStakes.Challenge.Domain.Entities;
using RightStakes.Challenge.Infra.Data.EntityConfiguration;

namespace RightStakes.Challenge.Infra.Data.Context
{
    public class RightStakesContext : DbContext
    {
        public RightStakesContext(DbContextOptions<RightStakesContext> options) : base(options)
        {

        }

        public DbSet<CryptoCurrency> CryptoCurrencies { get; set; }

        public DbSet<Quote> Quotes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CryptoCurrencyConfiguration());
            modelBuilder.ApplyConfiguration(new QuoteConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
