using System;
using System.Collections.Generic;
using daslib.Validators;
using daslib;

namespace namegenerator
{
	class MainClass
	{
		public static void Main (string[] theArgs)
		{
			Console.WriteLine ("Name generator");

			var args = new Args (theArgs);

			bool doTest = args.Contains("t");
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

			string all = "abcdefghijklmnopqrstuvwxyz";
			string vowels = "aeiouy";
			string consonants = "bcdfghjklmnpqrstvwxz";


			var gen = new Generator ();

			if (doTest) {
				RunIt ("test", gen, storage, new AcceptingValidator (), new List<string> () {
					"a"
					, consonants
					, vowels
				});
			}

			if (doThree) {
				RunIt ("3 letters", gen, storage, new ThreeLetterValidator (), new List<string> () {
					"a"
					, consonants
					, vowels
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


			Console.WriteLine ();
			Console.WriteLine ();
			Console.WriteLine ("===========================");
			Console.WriteLine (" Total");
			Console.WriteLine ("===========================");
			Console.WriteLine ("Generated: {0:#,##0}", totalEntriesGenerated);
			Console.WriteLine ("Valid: {0:#,##0}", totalValidEntries);
			Console.WriteLine ("In: {0}", totalTimeUsed);
		}


		private static int totalEntriesGenerated = 0;
		private static int totalValidEntries = 0;
		private static TimeSpan totalTimeUsed = new TimeSpan();

		private static void RunIt(string config, Generator gen, IStorage storage, IValidator validator, IList<string> allowed)
		{
			Console.WriteLine ();
			Console.WriteLine ();
			Console.WriteLine ("===========================");
			Console.WriteLine (" " + config);
			Console.WriteLine ("===========================");

			GenerateResult res = gen.Generate (allowed, validator, storage);

			Console.WriteLine ();
			Console.WriteLine ();
			Console.WriteLine ("Generated: {0:#,##0}", res.EntriesGenerated);
			Console.WriteLine ("Valid: {0:#,##0}", res.ValidEntries);
			Console.WriteLine ("In: {0}", res.TimeUsed);

			totalEntriesGenerated += res.EntriesGenerated;
			totalValidEntries += res.ValidEntries;
			totalTimeUsed = totalTimeUsed.Add (res.TimeUsed);
		}
	}
}
