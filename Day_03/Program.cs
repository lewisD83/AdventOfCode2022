using System;
using System.IO;
using System.Numerics;

class Day3
{
	static public char FindFirstOf (string line, string other)
	{
		foreach (char n in line)
		{
			int res = other.IndexOf(n);
			if (res >= 0)
			{
				char found = other[res];
				return found;
			}
		}

		return '/';
	}

	static public char FindFirstOf (string line, string other, string other2)
	{
		foreach (char n in line)
		{
			int res = other.IndexOf(n);
			int res2 = other2.IndexOf(n);

			if (res >= 0 && res2 >= 0)
			{
				char found = other[res];
				return found;
			}
		}

		return '/';
	}

	static public void Main (String[] args)
	{
		string[] lines = File.ReadAllLines("Input2.txt");
		int answer = 0;

		// Part 1
		foreach (string line in lines)
		{
			Console.WriteLine(line);

			int delimeter = line.Length / 2;

			string first = line.Substring(0, delimeter);
			string second = line.Substring(delimeter);

			char found = FindFirstOf(first, second);

			answer += char.IsLower(found) ? (found - '`') : (found - '&');
		}

		// Part 2
		List<string> list = new List<string>();
		answer = 0;

		foreach (string line in lines)
		{
			Console.WriteLine(line);
			list.Add(line);

			if (list.Count == 3)
			{
				int delimeter = line.Length / 2;

				string first = list[0];
				string second = list[1];
				string third = list[2];

				char found = FindFirstOf(first, second, third);

				answer += char.IsLower(found) ? (found - '`') : (found - '&');

				list.Clear();
			}

			
		}

		Console.WriteLine("Answer: " + answer);

	}
}
