class Day7
{
	public delegate void TreeVisitor<T>(T nodeData, int depth);
	public delegate void TreeVisitor2<T>(NTree<T> node, int depth);
	public static int answer = 0;
	public static int answer2 = 0;
	public static int minSize = 0;

	public class Node
	{
		public string name { get; set; }
		public int size { get; set; }
		public bool isDir { get; set; }

		public Node(string name, int size, bool isDir)
		{
			this.name = name;
			this.size = size;
			this.isDir = isDir;	
		}
	}

	// Create a method for a delegate.
	public static void PrintFilessytem(Node nodeData, int depth)
	{
		for(int i = 0; i < depth; i++) 
		{
			Console.Write("   ");
		}
		Console.Write(nodeData.name);
		Console.Write(nodeData.isDir ? " (dir" : "(file");
		Console.Write($", size = {nodeData.size})");
		Console.WriteLine();
	}

	public static void GetAnswer(Node nodeData, int depth)
	{
		if (nodeData.isDir && nodeData.size <= 100000)
		{
			answer += nodeData.size;
		}

		if (nodeData.isDir && nodeData.size >= minSize)
		{
			if(answer2 == 0 || nodeData.size < answer2)
			{
				answer2 = nodeData.size;
			}
		}
	}

	public class NTree<T>
	{
		private T data;
		private LinkedList<NTree<T>> children;
		private NTree<T> parent;

		public NTree(T data, NTree<T> parent)
		{
			this.data = data;
			children = new LinkedList<NTree<T>>();
			this.parent = parent;
		}

		public T GetData()
		{
			return data;
		}

		public void AddChild(T data, NTree<T> _parent)
		{
			children.AddLast(new NTree<T>(data, _parent));
		}

		public NTree<T> GetChild(int i)
		{
			foreach (NTree<T> n in children)
				if (--i == 0)
					return n;
			return null;
		}

		public NTree<T> GetParent()
		{
			return parent;
		}

		public void Traverse(NTree<T> node, int depth, TreeVisitor<T> visitor)
		{
			visitor(node.data, depth);
			foreach (NTree<T> kid in node.children)
			{
				Traverse(kid, depth +1, visitor);
			}
				
		}
		public void Traverse2(NTree<T> node, int depth, TreeVisitor2<T> visitor)
		{
			foreach (NTree<T> kid in node.children)
			{
				Traverse2(kid, depth + 1, visitor);
			}
			visitor(node, depth);
		}
	}

	// Create a method for a delegate.
	public static void CalcSize(NTree<Node> node, int depth)
	{
		if (node.GetData().isDir)
		{
			int i = 1;
			while (node.GetChild(i) != null)
			{
				NTree<Node> child = node.GetChild(i);
				if (child.GetData().isDir)
				{
					node.GetData().size += child.GetData().size;
				}
				i++;
			}
		}
	}

	static public void Main(String[] args)
	{
		string[] lines = File.ReadAllLines("Input2.txt");

		NTree<Node> tree = new NTree<Node>(new Node("/", 0, true), null);
		NTree<Node> currentNode = tree;

		foreach (string line in lines)
		{
			Console.WriteLine(line);

			var op = line.Split(' ');

			// User operation
			if (op[0] == "$")
			{
				if (op[1] == "cd")
				{
					if (op[2] == "/")
					{
						continue;
					}
					else if (op[2] == "..")
					{
						currentNode = currentNode.GetParent();
					}
					else
					{
						int i = 1;
						while (currentNode.GetChild(i) != null)
						{
							NTree<Node> node = currentNode.GetChild(i);
							if (node.GetData().name == op[2])
							{
								currentNode = node;
								break;
							}
							i++;
						}
					}
				}
			}
			else
			{
				var res = line.Split(' ');
				if (res[0] == "dir")
				{
					currentNode.AddChild(new Node(res[1], 0, true), currentNode);
				}
				else
				{
					int size = int.Parse(res[0]);
					currentNode.AddChild(new Node(res[1], size, false), currentNode);
					currentNode.GetData().size += size;	
				}
			}	
		}

		tree.Traverse2(tree, 0, CalcSize);
		minSize = 30000000 - (70000000 - tree.GetData().size);

		tree.Traverse(tree, 0, PrintFilessytem);
		tree.Traverse(tree, 0, GetAnswer);


		Console.WriteLine(answer);
		Console.WriteLine(answer2);
	}
}