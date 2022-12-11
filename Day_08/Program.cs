﻿using System.Reflection.Emit;
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
		
		public Grid() 
		{
			grid = new string[0];
			maxX = 0;
			maxY = 0;
		}

		public Grid(string[] grid, int maxX, int maxY)
		{
			this.grid = grid;
			this.maxX = maxX;
			this.maxY = maxY;
		}

		public char GetNeighbour(int x, int y, int deltaX, int deltaY) 
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

	public static bool CheckAllNeighbours(Grid grid, int x, int y, int i, int j)
	{
		int height = grid.grid[y][x] - '0';
		int neighbourHeight;

		// Check all up neighbours
		while ((neighbourHeight = (grid.GetNeighbour(x, y, i, j) - '0')) != -1)
		{
			if (height <= neighbourHeight)
			{
				return false;
			}

			i += i;
			j += j;
		}

		return true;
	}

	static public void Main(String[] args)
	{
		string[] lines = File.ReadAllLines("Input.txt");
		int maxX = lines[0].Length;
		int maxY = lines.Length;
		int answer = 0;
		/*
			30373
			25512
			65332
			33549
			35390
		 */

		Grid grid = new Grid(lines, maxX, maxY);

		for (int y = 0; y < maxY; y++)
		{
			for (int x = 0; x < maxX; x++)
			{
				if (y == 0 || y == (maxY - 1))
					continue;

				if (x == 0 || x == (maxX - 1))
					continue;

				int height = grid.grid[y][x] - '0';
				bool uVisible = CheckAllNeighbours(grid, x, y, 0, -1);
				bool dVisible = CheckAllNeighbours(grid, x, y, 0, 1);
				bool lVisible = CheckAllNeighbours(grid, x, y, -1, 0);
				bool rVisible = CheckAllNeighbours(grid, x, y, 1, 0);
				int goo = 4;

				if( uVisible ||
					dVisible ||
					lVisible ||
					rVisible)
				{
					answer++;
				}
				else
				{
					int foo = 4;
				}
			}
		}
	}
}


//// Check all up neighbours
//while ((neighbourHeight = (grid.GetNeighbour(x, y, 0, -i) - '0')) != -1)
//{
//	if (height <= neighbourHeight)
//	{
//		uVisible = false;
//		break;
//	}

//	i++;
//}

//// Check all down neighbours
//i = 1;
//while ((neighbourHeight = (grid.GetNeighbour(x, y, 0, i) - '0')) != -1)
//{
//	if (height <= neighbourHeight)
//	{
//		dVisible = false;
//		break;
//	}
//	i++;
//}


//// Check all left neighbours
//i = 1;
//while ((neighbourHeight = (grid.GetNeighbour(x, y, -i, 0) - '0')) != -1)
//{
//	if (height <= neighbourHeight)
//	{
//		lVisible = false;
//		break;
//	}
//	i++;
//}

//// Check all right neighbours
//i = 1;
//while ((neighbourHeight = (grid.GetNeighbour(x, y, i, 0) - '0')) != -1)
//{
//	if (height <= neighbourHeight)
//	{
//		rVisible = false;
//		break;
//	}
//	i++;
//}