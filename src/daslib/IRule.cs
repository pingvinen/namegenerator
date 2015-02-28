using System;

namespace daslib
{
	public interface IRule
	{
		string Title { get; }
		bool Complies (string str);
	}
}
