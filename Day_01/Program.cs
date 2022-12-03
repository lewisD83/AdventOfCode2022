using System;
using System.IO;
using System.Numerics;

class Day1
{
    static public void Main(String[] args)
    {
        string[] lines = File.ReadAllLines("Input.txt");
        List<int> totalCalories = new List<int>();

		int curCalories = 0;

        for (int i = 0; i < lines.Length; i++)
        {
            string line = lines[i];

			if (string.IsNullOrEmpty(line) == false)
			{
				curCalories += int.Parse(line);
			}

			if (string.IsNullOrEmpty(line) || i == lines.Length - 1)
            {
                totalCalories.Add(curCalories);
				curCalories = 0;
			}            
		}

		var temp = totalCalories.OrderByDescending(i => i).ToList();

		int answer1 = temp[0];
		int answer2 = temp[0] + temp[1] + temp[2];


		Console.WriteLine("Main Method");

    }
}
