using System;
using System.Collections.Generic;

namespace Code_of_lab_2
{
    public class ShopManager
    {
        public Dictionary<string, Store> StoresList { protected set; get; } = new Dictionary<string, Store>();
        public Dictionary<string, Product> AllProductsList { protected set; get; } = new Dictionary<string, Product>();

        public string make_store(string Name, string Address)
        {
            Store store = new Store(Name, Address);
            if (!try_store_list_ID(store.storeID))
            {
                StoresList.Add(store.storeID, store);
            }
            
            return store.storeID;
        }
        public string make_product(string Name)
        {
            Product product = new Product(Name);
            if (!try_product_list_ID(product.productID))
            {
                AllProductsList.Add(product.productID, product);
            }
            
            return product.productID;
        }

        public bool try_store_list_ID(string ID)
        {
            return StoresList.ContainsKey(ID);
        }
        public bool try_product_list_ID(string ID)
        {
            return AllProductsList.ContainsKey(ID);
        }

        public Store cheap_product_store(string productID)
        {
            double minPrice = double.MaxValue;
            Store best_store = new Store();
            foreach (KeyValuePair<string, Store> keyValue in StoresList)
            {
                double currentCost = keyValue.Value.AllProductInStore[productID].price;
                if (currentCost < minPrice)
                {
                    minPrice = currentCost;
                    best_store = keyValue.Value;
                }
            }

            return best_store;
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
