﻿using RightStakes.Challenge.Domain.Entities;
using RightStakes.Challenge.Domain.Interfaces.Repositories;
using RightStakes.Challenge.Infra.Data.Context;

namespace RightStakes.Challenge.Infra.Data.Repository
{
    public class CryptoCurrencyRepository : Repository<CryptoCurrency>, ICryptoCurrencyRepository
    {
        public CryptoCurrencyRepository(RightStakesContext context) : base(context)
        {

        }
    }
}