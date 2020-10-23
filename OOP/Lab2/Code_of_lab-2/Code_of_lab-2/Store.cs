using System;
using System.Collections.Generic;

namespace Code_of_lab_2
{
    public class Store
    {
        public string storeID;
        public string storeName;
        public string storeAddress;
        public List<ProductInStore> storeStorage = new List<ProductInStore>();
        public Store(string storeID, string storeName, string storeAddress)
        {
            this.storeID = storeID;
            this.storeName = storeName;
            this.storeAddress = storeAddress;
        }
    }
}
