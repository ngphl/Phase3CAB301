using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment3
{
    internal class ManagementSystem
    {
        private Database libraryData;
        public Database LibraryData { get { return libraryData; } set { libraryData = value; } }

        public ManagementSystem(MovieCollection movies, MemberCollection members)
        {
            libraryData = new Database(movies,members);
            
        }

        //START OF THE MENU
        public void startUp()
        {
            Console.WriteLine("=============================================================");
            Console.WriteLine("Welcome to Community Library Movie DVD Management System");
            Console.WriteLine("=============================================================");                  
            mainMenu();           
        }

        //MAIN MENU
        private void mainMenu()
        {           
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("=========================Main Menu==========================");
                Console.WriteLine();
                Console.WriteLine("1.Staff Login");
                Console.WriteLine("2.Member Login");
                Console.WriteLine("0.Exit");
                Console.WriteLine();
                Console.WriteLine("Enter your choice ==> (1/2/0)");

                //CHECK IF INPUT IS AN INTEGER
                string input = Console.ReadLine();
                bool option = int.TryParse(input, out int number);
                //IF ITS A NUMBER
                if (option)
                {
                    switch (number)
                    {
                        case 1:
                            //GO STAFF LOGIN
                            Console.Clear();
                            staffLogin();
                            break;                          
                        case 2:
                            //GO MEMBER LOGIN
                            Console.Clear();
                            Console.WriteLine("Member Login Success");                           
                            break;
                        case 0:
                            Environment.Exit(0);                        
                            break;
                        default:
                            Console.Clear();
                            Console.WriteLine("Option not available, try again.");
                            break;
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Option not available, try again.");
                }
            }
        }

        //LOG IN GUI FOR STAFF
        private void staffLogin()
        {
            Console.WriteLine("Username: ");
            string username = Console.ReadLine();
            Console.WriteLine("Password: ");
            string password = Console.ReadLine();
            if (username == "staff" && password == "today123")
            {
                Console.Clear();
                Console.WriteLine("Staff Login success");
                staffMenu();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Login Failed, back to main menu.");
            }
        }
        //MENU FOR STAFF
        public void staffMenu()
        {
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("=========================Staff Menu==========================");
                Console.WriteLine();
                Console.WriteLine("1. Add new DVDs of a new movie to the system");
                Console.WriteLine("2. Remove DVDs of a movie from the system");
                Console.WriteLine("3. Register a new member with the system");
                Console.WriteLine("4. Remove a registered member from the system");
                Console.WriteLine("5. Display a member's contact phone number, given the member's name");
                Console.WriteLine("6. Display all members who are currently renting a particular movie");
                Console.WriteLine("0. Return to the main menu");
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("Enter your choice ==> (1/2/3/4/5/6/0)");
                //CHECK IF INPUT IS AN INTEGER
                string input = Console.ReadLine();
                bool option = int.TryParse(input, out int number);
                //IF ITS A NUMBER                
                if (option)
                {
                    switch (number)
                    { 
                        case 1:
                            //Add new DVD
                            Console.Clear();
                            LibraryData.AddDvD();
                            break;
                        case 2:
                            //Remove DVD
                            Console.Clear();
                            LibraryData.RemoveDvD();
                            break;
                        case 3:
                            //Register new member
                            Console.Clear();
                            Console.WriteLine("Register new member");
                            break;
                        case 4:
                            Console.Clear();
                            Console.WriteLine("Remove register member");
                            break;
                        case 5:
                            Console.Clear();
                            Console.WriteLine("Display member info");
                            break;
                        case 6:
                            Console.Clear();
                            Console.WriteLine("Display all current rent member");
                            break;
                        case 0:
                            Console.Clear();
                            mainMenu();
                            break;
                        default:
                            Console.Clear();
                            Console.WriteLine("Option not available, try again.");
                            break;
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Option not available, try again.");
                }
            }
        }
    }
}
