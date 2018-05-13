using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConnectedLayer.Models;
using ConnectedLayer;
using System.Configuration;
using System.Data;
using static System.Console;

namespace AutoLotCUIClient
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine("*****Simple Transaction Example*****\n");

            //A simple way to allow the tx to succeed or not.
            bool throwEx = true;

            Write("Do you want to throw an exception (Y or N): ");

            var userAnswer = ReadLine();

            if(userAnswer?.ToLower()=="n")
            {
                throwEx = false;
            }

            var dal = new IventoryDAL();
            dal.OpenConnection(@"Data Source=FRED\SQLEXPRESS;Integrated Security=SSPI;Initial Catalog=AutoLol");

            //Process customer 5 -enter the id for Homer Simpson in the next line
            dal.ProcessCreditRisk(throwEx, 11);
            WriteLine("Check CreditRisk table for results!\n");
            ReadLine();
        }

        private static void ShowInstructions()
        {
            WriteLine("I:Inserts a new car.\n");
            WriteLine("U:Updates an existing car.\n");
            WriteLine("D:Deletes an existing car.\n");
            WriteLine("L:Lists current iventory.\n");
            WriteLine("S:Shows these instructions.\n");
            WriteLine("P:Look up pet name.\n");
            WriteLine("Q:Quits program.\n");
        }

        private static void DisplayTable(DataTable dt)
        {
            //Print out the column names.
            for(int curCol=0;curCol<dt.Columns.Count;curCol++)
            {
                Write($"{dt.Columns[curCol].ColumnName}\t");
            }

            WriteLine("\n--------------------------------------\n");

            //Print the DataTable.
            for(int curRow=0;curRow<dt.Rows.Count;curRow++)
            {
                for(int curCol=0;curCol<dt.Columns.Count;curCol++)
                {
                    Write($"{dt.Rows[curRow][curCol]}\t");
                }
                WriteLine();
            }
        }

        private static void ListIventory(IventoryDAL ivDAL)
        {
            //Get the list of iventory.
            DataTable dt = ivDAL.GetAllIventoryAsDataTable();

            //Pass DataTable to helper function to display.
            DisplayTable(dt);
        }
        private static void ListIventoryViaList(IventoryDAL ivDAL)
        {
            //Get the list of iventory.
            List<NewCar> carList= ivDAL.GetAllIventoryAsList();
            WriteLine("CarId \tMake \tColor \tPetName ");

            foreach(NewCar car in carList)
            {
                WriteLine($"{car.CarId}\t {car.Make}\t{car.Color}\t{car.PetName}");
            }
        }

        private static void DeleteCar(IventoryDAL ivDAL)
        {
            //Get ID of car to delete.
            Write("Enter ID of Car to delete: ");
            int id = int.Parse(ReadLine() ?? "0");

            //Just in case you have a referential integrity violation!
            try
            {
                ivDAL.DeleteCar(id);
            }
            catch(Exception ex)
            {
                WriteLine(ex.Message);
            }
        }

        private static void InsertNewCar(IventoryDAL ivDAL)
        {
            Write("Enter Car ID:");
            var newCarId = int.Parse(ReadLine() ?? "0");

            Write("Enter Car Color: ");
            var newCarColor = ReadLine();

            Write("Enter Car Make: ");
            var newCarMake = ReadLine();

            Write("Enter Pet Name: ");
            var newCarPetName = ReadLine();

            Write("Enter Founder: ");
            var newCarFounderName = ReadLine();

            //Now pass to data access library.
            //ivDAL.InsertAuto(newCarId, newCarColor, newCarMake, newCarPetName, newCarFounderName);

            var newCar = new NewCar
            {
                CarId = newCarId,
                Color = newCarColor,
                Make = newCarMake,
                PetName = newCarPetName,
                Founder = newCarFounderName
            };

            ivDAL.InsertAuto(newCar);
        }

        //Implementing the UpdateCarPetName() method
        private static void UpdateCarPetName(IventoryDAL ivDAL)
        {
            //First get the user data.
            Write("Enter Car ID: ");
            var carID = int.Parse(ReadLine() ?? "0");
            Write("Enter New Pet Name: ");
            var newCarPetName = ReadLine();

            //Now pass to data access library.
            ivDAL.UpdateCarPetName(carID, newCarPetName);
        }

        //Implementing LookUpPetName()
        private static void LookUpPetName(IventoryDAL ivDAL)
        {
            //Get ID of car to look up.
            Write("Enter ID of Car to look up: ");
            int carId = int.Parse(ReadLine() ?? "0");
            WriteLine($"PetName of {carId} is {ivDAL.LookUpPetName(carId).TrimEnd()}.");
        }
    }
}
