using System;
using System.Collections.Generic;

namespace Code_of_lab_2
{
    class Program
    {
        static void Main(string[] args)
        {
            
            ShopManager Shop_Manager = new ShopManager();

            string Sber_ID = Shop_Manager.make_store("Sber Market", "https://sbermarket.ru");
            string Yandex_ID = Shop_Manager.make_store("Yandex Lavka", "https://lavka.yandex");
            string Utkonos_ID = Shop_Manager.make_store("Utkonos", "https://www.utkonos.ru");
            
            // test for the number of stores. True if is 3.
            Console.WriteLine(Shop_Manager.StoresList.Count);
            /*
             * test for displaying data about stores
             * TRUE if console are
             * ID ... - Sber Market - https://sbermarket.ru
             * ID ... - Yandex Lavka - https://lavka.yandex
             * ID ... - Utkonos - https://www.utkonos.ru
            */
            foreach (KeyValuePair<string, Store> keyValue in Shop_Manager.StoresList)
            {
                Console.WriteLine(keyValue.Key + " - " + keyValue.Value.storeName + " - " + keyValue.Value.storeAddress);
            }

            string tomat_ID = Shop_Manager.make_product("tomatoes");
            string lemon_ID = Shop_Manager.make_product("lemons");
            string bread_ID = Shop_Manager.make_product("bread");;
            string milk_ID = Shop_Manager.make_product("milk");
            string tea_ID = Shop_Manager.make_product("tea");
            string coffee_ID = Shop_Manager.make_product("coffee");
            string water_ID = Shop_Manager.make_product("bottle of water");
            string juice_ID = Shop_Manager.make_product("juice");
            string fish_ID = Shop_Manager.make_product("fish");
            string honey_ID = Shop_Manager.make_product("honey");
            string nuts_ID = Shop_Manager.make_product("nuts");
            
            // test for the number of AllProductsList. True if is 20.
            Console.WriteLine(Shop_Manager.AllProductsList.Count);

            // Test true if answer is Sber Market https://sbermarket.ru
            Console.Write("Name of store {0}, ", Shop_Manager.StoresList[Sber_ID].storeName);
            Console.WriteLine("address {0}", Shop_Manager.StoresList[Sber_ID].storeAddress);
            
            Shop_Manager.StoresList[Sber_ID].add_product(Shop_Manager.AllProductsList[tomat_ID], 58, 153);
            Shop_Manager.StoresList[Sber_ID].add_product(Shop_Manager.AllProductsList[lemon_ID], 79, 126);
            Shop_Manager.StoresList[Sber_ID].add_product(Shop_Manager.AllProductsList[bread_ID], 159, 57);
            Shop_Manager.StoresList[Sber_ID].add_product(Shop_Manager.AllProductsList[milk_ID], 351, 49);
            Shop_Manager.StoresList[Sber_ID].add_product(Shop_Manager.AllProductsList[tea_ID], 58, 360);
            Shop_Manager.StoresList[Sber_ID].add_product(Shop_Manager.AllProductsList[coffee_ID], 456, 540);
            Shop_Manager.StoresList[Sber_ID].add_product(Shop_Manager.AllProductsList[water_ID], 820, 41);
            Shop_Manager.StoresList[Sber_ID].add_product(Shop_Manager.AllProductsList[juice_ID], 43, 63);
            Shop_Manager.StoresList[Sber_ID].add_product(Shop_Manager.AllProductsList[fish_ID], 17, 478);
            Shop_Manager.StoresList[Sber_ID].add_product(Shop_Manager.AllProductsList[honey_ID], 43, 270);
            Shop_Manager.StoresList[Sber_ID].add_product(Shop_Manager.AllProductsList[nuts_ID], 43, 231);

            Shop_Manager.StoresList[Yandex_ID].add_product(Shop_Manager.AllProductsList[tomat_ID], 142, 179);
            Shop_Manager.StoresList[Yandex_ID].add_product(Shop_Manager.AllProductsList[lemon_ID], 64, 135);
            Shop_Manager.StoresList[Yandex_ID].add_product(Shop_Manager.AllProductsList[bread_ID], 98, 39);
            Shop_Manager.StoresList[Yandex_ID].add_product(Shop_Manager.AllProductsList[milk_ID], 102, 68);
            Shop_Manager.StoresList[Yandex_ID].add_product(Shop_Manager.AllProductsList[tea_ID], 20, 238);
            Shop_Manager.StoresList[Yandex_ID].add_product(Shop_Manager.AllProductsList[coffee_ID], 48, 1380);
            Shop_Manager.StoresList[Yandex_ID].add_product(Shop_Manager.AllProductsList[water_ID], 327, 54);
            Shop_Manager.StoresList[Yandex_ID].add_product(Shop_Manager.AllProductsList[juice_ID], 81, 98);
            Shop_Manager.StoresList[Yandex_ID].add_product(Shop_Manager.AllProductsList[fish_ID], 32, 340);
            Shop_Manager.StoresList[Yandex_ID].add_product(Shop_Manager.AllProductsList[honey_ID], 81, 310);
            Shop_Manager.StoresList[Yandex_ID].add_product(Shop_Manager.AllProductsList[nuts_ID], 79, 176);

            Shop_Manager.StoresList[Utkonos_ID].add_product(Shop_Manager.AllProductsList[tomat_ID], 76, 149);
            Shop_Manager.StoresList[Utkonos_ID].add_product(Shop_Manager.AllProductsList[lemon_ID], 101, 97);
            Shop_Manager.StoresList[Utkonos_ID].add_product(Shop_Manager.AllProductsList[bread_ID], 231, 62);
            Shop_Manager.StoresList[Utkonos_ID].add_product(Shop_Manager.AllProductsList[milk_ID], 61, 130);
            Shop_Manager.StoresList[Utkonos_ID].add_product(Shop_Manager.AllProductsList[tea_ID], 19, 360);
            Shop_Manager.StoresList[Utkonos_ID].add_product(Shop_Manager.AllProductsList[coffee_ID], 256, 760);
            Shop_Manager.StoresList[Utkonos_ID].add_product(Shop_Manager.AllProductsList[water_ID], 915, 32);
            Shop_Manager.StoresList[Utkonos_ID].add_product(Shop_Manager.AllProductsList[juice_ID], 54, 124);
            Shop_Manager.StoresList[Utkonos_ID].add_product(Shop_Manager.AllProductsList[fish_ID], 9, 610);
            Shop_Manager.StoresList[Utkonos_ID].add_product(Shop_Manager.AllProductsList[honey_ID], 28, 299);
            Shop_Manager.StoresList[Utkonos_ID].add_product(Shop_Manager.AllProductsList[nuts_ID], 24, 315);

            Console.WriteLine("List of products in the Sber Market");
            foreach (KeyValuePair<string, ProductInStore> keyValue in Shop_Manager.StoresList[Sber_ID].AllProductInStore)
            {
                Console.WriteLine(keyValue.Key + " Product name: " + keyValue.Value.productName + " -- Quantity:  " + keyValue.Value.quantity + " Pricetag: " + keyValue.Value.price);
            }
            Console.WriteLine("List of products in the Yandex Lavka");
            foreach (KeyValuePair<string, ProductInStore> keyValue in Shop_Manager.StoresList[Yandex_ID].AllProductInStore)
            {
                Console.WriteLine(keyValue.Key + " Product name: " + keyValue.Value.productName + " -- Quantity:  " + keyValue.Value.quantity + " Pricetag: " + keyValue.Value.price);
            }
            Console.WriteLine("List of products in the Utkonos");
            foreach (KeyValuePair<string, ProductInStore> keyValue in Shop_Manager.StoresList[Utkonos_ID].AllProductInStore)
            {
                Console.WriteLine(keyValue.Key + " Product name: " + keyValue.Value.productName + " -- Quantity:  " + keyValue.Value.quantity + " Pricetag: " + keyValue.Value.price);
            }

            List<KeyValuePair<ProductInStore, int>> ProductsAvailableListInSberForBuy = new List<KeyValuePair<ProductInStore, int>>();
            ProductsAvailableListInSberForBuy = Shop_Manager.StoresList[Sber_ID].available_product(1000);
            foreach (KeyValuePair<ProductInStore, int> keyValue in ProductsAvailableListInSberForBuy)
            {
                Console.WriteLine("You can buy in Sber Market for 1000 rubles: " + keyValue.Value + " of " + keyValue.Key.productName);
            }
            List<KeyValuePair<ProductInStore, int>> ProductsAvailableListInYandexForBuy = new List<KeyValuePair<ProductInStore, int>>();
            ProductsAvailableListInYandexForBuy = Shop_Manager.StoresList[Yandex_ID].available_product(1000);
            foreach (KeyValuePair<ProductInStore, int> keyValue in ProductsAvailableListInYandexForBuy)
            {
                Console.WriteLine("You can buy in Yandex Lavka for 1000 rubles: " + keyValue.Value + " of " + keyValue.Key.productName);
            }
            List<KeyValuePair<ProductInStore, int>> ProductsAvailableListInUtkonosForBuy = new List<KeyValuePair<ProductInStore, int>>();
            ProductsAvailableListInUtkonosForBuy = Shop_Manager.StoresList[Utkonos_ID].available_product(1000);
            foreach (KeyValuePair<ProductInStore, int> keyValue in ProductsAvailableListInUtkonosForBuy)
            {
                Console.WriteLine("You can buy in Utkonos for 1000 rubles: " + keyValue.Value + " of " + keyValue.Key.productName);
            }
            
            Dictionary<string, int> MyCartForSber = new Dictionary<string, int>
                                             { {tea_ID, 1}, {bread_ID, 2}, {milk_ID, 1}, {lemon_ID, 2}, {water_ID, 5} };
            Dictionary<string, int> MyCartForYandex = new Dictionary<string, int>
                                             { {tea_ID, 1}, {bread_ID, 2}, {milk_ID, 1}, {lemon_ID, 2}, {water_ID, 5} };
            Dictionary<string, int> MyCartForUtkonos = new Dictionary<string, int>
                                             { {tea_ID, 1}, {bread_ID, 2}, {milk_ID, 1}, {lemon_ID, 2}, {water_ID, 5} };
            
            double amountCostSellSber = Shop_Manager.StoresList[Sber_ID].get_sell_amount_cost(MyCartForSber);
            double amountCostSellYandex = Shop_Manager.StoresList[Yandex_ID].get_sell_amount_cost(MyCartForYandex);
            double amountCostSellUtkonos = Shop_Manager.StoresList[Utkonos_ID].get_sell_amount_cost(MyCartForUtkonos);

            Console.WriteLine("Amount cost in Sber Market " + amountCostSellSber);
            Console.WriteLine("Amount cost in Yandex Lavka " + amountCostSellYandex);
            Console.WriteLine("Amount cost in Utkonos " + amountCostSellUtkonos);

            Console.WriteLine("Better to buy in " + Shop_Manager.best_store(MyCartForSber).storeName);

        }
    }
}
