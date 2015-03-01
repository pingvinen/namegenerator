using System;

namespace namegenerator
{
	public class BlackholeStorage : IStorage
	{
		#region IStorage implementation

		public void Save (string name)
		{
			Console.WriteLine ("Saving: {0}", name);
		}

		public void Init ()
		{
		}

		public void Clear ()
		{
		}

		public void Done ()
		{
		}

		#endregion
	}
}

