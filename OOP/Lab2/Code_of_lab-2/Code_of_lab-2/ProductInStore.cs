using System;
namespace Code_of_lab_2
{
    public class ProductInStore : Product
    {
        public int quantity;
        public decimal price;

        public ProductInStore(string productName, string productID, int quantity, decimal price)
            : base(productName, productID)
        {
            this.quantity = quantity;
            this.price = price;
        }
    }
}
