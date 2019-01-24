using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpOgDB3layer
{
    public class Menu
    {
        Controller con = new Controller();
        public void Show()
        {
            bool running = true;
            do
            {
                ShowMenu();
                string choice = GetUserChoice();
                switch (choice)
                {
                    case "0":
                        running = false;
                        break;
                    case "1":
                        string petName = string.Empty;
                        string petType = string.Empty;
                        string petBreed = string.Empty;
                        string petDOB = string.Empty;
                        string petWeight = string.Empty;
                        string ownerID = string.Empty;
                        Console.WriteLine("----------ENTER DATA FOR PET----------");
                        Console.WriteLine("Enter PetName.");
                        petName = Console.ReadLine();
                        Console.WriteLine("Enter Pet Type:");
                        petType = Console.ReadLine();
                        Console.WriteLine("Enter Pet Breed:");
                        petBreed = Console.ReadLine();
                        Console.WriteLine("Enter Pet DOB. Ex 01-01-1991");
                        petDOB = Console.ReadLine();
                        Console.WriteLine("Enter Pet Weight:");
                        petWeight = Console.ReadLine();
                        Console.WriteLine("Enter OwnerID");
                        ownerID = Console.ReadLine();
                        con.InsertPet(petName, petType, petBreed, petDOB, petWeight, ownerID);

                        break;
                    case "2":
                        List<string> data = con.GetAllPets();
                        Console.WriteLine("PetID" + "\t" + "Petname" + "\t" + "PetType" + "\t" + "PetBreed" + "\t"
                        + "PetDOB" + "\t" + "PetWeight" + "\t" + "OwnerID");
                        foreach (string item in data)
                        {
                            Console.WriteLine(item);
                        }
                        break;
                    default:
                        Console.WriteLine("Ugyldigt valg.");
                        Console.ReadLine();
                        break;
                }
            } while (running);
        }
        private void ShowMenu()
        {
            Console.WriteLine("Database");
            Console.WriteLine();
            Console.WriteLine("1. Insert new Pet");
            Console.WriteLine("2. Show all Pets");
            Console.WriteLine("");
            Console.WriteLine("0. Exit");
        }
        private string GetUserChoice()
        {
            Console.WriteLine();
            Console.Write("Indtast dit valg: ");
            return Console.ReadLine();
        }
    }
}
