using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zork_Grupp_L.Helpers
{
	public static class StringHelper
	{

		public static bool KindaEquals(string a, string b)
		{
			if (a == null || b == null) return false;
			string[] needleWords = a.Trim().ToLower().Split(' ');
			string[] itemWords = b.Trim().ToLower().Split(' ');
			
			// Matchar något av orden i gissningen med något av orden i item:ets namn...
			foreach (string needleWord in needleWords)
				foreach (string itemWord in itemWords)
					if (itemWord == needleWord)
						return true;

			return false;
		}

		public static string Join(this IList<string> words, string seperator = ", ", string lastSeperator = ", and ", string seperatorIf2 = " and ")
		{
			int length = words.Count;
			if (length == 1) return words[0];

			var sb = new StringBuilder();
			for (int i = 0; i < length; i++)
			{
				string word = words[i];
				if (word == null) continue;
				if (word.Length == 0) continue;
				
				sb.Append(word);

				if (i == length - 1) continue;

				if (i == length - 2)
					sb.Append(length == 2 ? seperatorIf2 : lastSeperator);
				else
					sb.Append(seperator);
			}

			return sb.ToString();
		}

		/// <summary>
		/// Returns the word with "an" prepended if starts with a vowel, otherwise it adds "a".
		/// Example: "potato" => "a potato", "orange" => "an orange"
		/// <para>See: <see cref="IsVowel"/></para>
		/// </summary>
		public static string AutoAorAn(this string word)
		{
			if (string.IsNullOrEmpty(word)) return null;
			return (word[0].IsVowel() ? "an " : "a ") + word;
		}

		/// <summary>
		/// Returns true if character is a vowel, false otherwise.
		/// </summary>
		public static bool IsVowel(this char c)
		{
			const string vowels = "aeiouyåäöAEIOUYÅÄÖ";
			return vowels.IndexOf(c) != -1;
		}

		/// <summary>
		/// Converts the first character to uppercase
		/// </summary>
		public static string ToFirstUpper(this string text)
		{
			if (text == null) return null;
			if (text.Length == 0) return text;
			if (text.Length == 1) return text.ToUpper();

			return char.ToUpper(text[0]) + text.Substring(1);
		}

		public static bool EqualsAny(string needle, params string[] haystack)
		{
			if (haystack == null) return false;
			if (haystack.Length == 0) return false;

			foreach (string item in haystack)
				if (item == needle)
					return true;

			return false;
		}

	}
}
