using System;

namespace BronsonHolland_CE07
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("1. Datafile1\n"
                + "2. Datafile2\n"
                + "3. Datafile3\n"
                + "4. Exit\n"
                + "Please choose a file: ");
            string input = Console.ReadLine().ToLower();

            switch (input)
            {
                case "1":
                case "datafile1":
                    {

                    }
                    break;
                case "2":
                case "datafile2":
                    {

                    }
                    break;
                case "3":
                case "datafile3":
                    {

                    }
                    break;
                case "4":
                case "exit":
                    {
                        return;
                    }
            }
        }
    }
}
