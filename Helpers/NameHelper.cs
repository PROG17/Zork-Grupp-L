using System;
using System.Collections.Generic;
using System.Linq;
using Zork_Grupp_L.Items;

namespace Zork_Grupp_L.Helpers
{
	public static class NameHelper
	{
		public static string[] GetNames(this IEnumerable<NamedObject> list)
		{
			var itemNames = new List<string>();

			foreach (NamedObject item in list)
			{
				itemNames.Add(item.Name);
			}

			return itemNames.ToArray();
		}

		public static string[] GetPrefixedNames(this IEnumerable<BaseItem> list)
		{
			var itemNames = new List<string>();

			foreach (BaseItem item in list)
			{
				itemNames.Add(item.PrefixedName);
			}

			return itemNames.ToArray();
		}

		public static List<NamedType> FindUniqueMatches<NamedType>(this IEnumerable<NamedType> list, string needle)
			where NamedType : NamedObject
		{
			return list.FindUniqueMatches(needle, n => n.Name);
		}

		public static List<T> FindUniqueMatches<T>(this IEnumerable<T> list, string needle, Func<T, string> selector)
		{
			if (list == null || needle == null) return new List<T>();
			string[] needleWords = needle.Trim().ToLower().Split(' ');

			List<T> allMatches = null;
			// Ett av orden i <needle> finns endast i ett av objektens namn
			foreach (string needleWord in needleWords)
			{
				List<T> matchesForWord = list.Where(n => selector(n).ContainsWord(needleWord)).ToList();
				if (matchesForWord.Count == 1)
				{
					return matchesForWord;
				}
				else if (matchesForWord.Count > 1)
				{
					allMatches = allMatches == null
						? matchesForWord
						: allMatches.Intersect(matchesForWord).ToList();
				}
			}

			return allMatches ?? new List<T>();
		}
		
	}
}