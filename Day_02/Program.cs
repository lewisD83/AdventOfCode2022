using System;
using System.IO;
using System.Numerics;

class Day2
{
	static public void Main (String[] args)
	{
		string[] lines = File.ReadAllLines("Input.txt");
		int part1Score = 0;
		int part2Score = 0;
		
		foreach(string line in lines)
		{
			string[] temp = line.Split(" ");

			// Convert player input to 0,1,2 for rock, paper and scissors
			int p1 = temp[0][0] - 'A';
			int p2 = temp[1][0] - 'X';
			int score = 0;

			// Draw
			if (p1 == p2)
			{
				score = p2 + 1 + 3;
			}

			// Loss
			if (p1 == ((p2 + 1) % 3) )
			{
				score = p2 + 1;
			}

			// Win
			if (p1 == ((p2 + 2) % 3))
			{
				score = p2 + 1 + 6;
			}

			part1Score += score;
			score = 0;

			// lose
			if (p2 == 0)
			{
				score = ((p1 + 2) % 3) + 1;
			}

			// Draw
			if (p2 == 1)
			{
				score = p1 + 1 + 3;
			}

			// Win 
			if (p2 == 2)
			{
				score = ((p1 + 1) % 3) + 1 + 6;
			}

			score = (p1 + (p2 + 2) % 3) % 3 + 1 + 3 * p2;

			part2Score += score;
		}

		int answer1 = part1Score;
		int answer2 = part2Score;


		Console.WriteLine("Main Method");

	}
}
