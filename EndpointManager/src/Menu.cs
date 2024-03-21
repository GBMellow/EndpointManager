using System;
using System.Collections.Generic;
using System.Xml.Serialization;

using EndpointEntity;

namespace EndpointManager
{

    class Program
    {
        static List<Endpoint> endpoints = [];

        static void Main(string[] args)
        {
            bool showMenu = true;
            while (showMenu)
            {
                 showMenu = MainMenu();
            }
        }

        private static bool MainMenu()
        {
            int option;

            Console.WriteLine("Choose an option:");
            Console.WriteLine("1) Insert a new endpoint");
            Console.WriteLine("2) Edit an existing endpoint");
            Console.WriteLine("3) Delete an existing endpoint");
            Console.WriteLine("4) List all endpoints");
            Console.WriteLine("5) Find an endpoint by Endpoint Serial Number");
            Console.WriteLine("6) Exit");
            
            if (int.TryParse(Console.ReadLine(), out option))
            {
                switch (option)
                {
                    case 1:
                        InsertEndpoint();
                        return true;
                    case 2:
                        EditEndpoint();
                        return true;
                    case 3:
                        DeleteEndpoint();
                        return true;
                    case 4:
                        ListEndpoints();
                        return true;
                    case 5:
                        FindEndpoint();
                        return true;
                    case 6:
                        Console.WriteLine("Are you sure you want to exit? (Y/N)");
                        if (Console.ReadLine().ToUpper() == "Y")
                            Environment.Exit(0);
                            return false;
                    default:
                        Console.WriteLine("Invalid option!\n");
                        return true;
                }
            }
            else
            {
                Console.WriteLine("Invalid option!\n");
                return true;
            }
        }

        static void InsertEndpoint()
        {
            Console.WriteLine("Enter Endpoint Serial Number:");
            string serialNumber = Console.ReadLine();

            if (endpoints.Exists(ep => ep.SerialNumber == serialNumber))
            {
                Console.WriteLine("Error: Endpoint with the same serial number already exists.");
                return;
            }

            Console.WriteLine("Enter Meter Model Id (16 for NSXI P2W, 17 for NSXI P3W, 18 for NSX2P3W, 19 for NSX3P4W):");
            if (!int.TryParse(Console.ReadLine(), out int meterModelId))
            {
                Console.WriteLine("Enter a valid number");
                return;
            }

            Console.WriteLine("Enter Meter Number:");
            if (!int.TryParse(Console.ReadLine(), out int meterNumber))
            {
                Console.WriteLine("Invalid Meter Number!");
                return;
            }

            Console.WriteLine("Enter Meter Firmware Version:");
            string firmwareVersion = Console.ReadLine();

            Console.WriteLine("Enter Switch State (0 for Disconnected, 1 for Connected, 2 for Armed):");
            if (!int.TryParse(Console.ReadLine(), out int switchState) || switchState < 0 || switchState > 2)
            {
                Console.WriteLine("Invalid Switch State!");
                return;
            }
            try
            {
                endpoints.Add(new Endpoint(serialNumber, meterModelId, meterNumber, firmwareVersion, switchState));
                Console.WriteLine("Endpoint added successfully!");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        static void EditEndpoint()
        {
            Console.WriteLine("Enter Endpoint Serial Number to edit:");
            string serialNumber = Console.ReadLine();
            var endpoint = endpoints.Find(ep => ep.SerialNumber == serialNumber);
            if (endpoint == null)
            {
                Console.WriteLine("Error: Endpoint not found!");
                return;
            }

            Console.WriteLine($"Current Switch State: {endpoint.SwitchState}");
            Console.WriteLine("Enter new Switch State (0 for Disconnected, 1 for Connected, 2 for Armed):");
            if (!int.TryParse(Console.ReadLine(), out int switchState) || switchState < 0 || switchState > 2)
            {
                Console.WriteLine("Invalid Switch State!");
                return;
            }

            endpoint.SwitchState = switchState;
            Console.WriteLine("Switch State updated successfully!");
        }

        static void DeleteEndpoint()
        {
            Console.WriteLine("Enter Endpoint Serial Number to delete:");
            string serialNumber = Console.ReadLine();
            var endpoint = endpoints.Find(ep => ep.SerialNumber == serialNumber);
            if (endpoint == null)
            {
                Console.WriteLine("Error: Endpoint not found!");
                return;
            }

            Console.WriteLine($"Are you sure you want to delete endpoint with serial number {serialNumber}? (Y/N)");
            if (Console.ReadLine().ToUpper() == "Y")
            {
                endpoints.Remove(endpoint);
                Console.WriteLine("Endpoint deleted successfully!");
            }
        }

        static void ListEndpoints()
        {
            if (endpoints.Count == 0)
            {
                Console.WriteLine("No endpoints found!");
                return;
            }

            Console.WriteLine("List of Endpoints:");
            foreach (var endpoint in endpoints)
            {
                Console.WriteLine(endpoint);
            }
        }

        static void FindEndpoint()
        {
            Console.WriteLine("Enter Endpoint Serial Number to find:");
            string serialNumber = Console.ReadLine();
            var endpoint = endpoints.Find(ep => ep.SerialNumber == serialNumber);
            if (endpoint == null)
            {
                Console.WriteLine("Error: Endpoint not found!");
                return;
            }

            Console.WriteLine("Endpoint found:");
            Console.WriteLine(endpoint);
        }
    }
}
