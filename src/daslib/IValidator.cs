﻿using System;

namespace daslib
{
	public interface IValidator
	{
		bool IsValid(string name);
		string IsValidWithMessage(string name);
	}
}

