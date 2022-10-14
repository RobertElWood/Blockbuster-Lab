using System;

namespace Blockbuster_Lab
{
	public class Blockbuster
	{
		//Creates a list of movies to be rented out by the blockbuster class.
		List <Movie> Movies { get; set; }

		//Constructor for the blockbuster object.
		public Blockbuster (List<Movie> movies)
		{
			Movies = movies;
		}
		
		//Method to print out available movie titles for rental from blockbuster.
		public void PrintMovies() 
		{ 
			for (int i = 0; i < Movies.Count; i++) 
			{
				Console.WriteLine($"{i + 1}: {Movies[i].Title}");
			}
		}

		//Method to CheckOut a movie from blockbuster. 
		//Uses TryParse to ensure user is selecting a movie from index list.
		public Movie CheckOut () 
		{
			bool selectingMovie = true;
			Movie pickedMovie = Movies[0];

			while (selectingMovie)
			{
				Console.WriteLine("\nHere are the movies currently available for rental:\n");

				PrintMovies();

				Console.WriteLine("\nPlease select a movie by entering the movie's index number: \n");

				bool isNumeric = int.TryParse(Console.ReadLine(), out int input);

                if (isNumeric == false)
                {
                    Console.WriteLine("\nI'm sorry, I don't think that you've entered a number. Please try again.");
                    continue;
                }
                else if (input <= 0 || input > Movies.Count())
                {
                    Console.WriteLine("\nI'm sorry, you entered a number that is out of the range of our scenes. Try again.");
                    continue;
                }

				pickedMovie = Movies[input-1];

				Console.WriteLine();
				pickedMovie.PrintInfo();

				selectingMovie = false;
            }

            return pickedMovie;
        }
	}
}
