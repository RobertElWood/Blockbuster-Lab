using System;

namespace Blockbuster_Lab
{
    //Enum to generate constant values for movie genres
    public enum Genre
    {
        Drama,
        Comedy,
        Horror,
        Romance,
        Action
    }

    public abstract class Movie
    {
        //initializes properties for the movie class to be inherited by VHS and DVD.
        public string Title { get; set; }

        public int RunTime { get; set; }

        public Genre Category { get; set; }

        //List to store information on movie scenes
        public List<string> Scenes  { get; set; }

    //Constructs movie object...Do you have to do this if the class is abstract?
    public Movie(string title, Genre category, int runTime, List<string> scenes)
        {
            Title = title;
            RunTime = runTime;
            Category = category;
            Scenes = scenes;
        }

        //Method to print information on each Movie object created in main.
        public virtual void PrintInfo ()
        {
            Console.WriteLine($"Title: {Title}\tRunTime: {RunTime}\tGenre: {Category}");
        }

        //Method to print all of the scenes in 'Scenes', along with their index.
        public void PrintScenes () 
        { 
            for (int i = 0; i < Scenes.Count; i++) 
            {
                Console.WriteLine($"Scene {i+1}");
            }
        }

        //Abstract method to 'play' movies of child class VHS and DVD
        public abstract void Play();

    }
}

   
