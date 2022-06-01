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
        public Database(MovieCollection movies,MemberCollection members) {this.movies = movies; this.members = members; }

        public void AddDvD()
        {    
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
                else if(genreInt == 2)
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
                
                while(true)
                {
                    //OFFICIALLY ADD IN THE MOVIE - TODO 
                    Console.WriteLine();
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
                        Movie movie = new Movie(title,genreChoose,classification,durationInt,numberToAdd);
                        bool added = movies.Insert(movie);
                        if (added)
                        {
                            Console.Clear();
                            Console.WriteLine("Movie successfully added, back to menu...");
                            break;
                        }
                        else
                        {
                            movie = (Movie)movies.Search(title);
                            movie.TotalCopies = movie.TotalCopies+numberToAdd;
                            movie.AvailableCopies = movie.AvailableCopies + numberToAdd;
                            Console.Clear();
                            Console.WriteLine("Movies already in library, added " + numberToAdd + " DvD instead");
                            Console.WriteLine("Detail of the Movie is now: " + movie.ToString());
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
    }
}
