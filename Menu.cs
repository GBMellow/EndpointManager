using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace EndpointManager
{

    class Menu
    {

        static void Main(string[] args)
        {
            int choice;
            do
            {
                Console.WriteLine("Choose an option:");
                Console.WriteLine("1) Insert a new endpoint");
                Console.WriteLine("2) Edit an existing endpoint");
                Console.WriteLine("3) Delete an existing endpoint");
                Console.WriteLine("4) List all endpoints");
                Console.WriteLine("5) Find an endpoint by Endpoint Serial Number");
                Console.WriteLine("6) Exit");
                if (int.TryParse(Console.ReadLine(), out choice))
                {
                    switch (choice)
                    {
                        case 1:
                            InsertEndpoint();
                            break;
                        case 2:
                            EditEndpoint();
                            break;
                        case 3:
                            DeleteEndpoint();
                            break;
                        case 4:
                            ListEndpoints();
                            break;
                        case 5:
                            FindEndpoint();
                            break;
                        case 6:
                            Console.WriteLine("Are you sure you want to exit? (Y/N)");
                            if (Console.ReadLine().ToUpper() == "Y")
                                Environment.Exit(0);
                            break;
                        default:
                            Console.WriteLine("Invalid choice!");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid choice!");
                }
            } while (choice != 6);
        }

        static void InsertEndpoint()
        {


        }

        static void EditEndpoint()
        {

        }

        static void DeleteEndpoint()
        {

        }

        static void ListEndpoints()
        {

        }

        static void FindEndpoint()
        {

        }
    }
}
