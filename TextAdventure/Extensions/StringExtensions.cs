using System;
using System.Collections.Generic;
using System.Linq;

namespace TextAdventure.Extensions
{
	public static class StringExtensions
	{
		// copied from https://github.com/djkrose/7DTD-ScriptingMod/blob/master/ScriptingMod/Extensions/StringExtensions.cs
		// Removes the indentation of the first non-empty line from all the lines,
 		// effectively keeping relative indentation but removing common indentation.
		// Also empty lines at start and end are removed.
		public static string Unindent(this string source)
		{
			IEnumerable<string> lines = source.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
			lines = TrimEmptyLines(lines);
			string indent = new string((lines.FirstOrDefault() ?? "").TakeWhile(char.IsWhiteSpace).ToArray());
			lines = lines.Select(l => l.StartsWith(indent) ? l.Substring(indent.Length) : l.TrimStart(' '));
			return string.Join(Environment.NewLine, lines.ToArray());
		}

		private static IEnumerable<string> TrimEmptyLines(IEnumerable<string> source)
		{
			string[] sourceArr = source.ToArray();

			// Remove empty lines one by one from beginning and end
			int start = 0, end = sourceArr.Length - 1;
			while (start < end && sourceArr[start].All(char.IsWhiteSpace)) start++;
			while (end >= start && sourceArr[end].All(char.IsWhiteSpace)) end--;
			return sourceArr.Skip(start).Take(end - start + 1);
		}
	}
}