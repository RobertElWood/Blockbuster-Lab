 namespace Blockbuster_Lab
{ 
    internal class Program
    {
        static void Main(string[] args)
        {
            //Bool value to control loop below
            bool goOn = true;

            //Movie list constructed as well as scene lists. These are fed into Blockbuster object.
            List<Movie> movieList = new List<Movie>();

            string[] ACVPScenes = {"Two Canadians are backpacking through France", "One of the backpackers is attacked by a vampire",
            "The backpacker slowly develops a garlic allergy", "The backpacker accepts that, as a vampire, he'll never get to enjoy French cuisine"};
            movieList.Add (new VHS ("A Canadian Vampire in Paris", Genre.Horror, 97, ACVPScenes.ToList(), 3));

            string[] SGSScenes = {"Donkey and Dragon are living happily", "Donkey is stolen by Donkey rustlers",
            "Shrek has a training arc to save Donkey", "Shrek goes on a rampage", "Donkey is rescued, the end"};
            movieList.Add(new VHS ("Shrek 37: Get Shrekt", Genre.Action, 120, SGSScenes.ToList(), 1));

            string[] STMScenes = { "'I'm Ready': The Opening Number", "'Future! Future!' Squidward's Existential Crisis",
            "'Money', by Mr. Krabs and the Krusty Quartet", "'No, this is Patrick', a Comedic Starfish Medley", "'Best Movie Ever' SpongeBob's Closing Song" };
            movieList.Add(new VHS("SpongeBob: The Musical", Genre.Horror, 300, STMScenes.ToList(), 2));

            string[] MPDScenes = { "John Cleese gets Roasted", "Ian Davidson gets Roasted", "Terry Gilliam gets Roasted", "Graham Chapman gets Roasted" };
            movieList.Add(new DVD ("...And Your Father Smelt of Elderberries! A Roast of Monty Python", Genre.Comedy, 67, MPDScenes.ToList()));

            string[] EWOKScenes = { "A peaceful Ewok village exists on Endor", "The villagers are abducted by a bigger Ewok tribe", 
                "All-out Ewok war breaks out as the villagers try to escape", "An escaped Ewok glimpses the first stormtroopers to land on Endor", }; 
            movieList.Add(new DVD("Ewokalypto", Genre.Drama, 138, EWOKScenes.ToList()));

            string[] NLAScenes = { "Johnny is revived as a zombie", "Johnny says 'I did not hit her...I did not'...Again", 
                "Mark shows up and sees Johnny is revived", "Johnny says 'Oh hi Mark' before he attacks, getting revenge" };
            movieList.Add(new DVD("The Room 2: Electric Boogaloo", Genre.Romance, 129, NLAScenes.ToList()));
            
            //Creates instance of blockbuster object with movies generated above.
            Blockbuster videoStore = new Blockbuster(movieList);

            Console.WriteLine("\nWelcome to Blockbuster Video! What? Yes...We're still in business.\n");
            Console.WriteLine("...Don't look so surprised.");

            while (goOn)
            {
                var pickedMovie = videoStore.CheckOut();

                Console.WriteLine($"\nWould you like to watch {pickedMovie.Title}? Y/N\n");

                string input = Console.ReadLine().ToLower();
                Console.WriteLine();

                if (input == "n")
                {
                    Console.WriteLine("\nOkay. We'll put this one back on the shelf and you can pick a different one.\n");
                    continue;
                }
                else if (input == "y" && pickedMovie is DVD) 
                { 
                    pickedMovie.Play();
                } 
                else if (input == "y" && pickedMovie is VHS) 
                {
                    VHS pickedMovieVHS = (VHS)pickedMovie;

                    Console.WriteLine("\nWould you like us to rewind the movie before you play it?\n");

                    string input2 = Console.ReadLine().ToLower();
                    Console.WriteLine();
                    
                    if (input2 == "y") 
                    {
                        pickedMovieVHS.Rewind();
                        pickedMovieVHS.Play();
                    } 
                    else if (input2 == "n") 
                    {
                        pickedMovieVHS.Play();
                    } 
                    else 
                    {
                        Console.WriteLine("\nI'm sorry, I didn't understand that. Let's try again.\n");
                        continue;
                    }

                } 
                else 
                {
                    Console.WriteLine("\nI'm sorry, I didn't understand that. Please try again!");
                    continue;
                }

                goOn = runAgain();
            }
        }
        public static bool runAgain()
        {
            Console.WriteLine("\nWould you like to rent another movie? Y/N?\n");
            string input = Console.ReadLine().ToLower();

            if (input == "y")
            {
                Console.WriteLine();
                return true;
            }
            else if (input == "n")
            {
                Console.WriteLine("\nThanks for coming to Blockbuster! Tell your friends we still exist!!!");
                return false;
            }
            else
            {
                Console.WriteLine("\nI didn't understand that. Please try again!\n");
                return runAgain();
            }
        }
    }
}