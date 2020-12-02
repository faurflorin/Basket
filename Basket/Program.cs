using System;
using System.Text;
using ShoppingBasket.Controllers;
using ShoppingBasket.Repository;
using ShoppingBasket.Extension;
using System.Collections.Generic;

namespace Basket
{
	class Program
	{
		static void Main(string[] args)
		{
            Console.OutputEncoding = Encoding.UTF8; // to show pound sign in console
            try
            {
                StoreController stroreController = new StoreController();
                stroreController.CreateStore();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            Console.WriteLine("Type exit to finish");
            Console.WriteLine("Products in store: ");
            foreach (var product in Store.AllProducts())
            {
                Console.WriteLine(product.Name + " " + product.Price.ToUkFormat() + "/" + product.Unit);
            }
            Console.WriteLine();
            Console.WriteLine("To create a basket type the products you want to have it,separate by space.");
            Console.WriteLine("If you want a product several times, write it as many times as you want.");
            Console.WriteLine();

            while (true)
            {
                Console.Write("PriceCalculator ");
                string input = Console.ReadLine();
                if (input == "exit")
                {
                    return;
                }
                else
                {
                    Console.WriteLine();
                    ShoppingBasket.Model.Basket basket = BasketController.CreateBasket(input);
                    decimal totalCostBasket = BasketController.CalculateBasketCost(basket);
                    decimal discountApplyed = BasketController.CalculateDiscountApplyedCost(basket);

                    Console.WriteLine(String.Format("Subtotal: {0}", totalCostBasket.ToUkFormat()));
                    IList<string> discountMessages = BasketController.GetDiscountApplyedMessages(basket);
                    foreach (string message in discountMessages)
                    {
                        Console.WriteLine(message);
                    }
                    Console.WriteLine(String.Format("Total: {0}", (totalCostBasket - discountApplyed).ToUkFormat()));

                    Console.WriteLine();
                }
            }
        }
	}
}
