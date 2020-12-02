using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingBasket.Interface
{
    public interface IDiscountRule
    {
        string ProductId { get; set; }
        int Occurence { get; set; }
    }
}
