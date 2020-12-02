using System;
using System.Collections.Generic;
using System.Text;
using ShoppingBasket.Enums;

namespace ShoppingBasket.Interface
{
    public interface IProduct
    {
        string Id { get; }
        string Name { get; set; }
        decimal Price { get; set; }
        UnitType Unit { get; set; }
    }
}
