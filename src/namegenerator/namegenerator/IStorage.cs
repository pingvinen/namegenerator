using System;

namespace namegenerator
{
	public interface IStorage
	{
		void Save(string name);
		void Init();
		void Clear();
	}
}

