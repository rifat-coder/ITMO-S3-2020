using System;
using System.Collections.Generic;

namespace Code_of_lab_2
{
    public class Shopping_center
    {
        public List<Store> stores = new List<Store>();
        public Shopping_center()
        {
        }
        public void create_store(string ID, string Name, string Address)
        {
            Store store = new Store(ID, Name, Address);
            stores.Add(store);
        }
    }
}
