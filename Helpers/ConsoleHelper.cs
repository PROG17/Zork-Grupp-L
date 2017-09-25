using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zork_Grupp_L.Helpers
{
	public static class ConsoleHelper
	{

		public static void WriteWrap(string format, params object[] args)
		{
			WriteWrap(arg: string.Format(format, args));
		}

		public static void WriteWrap(object arg)
		{
			if (arg == null) return;

			string[] words = arg.ToString().Split(' ');

			foreach (string word in words)
			{
				int wordLen = word.Length;
				if (Console.CursorLeft + wordLen > Console.WindowWidth)
					Console.WriteLine();

				Console.Write(word + ' ');
			}
		}

		public static void WriteLineWrap(string format, params object[] args)
		{
			WriteLineWrap(arg: string.Format(format, args));
		}

		public static void WriteLineWrap(object arg)
		{
			if (arg == null)
			{
				Console.WriteLine();
				return;
			}

			string[] words = arg.ToString().Split(' ');

			foreach (string word in words)
			{
				int wordLen = word.Length;
				if (Console.CursorLeft + wordLen > Console.WindowWidth)
					Console.WriteLine();

				Console.Write(word + ' ');
			}

			Console.WriteLine();
		}

	}
}
