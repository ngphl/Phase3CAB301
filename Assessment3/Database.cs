using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment3
{
    internal class Database
    {
        private MovieCollection movies;
        private MemberCollection members;

        public MovieCollection Movies { get { return movies; } }
        public MemberCollection Members { get { return members; } }
        public Database(MovieCollection movies, MemberCollection members) { this.movies = movies; this.members = members; }


        //Helper function
        public void displayAllMember()
        {
            Console.WriteLine("-------------All Member Detail-------------");
            Console.WriteLine(Members.ToString());
            Console.WriteLine("-------------------------------------------");
        }

        //Helper function
        private void displayMemberInfo(Member member)
        {
            Console.WriteLine("-------------Member Detail-------------");
            Console.WriteLine("First Name: " + member.FirstName);
            Console.WriteLine("Last Name: " + member.LastName);
            Console.WriteLine("Phone Number: " + member.ContactNumber);
            Console.WriteLine("PIN: " + member.Pin);
            Console.WriteLine("---------------------------------------");
        }


        //Display Info of a single movie 
        private void displayInfo(Movie movie)
        {
            Console.WriteLine("-------------Movie Detail-------------");
            Console.WriteLine("Title: " + movie.Title);
            Console.WriteLine("Genre: " + movie.Genre);
            Console.WriteLine("Classification: " + movie.Classification);
            Console.WriteLine("Duration: " + movie.Duration);
            Console.WriteLine("Available Copies: " + movie.AvailableCopies);
            Console.WriteLine("Total Copies: " + movie.TotalCopies);
            Console.WriteLine("---------------------------------------");
        }

        //Find and display movie by title
        public void displayByTitle()
        {
            Console.Clear();
            Console.WriteLine("Movie Name?");
            string title = Console.ReadLine();
            Movie movie = (Movie)movies.Search(title);
            if (movie != null)
            {
                displayInfo(movie);
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Movie not found");
            }

        }

        //Display all Movie info
        public void displayAllMovie()
        {
            IMovie[] availableMovie = movies.ToArray();
            Console.Clear();
            Console.WriteLine("All Movie in Library:");
            foreach (Movie movie in availableMovie)
            {
                displayInfo(movie);
            }
        }
        //Remove DvDs function
        public void RemoveDvD()
        {
            Console.Clear();
            //Choose movie title 
            Console.WriteLine("Title of Movie: ");
            string title = Console.ReadLine();
            Movie movie = (Movie)movies.Search(title);
            if (movie != null)
            {
                //CHOOSE AMOUNT TO REMOVE
                Console.Clear();
                displayInfo(movie);
                Console.WriteLine("NOTE: Can only remove amount up to available copies in library");
                while (true)
                {
                    Console.WriteLine();
                    Console.WriteLine("Number of DVD to remove:");
                    string toRemove = Console.ReadLine();
                    bool option = int.TryParse(toRemove, out int numberToRemove);
                    if (option)
                    {
                        //If number to remove exceed available copies in library
                        if (numberToRemove > movie.AvailableCopies)
                        {
                            //Do nothing
                            Console.Clear();
                            Console.WriteLine("Number of DvD to remove exceed number of available copies (" + movie.AvailableCopies + "), try again...");
                        }
                        else if (numberToRemove < 0)
                        {
                            Console.Clear();
                            Console.WriteLine("Do not enter negative number, try again...");
                        }
                        else //Number of DvD to remove Does not exceed available copies (CAN ONLY REMOVE THOSE IN LIBRARY)
                        {
                            Console.Clear();
                            movie.AvailableCopies -= numberToRemove;
                            movie.TotalCopies -= numberToRemove;
                            Console.WriteLine("Removed " + numberToRemove + " DvD from " + movie.Title + "");
                            if (movie.TotalCopies == 0)
                            {
                                movies.Delete(movie);
                                Console.WriteLine("No more copies available, remove the movie " + movie.Title + " from library...");
                            }
                            else
                            {
                                Console.WriteLine("Update!");
                                displayInfo(movie);
                            }
                            break;
                        }
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Invalid input, try again...");
                    }
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Movie not found, return to menu...");
            }
        }

        //Add DvDs function
        public void AddDvD()
        {
            Console.Clear();
            //Choose movie title 
            Console.WriteLine("Title of Movie: ");
            string title = Console.ReadLine();
            //Variable to check if any selection is invalid (e.g duration must be integer)
            bool option = true;
            while (option)
            {
                //CHOOSING GENRE - START
                Console.WriteLine();
                Console.WriteLine("Select Genre by Number: ");
                Console.WriteLine("1. Action");
                Console.WriteLine("2. Comedy");
                Console.WriteLine("3. History");
                Console.WriteLine("4. Drama");
                Console.WriteLine("5. Western");
                string genre = Console.ReadLine();
                option = int.TryParse(genre, out int genreInt);
                MovieGenre genreChoose;
                if (genreInt == 1)
                {
                    genreChoose = MovieGenre.Action;
                }
                else if (genreInt == 2)
                {
                    genreChoose = MovieGenre.Comedy;
                }
                else if (genreInt == 3)
                {
                    genreChoose = MovieGenre.History;
                }
                else if (genreInt == 4)
                {
                    genreChoose = MovieGenre.Drama;
                }
                else if (genreInt == 5)
                {
                    genreChoose = MovieGenre.Western;
                }
                else
                {
                    option = false;
                    break;
                }
                //CHOOSING GENRE - END
                //CHOOSING CLASSIFICATION - START
                Console.WriteLine();
                Console.WriteLine("Select Movie Classification by Number:");
                Console.WriteLine("1. General (G)");
                Console.WriteLine("2. Parental Guidance (PG)");
                Console.WriteLine("3. Mature (M)");
                Console.WriteLine("4. Mature Accompanied (MA15+)");
                string classify = Console.ReadLine();
                option = int.TryParse(classify, out int classifyInt);
                MovieClassification classification;
                if (classifyInt == 1)
                {
                    classification = MovieClassification.G;
                }
                else if (classifyInt == 2)
                {
                    classification = MovieClassification.PG;
                }
                else if (classifyInt == 3)
                {
                    classification = MovieClassification.M;
                }
                else if (classifyInt == 4)
                {
                    classification = MovieClassification.M15Plus;
                }
                else
                {
                    option = false;
                    break;
                }
                //CHOOSING CLASSIFICATION - END
                //CHOOSING DURATION - START
                Console.WriteLine();
                Console.WriteLine("Duration of Movie:");
                string duration = Console.ReadLine();
                option = int.TryParse(duration, out int durationInt);
                if (!option)
                {
                    break;
                }
                //CHOOSING DURATION - END
                //CHOOSE NUMBER OF DVD TO ADD - START
                Console.WriteLine();
                Console.WriteLine("Number of DVD to add:");
                string toAdd = Console.ReadLine();
                option = int.TryParse(toAdd, out int numberToAdd);
                if (!option)
                {
                    break;
                }
                //CHOOSE NUMBER OF DVD TO ADD - END

                while (true)
                {
                    //OFFICIALLY ADD IN THE MOVIE 
                    Console.Clear();
                    Console.WriteLine("Verify Movie Detail");
                    Console.WriteLine("Title: " + title + "");
                    Console.WriteLine("Genre: " + genreChoose + "");
                    Console.WriteLine("Classification: " + classification + "");
                    Console.WriteLine("Duration: " + durationInt + "");
                    Console.WriteLine("Number of DvD: " + numberToAdd + "");
                    Console.WriteLine("\nAdd this movie in? (Y/N)");
                    string yesNo = Console.ReadLine();
                    yesNo = yesNo.ToUpper();
                    if (yesNo == "Y")
                    {
                        //Add
                        Movie movie = new Movie(title, genreChoose, classification, durationInt, numberToAdd);
                        bool added = movies.Insert(movie);
                        if (added)
                        {
                            Console.Clear();
                            Console.WriteLine("Movie successfully added, back to menu...");
                            displayInfo(movie);
                            break;
                        }
                        else
                        {
                            movie = (Movie)movies.Search(title);
                            movie.TotalCopies += numberToAdd;
                            movie.AvailableCopies += numberToAdd;
                            Console.Clear();
                            Console.WriteLine("Movies already in library, added " + numberToAdd + " DvD instead");
                            Console.WriteLine("Update!");
                            displayInfo(movie);
                            break;
                        }
                    }
                    else if (yesNo == "N")
                    {
                        Console.Clear();
                        Console.WriteLine("Back to menu...");
                        break;
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Invalid option, try again");
                    }
                }
                break;
            }
            if (!option)
            {
                Console.Clear();
                Console.WriteLine("Invalid selection, back to menu...");
            }
        }

        //Register a member 
        public void RegisterMember()
        {
            //ASK FOR FIRST & LAST NAME
            Console.Clear();
            Console.WriteLine("NOTE: Name is Case sensitive (e.g John is different from john), please add with caution.");
            Console.WriteLine("First Name?");
            string first = Console.ReadLine();
            Console.WriteLine("Last Name?");
            string last = Console.ReadLine();
            Member onlyName = new Member(first, last);
            //CHECK IF FIRST & LAST NAME ALREADY EXIST
            if (Members.Search(onlyName))
            {
                Console.Clear();
                Console.WriteLine("There is already member with the same name, back to menu...");
            }
            else
            {
                //ASK FOR PHONE NUMBER
                Console.WriteLine("Phone Number?");
                string number = Console.ReadLine();
                bool validNumber = IMember.IsValidContactNumber(number);
                if (validNumber)
                {
                    //ASK FOR PIN
                    Console.WriteLine("Pin?");
                    string pin = Console.ReadLine();
                    bool validPin = IMember.IsValidPin(pin);
                    if (validPin)
                    {
                        //VERIFY DETAIL AND ADD MEMBER
                        Member member = new Member(first, last, number, pin);
                        while (true)
                        {
                            Console.Clear();
                            Console.WriteLine("Verify Member Detail");
                            displayMemberInfo(member);
                            Console.WriteLine("\nRegister this member? (Y/N)");
                            string yesNo = Console.ReadLine();
                            yesNo = yesNo.ToUpper();
                            if (yesNo == "Y")
                            {
                                Members.Add(member);
                                Console.Clear();
                                Console.WriteLine("Successfully Register member with following detail:");
                                displayMemberInfo(member);
                                break;
                            }
                            else if (yesNo == "N")
                            {
                                Console.Clear();
                                Console.WriteLine("Back to menu...");
                                break;
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("Invalid option, try again");
                            }
                        }
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Invalid PIN, back to menu...");
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Invalid Phone Number, back to menu...");
                }
            }
        }

        //Find a member contact number
        public void FindNumber()
        {
            Console.Clear();
            //Ask for name
            Console.WriteLine("First Name?");
            string first = Console.ReadLine();
            Console.WriteLine("Last Name?");
            string last = Console.ReadLine();
            Member toFind = new Member(first, last);
            //FIND THE NAME
            toFind = (Member)members.Find(toFind);
            if (toFind == null)
            {
                Console.Clear();
                Console.WriteLine("Can not find member with the name, back to menu...");
            }
            else
            {
                Console.Clear();
                string number = toFind.ContactNumber;
                Console.WriteLine("Contact Number for the input name: " + number);
            }
        }

        //Borrow a DVD
        public void BorrowDVD(Member member)
        {
            Console.Clear();
            //Check if member already borrow up to 5 DVD
            if (member.Borrowing.Number < 5)
            {
                displayAllMovie();
                Console.WriteLine();
                Console.WriteLine("Input movie title to borrow: ");
                string title = Console.ReadLine();
                Movie movieBorrow = (Movie)movies.Search(title);
                if (movieBorrow != null)
                {
                    bool canBorrow = movieBorrow.AddBorrower(member);
                    if (canBorrow)
                    {
                        //Create a copy of the movie but only include the title for sake of simplicity
                        Movie toAdd = new Movie(movieBorrow.Title);
                        member.Borrowing.Insert(toAdd);
                        Console.Clear();
                        Console.WriteLine("Borrow successfully.");
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Either there's no more available copies or the user had already borrowed 1 of this DVD");
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Movie title not found, back to menu...");
                }
            }
            else
            {
                Console.WriteLine("You already have 5 DVD borrowed.");
            }

        }


        //List current borrowed movie by user
        public void showBorrowed(Member member)
        {
            Console.Clear();
            IMovie[] array = member.Borrowing.ToArray();
            Console.WriteLine("Member currently borrow these DVD:");
            Console.WriteLine();
            Console.WriteLine("-------------Borrowed Detail-------------");
            foreach (Movie movie in array)
            {
                Console.WriteLine("Title: " + movie.Title);
            }
            Console.WriteLine("-----------------------------------------");
        }

        //Remove a registered member from the system
        public void removeMember()
        {
            Console.WriteLine("First Name?");
            string first = Console.ReadLine();
            Console.WriteLine("Last Name?");
            string last = Console.ReadLine();
            Member toFind = new Member(first, last);
            //FIND THE NAME
            toFind = (Member)members.Find(toFind);
            if (toFind != null)
            {
                int counter = 0;
                foreach (Movie movie in movies.ToArray())
                {
                    if (movie.Borrowers.Search(toFind) == true)
                    {
                        counter++;
                        break;
                    }
                }
                if (counter == 0)
                {
                    members.Delete(toFind);
                }
                else
                {
                    Console.WriteLine("Member has DVD on loan and can't be removed");
                }

            }
            else
            {
                Console.WriteLine($"{first} {last} is not a registered member");
            }
        }

        //Display all borrowers of particular movie
        public void displayBorrower()
        {
            Console.WriteLine("Movie title?");
            string title = Console.ReadLine();
            Console.WriteLine("");
            Movie toFind = new Movie(title);
            //FIND THE MOVIE
            toFind = (Movie)movies.Search(title);
            if (toFind != null)
            {
                if (toFind.Borrowers.Number != 0)
                {
                    Console.WriteLine(toFind.Borrowers.ToString());
                }
                else
                {
                    Console.WriteLine("No member borrowed this movie");
                }
            }
            else
            {
                Console.WriteLine("Invalid movie title");
            }
        }

        //Return a movie DVD to the community library
        public void returnDVD(Member member)
        {
            displayBorrowedMovie(member);
            Console.WriteLine("Movie title to return:");
            string title = Console.ReadLine();
            Console.WriteLine("");
            Movie toFind = new Movie(title);
            Movie temp = (Movie)movies.Search(title);
            if (toFind != null)
            {
                
                if (member.Borrowing.Delete(toFind) == true)
                {
                    temp.RemoveBorrower(member);
                    Console.WriteLine($"{toFind.Title} has been returned");
                }
                else
                {
                    Console.WriteLine("Error returning movie");//for testing error delete when complete
                }
            }
            else
            {
                Console.WriteLine($"You are not borrowing {toFind.Title}");
            }
        }

        //Display all borrowed Movie info
        public void displayBorrowedMovie(Member member)
        {

            Console.Clear();
            Console.WriteLine("All movies you are borrowing:");
            Console.WriteLine("------------------------------");
            foreach (Movie movie in member.Borrowing.ToArray())
            {
                Console.WriteLine("Title: " + movie.Title);
            }
            Console.WriteLine("------------------------------");

        }
    }
}