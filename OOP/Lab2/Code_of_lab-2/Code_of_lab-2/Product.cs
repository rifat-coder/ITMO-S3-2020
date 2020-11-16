using System;
namespace Code_of_lab_2
{
    public class Product
    {
        public string productID   { protected set; get; }
        public string productName { private set; get; }
        
        public Product(string productName)
        {
            this.productID = Guid.NewGuid().ToString();
            this.productName = productName;
        }
        
    }
}
