using System;
using System.Collections.Generic;
using System.IO;
using Zadanie1;
using Zadanie2;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            DataContext dataContext = new DataContext();
            JsonSerializer jsonSerializer = new JsonSerializer();
            CustomSerializer csvSerializer = new CustomSerializer();

            int wybor = 0;
            string path = "";
            while (wybor != 8)
            {
                printMenu();
                Console.WriteLine("Podaj numer opcji");
                wybor = Console.Read() - '0';
                Console.ReadLine();
                switch (wybor)
                {
                    case 1:
                        Console.WriteLine("podaj ścierzkę do pliku");
                        path = Console.ReadLine();
                        try
                        {
                            dataContext = jsonSerializer.DeserializeToDataContext(path);
                        }
                        catch (FileNotFoundException)
                        {
                            Console.WriteLine("Nie odnaleziono pliku");
                            break;
                        }
                        Console.WriteLine("Import json done");
                        break;
                    case 2:
                        Console.WriteLine("podaj ścierzkę do pliku");
                        path = Console.ReadLine();
                        jsonSerializer.Serialize(dataContext, path);
                        Console.WriteLine("Export json done");
                        break;
                    case 3:
                        Console.WriteLine("podaj ścierzkę do pliku");
                        path = Console.ReadLine();
                        try
                        {
                            dataContext = csvSerializer.Deserialize(path);
                        }
                        catch (FileNotFoundException)
                        {
                            Console.WriteLine("Nie odnaleziono pliku");
                            break;
                        }
                        Console.WriteLine("Import csv done");
                        break;
                    case 4:
                        Console.WriteLine("podaj ścierzkę do pliku");
                        path = Console.ReadLine();
                        csvSerializer.Serialize(dataContext, path);
                        Console.WriteLine("Export csv done");
                        break;
                    case 5:

                        Console.WriteLine();
                        Console.WriteLine(printAsString("Books", dataContext.books));
                        Console.WriteLine();
                        Console.WriteLine(printAsString("BookStates", dataContext.bookStates));
                        Console.WriteLine();
                        Console.WriteLine(printAsString("Clients", dataContext.clients));
                        Console.WriteLine();
                        Console.WriteLine(printAsString("Events", dataContext.events));
                        break;
                    case 6:
                        dataContext = ConstantDataFiller.Fill();
                        break;
                    case 7:
                        dataContext = new DataContext();
                        break;
                    case 8:
                        break;
                    default:
                        break;

                }
                Console.WriteLine("nacisnij enter aby kontynuować");
                Console.ReadKey();
                Console.Clear();

            }

        }

        private static string printAsString<T>(String listName, IEnumerable<T> list)
        {
            string line = listName + ": \n";
            foreach (T d in list)
            {
                line += d.ToString() + "\n";
            }
            return line;
        }

        private static void printMenu()
        {
            Console.WriteLine("Witaj w programie (zad2) Import/Export. Co chcesz zrobić ?");
            Console.WriteLine("1. Import JSON");
            Console.WriteLine("2. Export JSON");
            Console.WriteLine("3. Import CSV(Own Serialization)");
            Console.WriteLine("4. Export CSV(Own Serialization)");
            Console.WriteLine("5. Wyswietl");
            Console.WriteLine("6. Wypełnij dataContext stałymi");
            Console.WriteLine("7. Wyczyść dataContext");
            Console.WriteLine("8. Wyjscie");
            Console.WriteLine("---------------------------");
        }
    }
}
