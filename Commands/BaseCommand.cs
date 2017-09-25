﻿using System;
using System.Text.RegularExpressions;

namespace Zork_Grupp_L.Commands
{
	public abstract class BaseCommand
	{
		protected const string P_THE = @"($| +| +the( +|$))";

		public abstract string[] Syntax { get; }

		public abstract void Execute(Match match, string pattern);

		public bool TryExecute(string trimmedInput)
		{
			foreach (string pattern in this.Syntax)
			{
				string actualPattern = $"^{pattern.Replace(" ", @"\s")}$";

				Match match = Regex.Match(trimmedInput, actualPattern, RegexOptions.IgnoreCase);
				if (match.Success)
				{
					this.Execute(match, pattern);
					return true;
				}
			}

			return false;
		}
	}
}