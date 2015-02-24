using System;

namespace namegenerator
{
	public interface IRule
	{
		string Title { get; }
		bool Complies (string str);
	}
}
