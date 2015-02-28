using System;
using System.Collections.Generic;
using System.Text;

namespace namegenerator
{
	public class Permutator
	{
		public IEnumerable<string> GetPermutations(IList<string> characters)
		{
			var indices = new List<int> (characters.Count);
			foreach (string s in characters) {
				indices.Add (0);
			}

			// return 0,0,0,....,0
			yield return this.GetWord (characters, indices);

			while (true) {
				if (this.Increment (characters, indices)) {
					break;
				}

				yield return this.GetWord (characters, indices);
			}
		}

		private bool Increment(IList<string> characters, IList<int> indices)
		{
			bool isDone = false;

			int ni;

			for (int i = indices.Count - 1; i >= 0; i--) {
				ni = indices [i] + 1;
				indices [i] = ni; // store new index
				if (ni == characters [i].Length) {
					indices [i] = 0;
					isDone = (i == 0);
				} else {
					break; // nothing more to increment
				}
			}

			return isDone;
		}

		private string GetWord(IList<string> characters, IList<int> indices)
		{
			var sb = new StringBuilder ();

			for (int i = 0; i < indices.Count; i++) {
				sb.Append (characters [i] [indices [i]]);
			}

			return sb.ToString ();
		}
	}
}

