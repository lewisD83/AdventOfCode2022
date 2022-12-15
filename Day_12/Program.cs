using System;
using System.ComponentModel;
using System.IO;
using System.Numerics;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

class Day_12
{
	public class Grid
	{
		public string[] grid	{ get; }
		public int maxX			{ get; }
		public int maxY			{ get; }

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

		public Node GetNeighbour(int x, int y, int deltaX, int deltaY)
		{
			int newX = x + deltaX;
			int newY = y + deltaY;

			if (newX < 0 || newX >= maxX)
				return null;

			if (newY < 0 || newY >= maxY)
				return null;

			return new Node(newX, newY, grid[newY][newX]);
		}
	}

	public class Node
	{
		public int x		{ get; set; }
		public int y		{ get; set; }
		public int s		{ get; set; }
		public int height	{ get; set; }
		public char c		{ get; set; }
		public Node parent	{ get; set; }

		public Node(int _x, int _y, char _c)
		{
			this.x = _x;
			this.y = _y;
			this.c = _c;
			this.s = int.MaxValue;
			this.parent = null;

			if (this.c == 'S')
			{
				this.height = 'a' - 'a';
			}
			else if (this.c == 'E')
			{
				this.height = 'z' - 'a';
			}
			else
			{
				this.height = this.c - 'a';
			}
		}

		public override string ToString()
		{
			return $" ({x},{y}) = {c}({(int)c})";
		}
	}

	static public void Main(String[] args)
	{
		string[] lines = File.ReadAllLines("Input2.txt");
		int maxX = lines[0].Length;
		int maxY = lines.Count();

		int startX = 0;
		int startY = 0;

		int endX = 0;
		int endY = 0;

		List<Node> startPositions = new List<Node>();

		// Find our start and end positions
		for (int i = 0; i < lines.Length; i++)
		{
			string line = lines[i];

			if (line.Contains('S'))
			{
				int res = 0;
				while (true)
				{
					res = line.IndexOf('S', res);
					if (res >= 0)
					{
						startPositions.Add(new Node(res, i, 'S'));
						res++;
						continue;
					}
					break;
				}
			}
			if(line.Contains('a'))
			{
				int res = 0;
				while(true)
				{
					res = line.IndexOf('a', res);
					if (res >= 0)
					{
						startPositions.Add(new Node(res, i, 'a'));
						res++;
						continue;
					}
					break;
				}
			}
			
			if (line.Contains('E'))
			{
				endX = line.IndexOf('E');
				endY = i;
			}
		}

		List<int> counts = new List<int>();

		foreach (Node start in startPositions)
		{
			// Intialise our grid 
			Grid grid = new Grid(lines, maxX, maxY);

			// Initialise our start and end nodes
			Node end = new Node(endX, endY, 'E');

			// Keep track of the costs of moving to nodes 
			int[,] costs = new int[maxY, maxX];
			for (int y = 0; y < maxY; y++)
			{
				for (int x = 0; x < maxX; x++)
				{
					costs[y, x] = int.MaxValue;
				}
			}
			costs[startY, startX] = 0;
			start.s = 0;

			List<Node> currentNodes = new List<Node>();
			currentNodes.Add(start);

			List<Node> visitedNodes = new List<Node>();

			int[] dx = new int[] { -1, 1, 0, 0 };
			int[] dy = new int[] { 0, 0, -1, 1 };

			while (currentNodes.Count > 0)
			{
				// Pop our best current node
				Node current = currentNodes[0];
				currentNodes.RemoveAt(0);

				// Add it to a list of nodes that we have visited
				visitedNodes.Add(current);

				// If we have reached our goal break out
				if (current.x == endX && current.y == endY)
				{
					end = current;
					break;
				}

				// For all 4 neighbours of the current node
				for (int i = 0; i < 4; i++)
				{
					Node neighbour = grid.GetNeighbour(current.x, current.y, dx[i], dy[i]);
					if (neighbour != null)
					{
						// Make sure we haven't already visited this node
						bool visited = visitedNodes.Any(node => node.x == neighbour.x && node.y == neighbour.y);

						// Make sure we haven't queued this node already to be processed
						bool queued = currentNodes.Any(node => node.x == neighbour.x && node.y == neighbour.y);

						// Calculate the difference in height
						int diff = Math.Abs(current.height - neighbour.height);

						// An elf can only climb to a neighbour that is a difference of 1 in height
						bool isClimbable = (diff >= 0 && diff <= 1);

						//  An elf can drop to any neighbour lower than the current 
						bool isLower = (neighbour.height <= current.height);

						if (!visited && !queued && (isLower || isClimbable))
						{
							int currentDist = costs[current.y, current.x] + 1;
							int neighbourDist = costs[neighbour.y, neighbour.x];

							costs[neighbour.y, neighbour.x] = Math.Min(currentDist, neighbourDist);
							neighbour.s = currentDist;
							currentNodes.Add(neighbour);
							neighbour.parent = current;
						}
					}
				}

				currentNodes.OrderByDescending(node => node.s).ToList();

			}
			{
				int		count = 0;

				while (end != null)
				{
					count++;
					int	x = end.x;
					int	y = end.y;
					char c = end.c;

					//Console.WriteLine($"({x},{y}) : {c}");

					end = end.parent;
				}
				if (count > 1)
				{
					counts.Add(count-1);
				}
				
				//Console.WriteLine(count);
				//Console.WriteLine();


			}
		}
		var list = counts.OrderBy(x => x).ToList();
		int answer = list[0];
		Console.WriteLine(answer);
	}

}