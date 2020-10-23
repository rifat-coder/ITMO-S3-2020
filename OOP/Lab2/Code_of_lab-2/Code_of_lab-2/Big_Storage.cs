using System;
using System.Collections.Generic;

namespace Code_of_lab_2
{
    public class Big_Storage
    {
        public List<Product> allproducts = new List<Product>();
        public Big_Storage()
        {
        }
        public void create_product(string ID, string Name)
        {
            Product product = new Product(ID, Name);
            allproducts.Add(product);
        }
    }
}
