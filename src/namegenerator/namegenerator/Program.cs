using System;
using System.Collections.Generic;

namespace namegenerator
{
	class MainClass
	{
		public static void Main (string[] theArgs)
		{
			Console.WriteLine ("Name generator");

			var args = new Args (theArgs);

			bool doThree = args.Contains("3");
			bool doFour = args.Contains("4");
			bool doFive = args.Contains("5");
			bool doSix = args.Contains("6");
			bool doSeven = args.Contains("7");

			bool doClear = args.Contains("clear");




			IStorage storage = new BufferedDbStorage ();
			storage.Init ();

			if (doClear) {
				storage.Clear ();
			}

			var all = "abcdefghijklmnopqrstuvwxyz";
			var consonants = "bcdfghjklmnpqrstvwxz";

			var gen = new Generator ();

			if (doThree) {
				RunIt ("3 letters", gen, storage, new ThreeLetterValidator (), new List<string> () {
					"a"
				, consonants
				, all
				});
			}

			if (doFour) {
				RunIt ("4 letters", gen, storage, new MultiLetterValidator (), new List<string> () {
					"a"
				, consonants
				, all
				, all
				});
			}

			if (doFive) {
				RunIt ("5 letters", gen, storage, new MultiLetterValidator (), new List<string> () {
					"a"
				, consonants
				, all
				, all
				, all
				});
			}

			if (doSix) {
				RunIt ("6 letters", gen, storage, new MultiLetterValidator (), new List<string> () {
					"a"
				, consonants
				, all
				, all
				, all
				, all
				});
			}

			if (doSeven) {
				RunIt ("7 letters", gen, storage, new MultiLetterValidator (), new List<string> () {
					"a"
				, consonants
				, all
				, all
				, all
				, all
				, all
				});
			}

			storage.Done ();
		}



		private static void RunIt(string config, Generator gen, IStorage storage, IValidator validator, IList<string> allowed)
		{
			Console.WriteLine ();
			Console.WriteLine (config);
			Console.WriteLine ("===========================");

			GenerateResult res = gen.Generate (allowed, validator, storage);

			Console.WriteLine ();
			Console.WriteLine ("Generated: {0:#,##0}", res.EntriesGenerated);
			Console.WriteLine ("Valid: {0:#,##0}", res.ValidEntries);
			Console.WriteLine ("In: {0}", res.TimeUsed);
		}
	}
}
