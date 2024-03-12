namespace Supermarket
{
    internal class Product
    {
        private string productID;
        private string[][] productsList;
        private int quantity;
        public int ProductCode;
        public string ProductType;
        public double ProductVat;
        public double ProductPrice;

        public Product(string[] productSerial)
        {
            //values productID[0],quantity[1],ProductCode[2], ProductType[3], ProductVat[4], ProductPrice[5]
            productsList = new string[productSerial.Length][];

            //create an array of all product and save in productsList
            for (int i = 0; i < productSerial.Length; i++)
            {
                Console.WriteLine("Write below the number of quantity avaiable for this product: " + productSerial[i]);
                int quantity = Convert.ToInt32(Console.ReadLine());

                productsList[i] = productDescription(productSerial[i], quantity);
            }
        }

        public string[] productDescription(string productSerial, int quantity)
        {
            this.productID = productSerial;
            this.quantity = quantity;
            decodeProductID();

            string[] product = new string[6];
            product = [
                productID,
                Convert.ToString(quantity),
                Convert.ToString(ProductCode),
                ProductType,
                Convert.ToString(ProductVat),
                Convert.ToString(ProductPrice),
                ];
            return product;
        }

        private void decodeProductID()
        {
            ProductCode = Convert.ToInt32(productID.Substring(0, 2));
            ProductType = productName(productID.Substring(2, 2));
            ProductVat = Convert.ToDouble(productID.Substring(4, 2));
            ProductPrice = Convert.ToDouble(productID.Substring(6, 3)) / 100;
        }

        private string productName(string letter)
        {
            switch (letter)
            {
                case "OL":
                    return "Olio";

                case "CE":
                    return "Cereali";

                case "PA":
                    return "Pasta";

                case "TO":
                    return "Tonno";

                case "VI":
                    return "Vino";
            }

            return "Code not found";
        }

        public void printProduct()
        {
            Console.WriteLine(productsList[0][0]);
            Console.WriteLine(productsList[1][0]);
            Console.WriteLine(productsList[2][0]);

            for (int i = 0; i < productsList.Length; i++)
            {
                Console.WriteLine($"\nProduct id: {productsList[i][0]},\nQuantity: {productsList[i][1]},\nProduct code. {productsList[i][2]},\nProduct type: {productsList[i][3]},\nProduct vat: {productsList[i][4]},\nProduct price: {productsList[i][5]}.");
            }
        }

        public string[][] GetProductsList()
        {
            return productsList;
        }
    }

}