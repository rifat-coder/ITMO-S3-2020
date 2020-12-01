using System;
using System.Collections.Generic;

namespace Code_of_lab_2
{
    public class Store
    {
        public string storeID      { private set; get; }
        public string storeName    { private set; get; }
        public string storeAddress { private set; get; }
        public Dictionary<string, ProductInStore> AllProductInStore { protected set; get; } = new Dictionary<string, ProductInStore>();

    public Store(string storeName, string storeAddress)
        {
            this.storeID = Guid.NewGuid().ToString();
            this.storeName = storeName;
            this.storeAddress = storeAddress;
        }
        public Store()
        { 
        }

        public void add_product(Product currentProdInList, int quantity, double price)
        {
            ProductInStore product = new ProductInStore(currentProdInList, quantity, price);
            AllProductInStore.Add(product.productID, product);
        }

        public void change_price(string ID, double newPrice)
        {
            if (newPrice >= 0)
            {
                AllProductInStore[ID].price = newPrice;
            }
            else
            {
                throw new Store_Exception("Price doesn't be less 0");
            }

        }
        public void change_quantity(string ID, int newQuantity)
        {
            if (newQuantity >= 0)
            {
                AllProductInStore[ID].quantity = newQuantity;
            }
            else
            {
                throw new Store_Exception("Quantity doesn't be less 0");
            }
            
        }

        public bool check_product_in_list(string ID)
        {
            return AllProductInStore.ContainsKey(ID);
        }

        public List<KeyValuePair<ProductInStore, int>> available_product(double money)
        {
            List<KeyValuePair<ProductInStore, int>> AvailableProduct = new List<KeyValuePair<ProductInStore, int>>();
            int quantity = 0;
            foreach (KeyValuePair<string, ProductInStore> keyValue in AllProductInStore)
            {
                if (keyValue.Value.price < money && money / keyValue.Value.price < keyValue.Value.quantity)
                {
                    quantity = (int)(money / keyValue.Value.price);
                    AvailableProduct.Add(new KeyValuePair<ProductInStore, int>(keyValue.Value, quantity));
                }
                else if (money / keyValue.Value.price > keyValue.Value.quantity)
                {
                    quantity = keyValue.Value.quantity;
                    AvailableProduct.Add(new KeyValuePair<ProductInStore, int>(keyValue.Value, quantity));
                }
                else
                {
                    AvailableProduct.Add(new KeyValuePair<ProductInStore, int>(keyValue.Value, 0));
                }
            }
            
            return AvailableProduct;
        }

        public double get_sell_amount_cost(Dictionary<string, int> Cart)
        {
            double amount_cost = 0;
            foreach (KeyValuePair<string, int> keyValue in Cart)
            {
                if (keyValue.Value <= AllProductInStore[keyValue.Key].quantity)
                {
                    amount_cost += keyValue.Value * AllProductInStore[keyValue.Key].price;
                }
                else
                {
                    throw new Store_Exception("Out of stock!");
                }
            }

            return amount_cost;
        }
    }
}
