using System;
using viewer.WebStuff;

namespace viewer
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Console.WriteLine ("Namegenerator viewer");

			AppHost appHost = new AppHost ();
			appHost.Init ();
			appHost.Start ("http://*:15620/");

			Console.ReadLine ();
		}
	}
}
