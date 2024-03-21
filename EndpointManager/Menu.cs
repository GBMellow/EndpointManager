using System;
using System.Collections.Generic;
using System.Security;
using System.Text.RegularExpressions;
using System.Transactions;
using System.Xml.Serialization;

using EndpointEntity;

namespace EndpointManager
{

    class Menu
    {
        static List<Endpoint> endpoints = [];
        static IEndpointRepositoryInterface repository = new InMemoryEndpointRepository();

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
            Console.WriteLine("5) Find an endpoint by Serial Number");
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
            string serialNumber = "";
            int meterModelId = 0;
            int meterNumber = 0;
            string firmwareVersion = "";
            int switchState = 0;

            bool verification = true;
            Console.WriteLine("Enter Endpoint Serial Number:");
            
            while (verification)
            {
                serialNumber = Console.ReadLine();
                if (serialNumber != null)
                {
                    if (Regex.IsMatch(serialNumber, @"^[0-9]+$")) //is necessary?
                    {
                        break;
                    }
                }
                Console.WriteLine("Enter a valid serial number");
            }

            Console.WriteLine("Enter Meter Model Id (16 for NSXI P2W, 17 for NSXI P3W, 18 for NSX2P3W, 19 for NSX3P4W):");
            
            while (verification)
            {
                if (int.TryParse(Console.ReadLine(), out meterModelId))
                {
                    break;
                }
                Console.WriteLine("Enter a valid number");
            }

            Console.WriteLine("Enter Meter Number:");
            while (verification)
            {
                if (int.TryParse(Console.ReadLine(), out meterNumber))
                {
                    break;
                }
                Console.WriteLine("Enter a valid number!");
            }

            Console.WriteLine("Enter Meter Firmware Version:");
            while (verification)
            { 
                firmwareVersion = Console.ReadLine();
                if (firmwareVersion != "" || firmwareVersion != null)
                {
                    break;
                }
                Console.WriteLine("Enter a valid firmware version");
            }

            Console.WriteLine("Enter Switch State (0 for Disconnected, 1 for Connected, 2 for Armed):");
            while (verification)
            { 
                if (int.TryParse(Console.ReadLine(), out switchState))
                {
                    break;
                }
                Console.WriteLine("Enter a valid number!");
            }

            try
            {
                repository.Create(new Endpoint(serialNumber, meterModelId, meterNumber, firmwareVersion, switchState));
                Console.WriteLine("Endpoint added successfully!");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        static void EditEndpoint()
        {
            try
            {
                Console.WriteLine("Enter Endpoint Serial Number to edit:");
                string serialNumber = Console.ReadLine();
                if (serialNumber == "" || serialNumber == null)
                {
                    Console.WriteLine("Enter a valid serial number");
                    return;
                }
                var endpoint = repository.GetBySerialNumber(serialNumber);
        
                Console.WriteLine($"Current Switch State: {endpoint.SwitchState}");
                Console.WriteLine("Enter new Switch State (0 for Disconnected, 1 for Connected, 2 for Armed):");
                if (!int.TryParse(Console.ReadLine(), out int switchState))
                {
                    Console.WriteLine("Enter a valid number!");
                    return;
                }
                repository.Update(serialNumber, switchState);
                Console.WriteLine("Switch State updated successfully!");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        static void DeleteEndpoint()
        {
            try
            {
                Console.WriteLine("Enter Endpoint Serial Number to delete:");
                string serialNumber = Console.ReadLine();
                if (serialNumber == "" || serialNumber == null)
                {
                    Console.WriteLine("Enter a valid serial number");
                    return;
                }

                var endpoint = repository.GetBySerialNumber(serialNumber);
                
                Console.WriteLine($"Are you sure you want to delete this endpoint? {endpoint}\n (Y/N)");
                if (Console.ReadLine().ToUpper() == "Y")
                {
                    if (repository.Delete(serialNumber))
                    {
                        Console.WriteLine("Endpoint deleted successfully!");
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }

        static void ListEndpoints()
        {
            try
            {
                var endpoints = repository.GetAll();
                Console.WriteLine("List of Endpoints:\n");
                foreach (var endpoint in endpoints)
                {
                    Console.WriteLine(endpoint);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        static void FindEndpoint()
        {
            try
            {
                Console.WriteLine("Enter Endpoint Serial Number to find:");
                string serialNumber = Console.ReadLine();
                if (serialNumber == "" || serialNumber == null)
                {
                    Console.WriteLine("Enter a valid serial number");
                    return;
                }

                var endpoint = repository.GetBySerialNumber(serialNumber);
                Console.WriteLine("Endpoint found:");
                Console.WriteLine(endpoint);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
