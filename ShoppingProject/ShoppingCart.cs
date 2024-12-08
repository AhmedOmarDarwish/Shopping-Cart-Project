using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingProject
{
    internal  class ShoppingCart
    {
        public static List<Products> products = new List<Products>(); //User Shopping Cart
        public static Dictionary<string, double> itemPrice = new Dictionary<string, double>() //Stock
        {
            {"Laptop",13999.99 },
            {"Computer",15000 },
            {"TV",50000 },
            {"PS4",60000 },

        };
        static Stack<string> action = new Stack<string>();


        /// <summary>
        /// Add Item to Shopping Cart
        /// </summary>
        public static void AddItemCart()
        {
            Console.WriteLine("Available Items :");
            Console.WriteLine("-----------------");
            foreach (var item in itemPrice) {
                Console.WriteLine($"Item: {item.Key} Price: {item.Value}");
            }
            Console.Write("Please Enter Product Name:");
            string cartItem = Console.ReadLine().Trim().ToLower();
            AddListItem(cartItem);

        }
        public static void AddListItem(string productName)
        {
            string iteamName = null;
            foreach (var item in itemPrice)
            {
                if (item.Key.Trim().ToLower() == productName.Trim().ToLower())
                {
                    iteamName = item.Key;
                    products.Add(new Products(item.Key, item.Value));
                    action.Push($"Item {item.Key} Added to Cart");
                    Console.WriteLine("+++++++++++++++++++++++++++++");
                    Console.WriteLine("Item is added to your Cart :)");
                    Console.WriteLine("+++++++++++++++++++++++++++++");

                }
            }
            if (iteamName == null || iteamName == string.Empty)
            {
                Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
                Console.WriteLine("Item is Out of stock or not available :)");
                Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
                AddItemCart();

            }
        }

        /// <summary>
        /// View All Items in your Cart
        /// </summary>
        internal static void ViewCart()
        {
            //Check if Cart is Empty or not
            if (products.Any()) {
                Console.WriteLine("Cart Items :");
                Console.WriteLine("-----------------");
                foreach (var item in products) {
                    Console.WriteLine($"Item: {item.ProductName} Price: {item.ProductPrice}");
                }
            
            }
            else
            {
                Console.WriteLine("^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^");
                Console.WriteLine("Cart is Empty Please Add Items First :)");
                Console.WriteLine("^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^");
            }
        }
        /// <summary>
        /// Remove Special Item From cart
        /// </summary>
        internal static void RemoveItemCart()
        {
            ViewCart();
            if (products.Any())
            {
                Console.Write("Please Enter Product Name to Remove :");
                string cartItem = Console.ReadLine().Trim().ToLower();
                RemoveListItem(cartItem);
            }
        }

        public static void RemoveListItem(string productName)
        {
            string iteamName = null;
            foreach (var item in products)
            {
                if (item.ProductName.Trim().ToLower() == productName.Trim().ToLower())
                {
                    iteamName = item.ProductName;
                    products.Remove(item);
                    action.Push($"Item {item.ProductName} Removed from Cart");

                    Console.WriteLine("------------------");
                    Console.WriteLine("Item is Removed :)");
                    Console.WriteLine("------------------");
                    ViewCart();
                    break;

                }
            }
            if (iteamName == null || iteamName == string.Empty)
            {
                Console.WriteLine("!!!!!!!!!!!!!!!!!!!!");
                Console.WriteLine("Item does not exist in shopping cart :(");
                Console.WriteLine("!!!!!!!!!!!!!!!!!!!!");
                RemoveItemCart();
            }
        }

        /// <summary>
        /// Make your Order with CheckOut
        /// </summary>
        internal static void CheckOut()
        {
            if (products.Any())
            {
                double totalPrice = 0;
                ViewCart();
                foreach (var item in products)
                {
                    totalPrice += item.ProductPrice;
                }
                Console.WriteLine($"$$$$$$$$ Total Price to pay: {totalPrice}   $$$$$$$$");
                Console.WriteLine("Please Proceed to Payment, Thank you for Shopping :) ");
                products.Clear();
                action.Push("CheckOut");

            }
            else {
                Console.WriteLine("^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^");
                Console.WriteLine("Cart is Empty Please Add Items First :)");
                Console.WriteLine("^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^");
            }
        }

        /// <summary>
        /// Undo  last Mistake Action
        /// </summary>
        internal static void UndoAction()
        {
            if (action.Any())
            {
                string lastAction = action.Pop();
                Console.WriteLine($"Your Last Action is ({lastAction})");
                var actionArray = lastAction.Split();

                if (lastAction.Contains("Added"))
                {
                    RemoveListItem(actionArray[1]);
                }
                else if (lastAction.Contains("Removed"))
                {
                    AddListItem(actionArray[1]);

                }
                else
                {
                    Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
                    Console.WriteLine("Check Out Cannot be Undo, Please ask for Refund");
                    Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");

                }
            }
        }
    }



}    

