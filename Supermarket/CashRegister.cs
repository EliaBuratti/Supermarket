namespace Supermarket
{
    internal class CashRegister
    {
        private int MaxProducts = 3;
        private int MaxItem = 10;
        private string[][] ProductList;
        private string[] ProductDiscount;
        private string[] cart;
        private int[] itemAdded;

        public CashRegister(string[][] productList, string[] itemDiscount)
        {
            ProductList = productList;
            cart = new string[MaxProducts];
            itemAdded = new int[MaxProducts];
            ProductDiscount = itemDiscount;
        }

        public void addCart()
        {
            for (int i = 0; i < MaxProducts; i++)
            {
                Console.WriteLine("Write a code to add your product on the cart:");
                string inputCodeProduct = Console.ReadLine();

                Console.WriteLine("How much? (max 10)");
                int quantity = Convert.ToInt32(Console.ReadLine());

                if (CheckCode(inputCodeProduct, quantity))
                {
                    cart[i] = inputCodeProduct;
                    itemAdded[i] = quantity;
                }
                else
                {
                    --i;
                }
            }
        }

        private bool CheckCode(string codeID, int QuantityItem)
        {
            int indexProduct = FindCode(codeID).Item2;

            if (indexProduct == -1)
            {
                Console.WriteLine("Product not found");
                return false;
            }

            if (cart.Contains(codeID))
            {
                Console.WriteLine("You have added this product yet!");
                return false;
            }

            int quantityAvaiable = Convert.ToInt32(ProductList[indexProduct][1]);

            if (QuantityItem > MaxItem || quantityAvaiable < QuantityItem)
            {
                Console.WriteLine("You exceed maximum!");
                return false;
            }
            return true;
        }

        private (string[], int) FindCode(string code)
        {
            int indexProduct = -1;
            string[] codeFind = new string[1];

            for (int i = 0; i < ProductList.Length; i++)
            {
                if (code == ProductList[i][0])
                {
                    indexProduct = i;
                    codeFind = ProductList[indexProduct];
                    break;
                }
            }

            return (codeFind, indexProduct);
        }

        public void PrintTotal()
        {
            double totalShopping = 0;
            double totalDiscount = 0;
            double totalShoppingVat = 0;

            int i = 0;
            foreach (string item in cart)
            {
                string[] itemCart = FindCode(item).Item1;
                double SubTotal = itemAdded[i] * Convert.ToDouble(itemCart[5]);
                double Vat = (SubTotal * Convert.ToDouble(itemCart[4])) / 100;
                double totalCost = SubTotal + Vat;

                totalShoppingVat += totalCost;
                totalShopping += SubTotal; 


                if (ProductDiscount.Contains(itemCart[0]))
                {
                    totalDiscount += (double)itemAdded[i] * Convert.ToDouble(itemCart[5]);
                }

                Console.WriteLine(
                    $"\nProduct id: {itemCart[0]}\t\t" +
                    $"Quantity: {itemAdded[i]}\t\t" +
                    $"Product code: {itemCart[2]}\t\t" +
                    $"Product type: {itemCart[3]}\t\t" +
                    $"Product vat: {itemCart[4]}\t\t" +
                    $"Product price: {itemCart[5]}\t\t" +
                    $"Sub total: {SubTotal}\t\t" +
                    $"Vat : {Vat}\t\t" +
                    $"Total Price: {totalCost}.\n"
                );

                i++;
            }
            int HoursFree = (int)(totalShoppingVat - totalDiscount) / 15;

            Console.WriteLine("Total amount: " + totalShopping);
            Console.WriteLine("Discount: " + totalDiscount);
            Console.WriteLine("Total amount with Vat: " + (totalShoppingVat - totalDiscount));
            Console.WriteLine("For this shopping we offer to you: " + HoursFree + " hours, for your parking");
        }
    }
}
