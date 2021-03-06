﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtoCommerce.Domain.Pricing.Model.Search
{
    public class PricelistAssignmentsSearchCriteria : PricingSearchCriteria
    {
        public string PriceListId { get; set; }

        private string[] _priceListIds;
        public string[] PriceListIds
        {
            get
            {
                if (_priceListIds == null && !string.IsNullOrEmpty(PriceListId))
                {
                    _priceListIds = new[] { PriceListId };
                }
                return _priceListIds;
            }
            set
            {
                _priceListIds = value;
            }
        }
    }
}
