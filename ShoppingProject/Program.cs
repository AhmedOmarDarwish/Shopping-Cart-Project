
namespace ShoppingProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello in Shopping Website");
            Console.WriteLine("=========================");
            while (true)
            {
                Console.WriteLine(
                "1. Add item to Cart\n" +
                "2. View Carts items\n" +
                "3. Remove item from Cart\n" +
                "4. CheckOut\n" +
                "5. Undo Last Action\n" +
                "6. Exit");
            string choice = Console.ReadLine();
            
                switch (choice) {
                    case "1":
                        ShoppingCart.AddItemCart();
                        break;
                    case "2":
                        ShoppingCart.ViewCart();
                        break;
                    case "3":
                        ShoppingCart.RemoveItemCart();
                        break;
                    case "4":
                        ShoppingCart.CheckOut();
                        break;
                    case "5":
                        ShoppingCart.UndoAction();
                        break;
                    case "6":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid Code Entered, Please try Again");
                        break;
                }
            }

        }


    }
}
