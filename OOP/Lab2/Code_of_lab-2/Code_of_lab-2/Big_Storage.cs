using System;
using System.Collections.Generic;

namespace Code_of_lab_2
{
    public class Big_Storage
    {
        
        public Dictionary<string, string> AllProductsList = new Dictionary<string, string>();
        public Big_Storage()
        {
        }
        public void make_product(string Name)
        {
            Product product = new Product(Name);
            AllProductsList.Add(product.productID, product.productName);
        }
        public bool check_product_in_list(string ID)
        {
            return AllProductsList.ContainsKey(ID);
        }
    }
}
