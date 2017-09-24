using System.Text.RegularExpressions;

namespace Zork_Grupp_L.Commands
{
	public abstract class Command
	{
		public abstract string[] Syntax { get; }

		public abstract void Execute(Match match, string pattern);

		public bool TryExecute(string trimmedInput)
		{
			foreach (string pattern in this.Syntax)
			{
				Match match = Regex.Match(trimmedInput, $"^{pattern.Replace(" ", @"\s")}$", RegexOptions.IgnoreCase);
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