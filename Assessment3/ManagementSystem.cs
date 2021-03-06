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
                            staffLogin();
                            break;                          
                        case 2:
                            //GO MEMBER LOGIN                         
                            memberLogin();
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

        //LOG IN GUI FOR MEMBER
        private void memberLogin()
        {
            Console.Clear();
            //Check First & Last Name
            Console.WriteLine("First Name: ");
            string first = Console.ReadLine();
            Console.WriteLine("");
            Console.WriteLine("Last Name: ");
            string last = Console.ReadLine();
            Console.WriteLine("");
            Member checkMember = new Member(first, last);
            //Check if its in data
            checkMember = (Member)libraryData.Members.Find(checkMember);
            if (checkMember != null)
            {
                Console.WriteLine("Password: ");
                string pass = Console.ReadLine();
                Console.WriteLine("");
                if (pass == checkMember.Pin)
                {
                    Console.Clear();
                    memberMenu(checkMember);
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Incorrect Password, back to main menu...");
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("User not found, back to main menu...");
            }

        }

        private void memberMenu(Member member)
        {
            while (true)
            {        
                Console.WriteLine();
                Console.WriteLine("=========================Member Menu==========================");
                Console.WriteLine("Login as " + member.FirstName + " " + member.LastName);
                Console.WriteLine();
                Console.WriteLine("1. Browse all the movies");
                Console.WriteLine("2. Display all the information about a movie, given the title of the movie");
                Console.WriteLine("3. Borrow a movie DVD");
                Console.WriteLine("4. Return a movie DVD");
                Console.WriteLine("5. List current borrowing movies");
                Console.WriteLine("6. Display the top 3 movies rented by the members");
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
                            //Browse all movies
                            libraryData.displayAllMovie();
                            break;
                        case 2:
                            //Display all given title
                            libraryData.displayByTitle();
                            break;
                        case 3:
                            //Borrow a movie DVD
                            libraryData.BorrowDVD(member);
                            break;
                        case 4:
                            //Return a movie DVD    
                            libraryData.returnDVD(member);
                            break;
                        case 5:
                            //Show current borrowed DVD
                            libraryData.showBorrowed(member);
                            break;
                        case 6:
                            //Show top 3 borrowed
                            Console.Clear();
                            libraryData.top3();
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


        //LOG IN GUI FOR STAFF
        private void staffLogin()
        {
            Console.Clear();
            Console.WriteLine("Username: ");
            string username = Console.ReadLine();
            Console.WriteLine("");
            Console.WriteLine("Password: ");
            string password = Console.ReadLine();
            Console.WriteLine("");
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
                            libraryData.AddDvD();
                            break;
                        case 2:
                            //Remove DVD
                            libraryData.RemoveDvD();
                            break;
                        case 3:
                            //Register new member
                            libraryData.RegisterMember();
                            break;
                        case 4:
                            //Remove a member
                            LibraryData.removeMember();                    
                            break;
                        case 5:
                            //Find Member's phone number
                            libraryData.FindNumber();
                            break;
                        case 6:
                            //Display member currently borrowing a movie
                            libraryData.displayAllMovie();
                            Console.WriteLine("");                           
                            libraryData.displayBorrower();
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
