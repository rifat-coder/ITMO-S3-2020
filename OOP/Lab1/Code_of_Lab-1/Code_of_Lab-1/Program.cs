using System;

namespace Code_of_Lab_1
{
    class Cars
    {
        private int wheels;

    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Console.WriteLine("Test Test Code!!");
            int cntu = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i <= cntu; i++) {
                if (i % 2 == 0)
                {
                    Console.WriteLine("Number " + i + "is even.");
                } else
                {
                    Console.WriteLine("Number " + i + "is odd");
                }
                
            }
            double num1 = 11.7, num2 = 23.6;
            Console.WriteLine(num1 + " + " + num2 + " = " + (num1 + num2));

        }
    }
}
