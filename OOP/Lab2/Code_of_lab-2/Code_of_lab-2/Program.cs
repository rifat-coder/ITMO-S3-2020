using System;
using System.Collections.Generic;

namespace Code_of_lab_2
{
    class Program
    {
        static void Main(string[] args)
        {
            // генерировать ID автоматическкий
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
            Big_Storage big_storage = new Big_Storage();
            big_storage.create_product("BMW_X3_Wh", "BMW X3");
            big_storage.create_product("VOL_XC60_R", "Volvo XC60");
            big_storage.create_product("TSL_MX_Wh", "Tesla Model X");
            big_storage.create_product("TSL_M3_R", "Tesla Model 3");
            big_storage.create_product("FER_812_Gr", "Ferrari 812");
            big_storage.create_product("AUD_Q3_B", "Audi Q3");
            big_storage.create_product("KIA_RIO_R", "Kia Rio");
            big_storage.create_product("SMR_F_Y", "Smart fortwo");
            big_storage.create_product("MRS_C_R", "Mercedes-Benz C");
            big_storage.create_product("HND_SOL_G", "Hyundai Solaris");
            big_storage.create_product("FRD_Tr_Bl", "Ford Transit");

        }
    }
}
