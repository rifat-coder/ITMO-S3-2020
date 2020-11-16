using System;
namespace Code_of_lab_2
{
    public class ProductInStore : Product
    {
        public int    quantity { get; set; }
        public double price    { get; set; }

        public ProductInStore(Product curentProduct, int quantity, double price)
            : base(curentProduct.productName)
        {
            productID = curentProduct.productID;
            this.quantity = quantity;
            this.price = price;
        }
    }
}
