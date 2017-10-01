using System.Collections;
using System.Collections.Generic;
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
	}
}