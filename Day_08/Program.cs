using System.Reflection.Emit;
using System.Xml.Linq;

class Day8
{
	public int maxX = 0;
	public int maxY = 0;

	public class Grid
	{
		public string[] grid;
		public int maxX;
		public int maxY;

		public Grid ()
		{
			grid = new string[0];
			maxX = 0;
			maxY = 0;
		}

		public Grid (string[] grid, int maxX, int maxY)
		{
			this.grid = grid;
			this.maxX = maxX;
			this.maxY = maxY;
		}

		public char GetNeighbour (int x, int y, int deltaX, int deltaY)
		{
			int newX = x + deltaX;
			int newY = y + deltaY;

			if (newX < 0 || newX >= maxX)
				return '/';

			if (newY < 0 || newY >= maxY)
				return '/';

			return grid[newY][newX];
		}
	}

	public static bool CheckAllNeighbours (Grid grid, int x, int y, int i, int j)
	{
		int height = grid.grid[y][x] - '0';
		int neighbourHeight;
		int a = i;
		int b = j;

		// Check all up neighbours
		while ((neighbourHeight = (grid.GetNeighbour(x, y, a, b) - '0')) != -1)
		{
			if (height <= neighbourHeight)
			{
				return false;
			}

			a += i;
			b += j;
		}

		return true;
	}

	public static int CheckScenicScore (Grid grid, int x, int y, int i, int j)
	{
		int height = grid.grid[y][x] - '0';
		int neighbourHeight;
		int a = i;
		int b = j;

		int numTrees = 0;

		// Check all up neighbours
		while ((neighbourHeight = (grid.GetNeighbour(x, y, a, b) - '0')) != -1)
		{
			numTrees++;

			if (height <= neighbourHeight)
			{
				break;
			}

			a += i;
			b += j;
		}

		return numTrees;
	}

	static public void Main (String[] args)
	{
		string[] lines = File.ReadAllLines("Input2.txt");
		int maxX = lines[0].Length;
		int maxY = lines.Length;
		int answer = 0;
		int answer2 = 0;

		Grid grid = new Grid(lines, maxX, maxY);

		for (int y = 0; y < maxY; y++)
		{
			for (int x = 0; x < maxX; x++)
			{
				int height = grid.grid[y][x] - '0';
				bool uVisible = CheckAllNeighbours(grid, x, y, 0, -1);
				bool dVisible = CheckAllNeighbours(grid, x, y, 0, 1);
				bool lVisible = CheckAllNeighbours(grid, x, y, -1, 0);
				bool rVisible = CheckAllNeighbours(grid, x, y, 1, 0);

				if (uVisible ||
					dVisible ||
					lVisible ||
					rVisible)
				{
					answer++;
				}

				if (y == 0 || y == (maxY - 1))
					continue;

				if (x == 0 || x == (maxX - 1))
					continue;

				int uScore = CheckScenicScore(grid, x, y, 0, -1);
				int dScore = CheckScenicScore(grid, x, y, 0, 1);
				int lScore = CheckScenicScore(grid, x, y, -1, 0);
				int rScore = CheckScenicScore(grid, x, y, 1, 0);

				int score = uScore * dScore * lScore * rScore;
				if (score > answer2)
				{
					answer2 = score;
				}

				int foo = 5;

			}
		}

		Console.WriteLine(answer);
		Console.WriteLine(answer2);
	}
}