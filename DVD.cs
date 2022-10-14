using System;

namespace Blockbuster_Lab
{
    public class DVD : Movie
    {

        //DVD Constructor. Doesn't have current scene like VHS, as play method will simply go through list of scenes
        //Doesn't need anything in body because there are no different properties to be declared over base.
        public DVD(string title, Genre category, int runTime, List<string> scenes) : base(title, category, runTime, scenes) 
        { 
        
        }
        
        //Play method for DVDs. Displays a menu of available scenes to the user and allows them to select one.
        //Error handling included for proper user input. Will loop until user selects appropriate number.
        public override void Play()
        {
            bool selectingScene = true;

            while (selectingScene)
            {
                Console.WriteLine($"\nWhich scene from {Title} would you like to watch?\n");

                PrintScenes();

                Console.WriteLine("\nPlease select a scene: \n");

                bool isNumeric = int.TryParse(Console.ReadLine(), out int input);

                if (isNumeric == false) 
                {
                    Console.WriteLine("\nI'm sorry, I don't think that you've entered a number. Please try again.");
                    continue;
                } 
                else if (input <= 0 || input > Scenes.Count()) 
                {
                    Console.WriteLine("\nI'm sorry, you entered a number that is out of the range of our scenes. Try again.");
                    continue;
                }

                Console.WriteLine($"\nYou watched scene {input}: {Scenes[input-1]}");
                
                selectingScene = false;
            }
        }
    }
}
