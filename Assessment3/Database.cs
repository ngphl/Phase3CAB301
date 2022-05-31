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
            Console.WriteLine("Title of Movie: ");
            string title = Console.ReadLine();

            //CHOOSING GENRE - START
            Console.WriteLine("Select Genre by Number: ");
            Console.WriteLine("1. Action");
            Console.WriteLine("2. Comedy");
            Console.WriteLine("3. History");
            Console.WriteLine("4. Drama");
            Console.WriteLine("5. Western");
            string genre = Console.ReadLine();
            bool option = int.TryParse(genre, out int genreInt);
            while (option)
            {
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
                    Console.Clear();
                    Console.WriteLine("No genre found, back to menu...");
                    break;
                }
                //CHOOSING GENRE - END
                //CHOOSING CLASSIFICATION - START
                Console.WriteLine("Select Movie Classification by Number:");
                Console.WriteLine("1. General (G)");
                Console.WriteLine("2. Parental Guidance (PG)");
                Console.WriteLine("3. Mature (M)");
                Console.WriteLine("4. Mature Accompanied (MA15+)");
                string classify = Console.ReadLine();
                bool option2 = int.TryParse(classify, out int classifyInt);
                if (option2)
                {
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
                        Console.Clear();
                        Console.WriteLine("No genre found, back to menu...");
                        break;
                    }
                    //CHOOSING CLASSIFICATION - END
                    //CHOOSE NUMBER OF DVD TO ADD - START
                    Console.WriteLine("Number of DVD to add:");
                    string toAdd = Console.ReadLine();
                    option = int.TryParse(toAdd, out int numberToAdd);
                    //If number added is not appropriate
                    if (!option)
                    {
                        Console.Clear();
                        Console.WriteLine("Invalid amount, back to menu...");
                    }
                    //If number added is appropriate
                    //OFFICIALLY ADD IN THE MOVIE - TODO 

                    break;
                    //CHOOSE NUMBER OF DVD TO ADD - END
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Invalid selection, back to menu...");
                    break;
                }
            }   
            if (!option)
            {
                Console.Clear();
                Console.WriteLine("Invalid selection, back to menu...");
            }
        }
    }
}
