﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtoCommerce.Domain.Commerce.Model;
using VirtoCommerce.Platform.Core.Common;

namespace VirtoCommerce.Domain.Cart.Model
{
	public class ShipmentMethod : ValueObject<ShipmentMethod>, ITaxable
    {
		public string ShipmentMethodCode { get; set; }
		public string OptionName { get; set; }
		public string Name { get; set; }
		public string LogoUrl { get; set; }
		public string Currency { get; set; }

		public decimal Price { get; set; }

        public virtual decimal PriceWithTax
        {
            get
            {
                return Price + Price * TaxPercentRate;
            }
        }
     
        public virtual decimal DiscountAmount { get; set; }

        public virtual decimal DiscountAmountWithTax
        {
            get
            {
                return DiscountAmount + DiscountAmount * TaxPercentRate;
            }
        }

        public virtual decimal Total
        {
            get
            {
                return Price - DiscountAmount;
            }
        }

        public virtual decimal TotalWithTax
        {
            get
            {
                return PriceWithTax - DiscountAmountWithTax;
            }
        }

        public ICollection<Discount> Discounts { get; set; }

        #region ITaxable Members

        /// <summary>
        /// Tax category or type
        /// </summary>
        public string TaxType { get; set; }


        public decimal TaxTotal
        {
            get
            {
                return TotalWithTax - Total;
            }
        }

        public decimal TaxPercentRate { get; set; }

        #endregion
    }
}
