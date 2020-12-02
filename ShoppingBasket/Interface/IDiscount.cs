using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingBasket.Interface
{
    public interface IDiscount
    {
        string ProductId { get; }
        decimal Value { get; set; }
        DateTime? ValidFrom { get; set; }
        DateTime? ValidTo { get; set; }

        bool IsActive { get; }

        decimal CalculateDiscount(IProduct product, out string message);
    }

    public interface IConditionalDiscount
    {
        IDiscountRule Rule { get; set; }
    }
}
