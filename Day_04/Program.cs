using System;
using System.IO;
using System.Numerics;

class Day4
{
	static public void Main (String[] args)
	{
		string[] lines = File.ReadAllLines("Input.txt");
		int answer = 0;
		int answer2 = 0;

		// Part 1
		foreach (string line in lines)
		{
			string[] elves = line.Split(',');
			string[] elf1 = elves[0].Split('-');
			string[] elf2 = elves[1].Split('-');

			int x1 = int.Parse(elf1[0]);
			int x2 = int.Parse(elf1[1]);
			int x3 = int.Parse(elf2[0]);
			int x4 = int.Parse(elf2[1]);

			if (x1 >= x3 && x2 <= x4 ||
				x3 >= x1 && x4 <= x2)
			{
				answer++;
			}

			if (x1 <= x3 && x2 >= x3 ||
				x1 <= x4 && x2 >= x4 ||
				x3 <= x1 && x4 >= x1 ||
				x3 <= x2 && x4 >= x2)
			{
				answer2++;
			}
		}

		Console.WriteLine(answer);
		Console.WriteLine(answer2);
	}
}
