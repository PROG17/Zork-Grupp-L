using System;
using JetBrains.Annotations;

namespace Zork_Grupp_L.Helpers
{
	public static class ConsoleHelper
	{
		[StringFormatMethod("format")]
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

		[StringFormatMethod("format")]
		public static void WriteLineWrap(string format, params object[] args)
		{
			WriteLineWrap(arg: string.Format(format, args));
		}

		public static void WriteLineWrap(object arg)
		{
			WriteWrap(arg);

			Console.WriteLine();
		}

	}
}
