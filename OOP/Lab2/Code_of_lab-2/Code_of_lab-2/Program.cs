using System;
using System.Collections.Generic;

namespace Code_of_lab_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Shopping_center shopping_center = new Shopping_center();
            shopping_center.create_store("MSK_01", "Star Of The Capital", "Varshavskoe sh. 127");
            shopping_center.create_store("KZN_01", "Car Gorke", "Rodiny, 1B");
            shopping_center.create_store("MSK_02", "City Moscow", "Nikolskaya str. 10");
            shopping_center.create_store("SPB_01", "Olymp-Neva", "Ispolkomskaya, d. 15");
            Console.WriteLine(shopping_center.stores.Count);
            for (int i = 0; i < shopping_center.stores.Count; i++)
            {
                Store store = shopping_center.stores[i];
                Console.WriteLine("ID:{0}, Название:{1}, Улица:{2}", store.storeID, store.storeName, store.storeAddress);
            }
        }
    }
}
