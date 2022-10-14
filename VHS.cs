using System;

namespace Blockbuster_Lab
{
	public class VHS : Movie
	{
		//Implements CurrentScene property for VHS object.
		public int CurrentScene { get; set; }

		//VHS constructor. Inherits from the 'Movie' class
		public VHS(string title, Genre category, int runTime, List<string> scenes, int currentScene) : base (title, category, runTime, scenes) 
		{ 
			CurrentScene = currentScene;
		}

		//Overrides abstact method from parent class for 'play'
		public override void Play ()
		{
			for (int i = 0; CurrentScene < Scenes.Count(); i++) 
			{
                Console.WriteLine("\n" + Scenes[CurrentScene] + "\n");
                CurrentScene++;
            }

			Console.WriteLine("\nThe end!\n");
		}

		//Rewind method. Resets VHS movie's current scene to 0.
		public void Rewind () 
		{
			CurrentScene = 0;
		}
	}
}
