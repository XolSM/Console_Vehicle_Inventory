using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace MidTermAtHome
{
    internal class Program
    {
        public static ArrayList GetVehicles(ref ArrayList vehicles)
        {
            //Data:
            string[] maker = { "Kia", "Audi", "Mercedez", "BMW", "Volkswagen" };
            string[] model = { "Sportage", "Q5", "EQS", "Q3", "Beetle" };
            string[] year = { "2017", "2020", "2023", "2002", "1980" };
            string[] mileage = { "14022", "10300", "4500", "191000", "245000" };
            string[] price = { "30599", "39259", "93200", "6599", "4750" };

            //Instantiate each vehicle object within the vehicles array
            //for (int i = 0; i < 4; i++)
            //{
            //    vehicles[i] = new Vehicle(maker[i], model[i], year[i], mileage[i], price[i]);
            //}
            //for (int i = 0; i < vehicles.Length; i++)
            //{
            //    while (maker[i] != null)
            //    {

            //SEVERAL OBJECTS WITH THE SAME NAME BUT DIFFERENT DATA INTO THE ARRAY LIST, NO ISSUES?
            for (int i = 0; i < maker.Length; i++)
            {
                Vehicle vehicle = new Vehicle(maker[i], model[i], year[i], mileage[i], price[i]);
                vehicles.Add(vehicle);
            }
            return vehicles;
        }

        
        public static int UserInput() //Get and validate user input between 1 to 4
        {
            int userSelection;
            bool restart = false;
            do
            {
                WriteLine("Hi, dear customer, please make a selection:\n" +
                "\t1-view all inventory;\n" +
                "\t2-select vehicle;\n" +
                "\t3-show cheapest vehicle;\n" +
                "\t4-exit.");
                userSelection = int.Parse(ReadLine());
                if (userSelection != 1 && userSelection != 2 && 
                    userSelection != 3 && userSelection != 4)
                {
                    WriteLine("Invalid selection, please input a number from 1 to 4)");
                    restart = true;
                }
                else
                {
                    return userSelection;
                }
            } while (restart);
            return userSelection;
        }

        public static void ViewInventory(string index, ArrayList vehicles) //Option 1 from menu
        {
            WriteLine("\tSure, here are all the vehicles we have:");
            WriteLine("No.\tMaker\tModel\tYear\tMileage\t  Price");
            if (index == "")
            {
                //for (int i = 0; i < 4; i++)
                //{
                //    Write((i + 1) + ".\t"); WriteLine(vehicles[i].ToString());
                //}
                for (int i = 0; i < vehicles.Count; i++)
                {
                    Vehicle vehicle = (Vehicle)vehicles[i];// Casting to vehicle
                    Write((i + 1) + ".\t"); WriteLine(vehicle.ToString());
                }
            }
            else
            {
                //int j = 1;
                for (int i = 0; i < vehicles.Count; i++)
                {
                    if (i == int.Parse(index) - 1)
                    {
                        continue;
                    }
                    else
                    {
                        Vehicle vehicle = (Vehicle)vehicles[i];// Casting to vehicle
                        Write((i + 1) + ".\t"); WriteLine(vehicle.ToString());
                    }
                    //j++;
                }
            }
            Write("\n");
        }

        public static void PrintVehicle(Vehicle vehicle) //Option 2 from menu - Step 2 Printing Vehicle
        {
            WriteLine("\tGood choice! Here is your order details:");
            Write("Order:\t"); WriteLine(vehicle.ToString());
            WriteLine("\t\t\t\tTax:\t  ${0:F0}", (int.Parse(vehicle.price) * vehicle.TaxRate()));
            WriteLine("\t\t\t\tTotal:\t  ${0:F0}",vehicle.TotalPrice());
            WriteLine("Thank you");
            Write("\n");
        }

        public static string SelectVehicle(ArrayList vehicles, string mainIndex) //Option 2 from menu - Step 1 Selecting Vehicle
        //Including user input validatation between 1 to 4
        {
            string index = "";
            WriteLine("\tSure, which car do you like");
            int userSelection = int.Parse(ReadLine());
            //for (int i = userSelection - 1; i < userSelection; i++)
            //{
            if (userSelection >= 0 && userSelection < vehicles.Count
                && mainIndex != userSelection.ToString())
            {
                Vehicle vehicle = (Vehicle)vehicles[userSelection-1];// Casting to vehicle
                index = userSelection.ToString();
                PrintVehicle(vehicle);
            }
            else if (mainIndex == userSelection.ToString())
            {
                bool restart;
                do
                {
                    WriteLine("\n\tSorry, you have already selected that vehicle\n" +
                                "\tplease select again or 0 to main menu", vehicles.Count);
                    int userSelection2 = int.Parse(ReadLine());
                    restart = false;
                    if (userSelection >= 0 && userSelection < vehicles.Count
                        && mainIndex != userSelection.ToString())
                    {
                        Vehicle vehicle = (Vehicle)vehicles[userSelection2-1];// Casting to vehicle
                        index = userSelection.ToString();
                        PrintVehicle(vehicle);
                    }
                    else
                    {
                        restart = true;
                    }
                } while (restart);
            }
            else if (userSelection <= 0)
            {
                index = "";
            }
            else
            {
                bool restart;
                do
                {
                    WriteLine("\n\tSorry, we only have {0} vehicles in stock,\n" +
                                "\tplease select again or 0 to main menu", vehicles.Count);
                    int userSelection2 = int.Parse(ReadLine());
                    restart = false;
                    if (userSelection2 >= 0 && userSelection2 < vehicles.Count)
                    {
                        Vehicle vehicle = (Vehicle)vehicles[userSelection2-1];// Casting to vehicle
                        index = userSelection.ToString();
                        PrintVehicle(vehicle);
                    }
                    else
                    {
                        restart = true;
                    }
                } while (restart);
            }
            return index;
        }

        public static void CheapestVehicle(ArrayList vehicles)
        {
            int index = 0;
            Vehicle vehicle = (Vehicle)vehicles[0];// Casting to vehicle
            int min = int.Parse(vehicle.price); 
            for (int i = 0; i < 4; i++)
            {
                Vehicle vehicleI = (Vehicle)vehicles[i];// Casting to vehicle
                if (int.Parse(vehicleI.price) <= min) 
                {
                    min = int.Parse(vehicleI.price); 
                    index = i;
                }
            }
            
            WriteLine("The cheapest vehicle in our inventory is the: \n" + vehicles[index].ToString() + "\n");
        }
        static void Main(string[] args)
        {

            //Vehicle[] vehicles = new Vehicle[100];
            ArrayList vehicles = new ArrayList();
            GetVehicles(ref vehicles);

            string index = "";
            bool restart = false;
            do
            {
            int userInput = UserInput();
                switch (userInput)
                {
                   case 1:
                       ViewInventory(index, vehicles);
                       restart = true;
                       break;
                   case 2:
                       index = SelectVehicle(vehicles, index);
                       restart = true;
                       break;
                   case 3:
                       CheapestVehicle(vehicles);
                       restart = true;
                       break;
                    case 4:
                        restart = false;
                        WriteLine("Press Enter");
                        break;
                }
            } while(restart);

                ReadKey();
        }
    }
}
