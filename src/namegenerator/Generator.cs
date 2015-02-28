using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace namegenerator
{
	public class Generator
	{
		public Generator ()
		{
		}

		private long GetNumberOfPermutations(IList<string> allowedCharacters)
		{
			long res = (long)allowedCharacters[0].Length;

			for (int i = 1; i < allowedCharacters.Count; i++) {
				res *= allowedCharacters [i].Length;
			}

			return res;
		}

		public GenerateResult Generate(IList<string> allowedCharacters, IValidator validator, IStorage storage)
		{
			var result = new GenerateResult ();
			var permutator = new Permutator ();
			var max = this.GetNumberOfPermutations (allowedCharacters);


			Stopwatch sw = new Stopwatch ();
			sw.Start ();
			Console.WriteLine ();
			foreach (string name in permutator.GetPermutations(allowedCharacters)) {
				result.EntriesGenerated++;

				if (result.EntriesGenerated % 100 == 0) {
					Console.Write (".");
				}
				if (result.EntriesGenerated % 10000 == 0) {
					Console.WriteLine ("[{0:#,##0}/{1:#,##0}]", result.EntriesGenerated, max);
				}


				if (validator.IsValid (name)) {
					result.ValidEntries++;
					storage.Save (name);
				}
			}
			sw.Stop ();

			result.TimeUsed = sw.Elapsed;

			return result;
		}
	}
}

