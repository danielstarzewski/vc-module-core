﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtoCommerce.Foundation.Money;

namespace VirtoCommerce.Domain.Marketing.Model
{
	public abstract class AmountBasedReward : PromotionReward
	{
		public RewardAmountType AmountType { get; set; }

		public decimal Amount { get; set; }

		public int QuantityLimit { get; set; }

		public decimal CalculateDiscountAmount(decimal price, int quantity = 1)
		{
			var retVal = Amount;
			if (AmountType == RewardAmountType.Relative)
			{
				retVal = Math.Floor(price * Amount) * Math.Min(quantity, QuantityLimit == 0 ? quantity : QuantityLimit);
			}
			return FinanceRound(retVal);
		}

		private static decimal FinanceRound(decimal value)
		{
			return Math.Round(value, 2, MidpointRounding.AwayFromZero);
		}
	}
}
