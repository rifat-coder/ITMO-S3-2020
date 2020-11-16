using System;
using System.Collections.Generic;

namespace Code_of_lab_2
{
    public class ShopManager
    {
        public Dictionary<string, Store> StoresList = new Dictionary<string, Store>();
        public Dictionary<string, Product> AllProductsList = new Dictionary<string, Product>();

        public string make_store(string Name, string Address)
        {
            Store store = new Store(Name, Address);
            StoresList.Add(store.storeID, store);
            return store.storeID;
        }
        public string make_product(string Name)
        {
            Product product = new Product(Name);
            AllProductsList.Add(product.productID, product);
            return product.productID;
        }
        public bool try_product_list(string ID)
        {
            return AllProductsList.ContainsKey(ID);
        }

        public Store best_store(Dictionary<string, int> Cart)
        {
            double minAmountCost = double.MaxValue;
            Store best_store = new Store();
            foreach (KeyValuePair<string, Store> keyValue in StoresList)
            {
                double currentCost = keyValue.Value.get_sell_amount_cost(Cart);
                if (currentCost < minAmountCost)
                {
                    minAmountCost = currentCost;
                    best_store = keyValue.Value;
                }
            }

            return best_store;
        }

    }
}
