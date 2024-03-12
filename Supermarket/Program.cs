namespace Supermarket
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] products = ["05VI221330", "04TO100550", "03PA220110", "02CE220250", "01OL040130"];
            string[] productsDiscount = [products[0], products[2], products[3]];

            Product newProduct = new(products);

            /*Product[] newProducts = new Product[products.Length]; 
             * in this case i will create an array of all product code, and it possible to pick data with index example: newProducts[0].GetProductsList()
             * */
            CashRegister newTransaction = new(newProduct.GetProductsList(), productsDiscount);

            newProduct.printProduct();

            newTransaction.addCart();

            newTransaction.PrintTotal();

        }
    }
}
