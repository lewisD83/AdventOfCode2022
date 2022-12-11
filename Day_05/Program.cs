class Day5
{
	static public void Main (String[] args)
	{
		string[] lines = File.ReadAllLines("Input2.txt");
		int answer = 0;
		int answer2 = 0;


		List<Stack<char>> stacks = new List<Stack<char>>();
		Stack<char> stack1 = new Stack<char>();
		Stack<char> stack2 = new Stack<char>();
		Stack<char> stack3 = new Stack<char>();
		Stack<char> stack4 = new Stack<char>();
		Stack<char> stack5 = new Stack<char>();
		Stack<char> stack6 = new Stack<char>();
		Stack<char> stack7 = new Stack<char>();
		Stack<char> stack8 = new Stack<char>();
		Stack<char> stack9 = new Stack<char>();

		bool part1 = false;

		if (part1)
		{
							  stack2.Push('M');
			stack1.Push('Z'); stack2.Push('C');
			stack1.Push('N'); stack2.Push('D'); stack3.Push('P');
		}
		else
		{
												stack3.Push('V'); stack4.Push('L'); stack5.Push('V');
			stack1.Push('B');					stack3.Push('L'); stack4.Push('D');	stack5.Push('F'); stack6.Push('G');
			stack1.Push('S'); stack2.Push('J'); stack3.Push('M'); stack4.Push('M');	stack5.Push('C'); stack6.Push('F');
			stack1.Push('V'); stack2.Push('V'); stack3.Push('H'); stack4.Push('Z');	stack5.Push('G'); stack6.Push('Q');	stack7.Push('L');
			stack1.Push('Z'); stack2.Push('B'); stack3.Push('N'); stack4.Push('P');	stack5.Push('J'); stack6.Push('T');	stack7.Push('G');					stack9.Push('J');
			stack1.Push('G'); stack2.Push('C'); stack3.Push('Z'); stack4.Push('F');	stack5.Push('B'); stack6.Push('S');	stack7.Push('C'); stack8.Push('N');	stack9.Push('F');
			stack1.Push('P'); stack2.Push('Z'); stack3.Push('D'); stack4.Push('J');	stack5.Push('Q'); stack6.Push('L');	stack7.Push('Z'); stack8.Push('L');	stack9.Push('H');
			stack1.Push('W'); stack2.Push('F'); stack3.Push('C'); stack4.Push('B'); stack5.Push('H'); stack6.Push('B'); stack7.Push('V'); stack8.Push('G'); stack9.Push('C');
		}


		stacks.Add(stack1);
		stacks.Add(stack2);
		stacks.Add(stack3);
		stacks.Add(stack4);
		stacks.Add(stack5);
		stacks.Add(stack6);
		stacks.Add(stack7);
		stacks.Add(stack8);
		stacks.Add(stack9);

		foreach (string line in lines)
		{
			string[] temp = line.Split(' ');

			int quantity = int.Parse(temp[1]);
			int moveFrom = int.Parse(temp[3]) - 1;
			int moveTo = int.Parse(temp[5]) - 1;

			int op = 0;

			if (false)
			{
				while (op < quantity)
				{
					op++;
					var stackFrom = stacks[moveFrom];
					var stackTo = stacks[moveTo];

					char crate = stackFrom.Pop();
					stackTo.Push(crate);
				}
			}
			else
			{
				Stack<char> doo = new Stack<char>();
				var stackTo = stacks[moveTo];
				while (op < quantity)
				{
					op++;
					var stackFrom = stacks[moveFrom];

					char crate = stackFrom.Pop();
					doo.Push(crate);
				}

				for (int i = 0; i < quantity; i++)
				{
					char foo = doo.Pop();
					stackTo.Push(foo);
				}
			}

			Console.WriteLine(line);
		}

		string f = null;

		f += stack1.ElementAt(0);
		f += stack2.ElementAt(0);
		f += stack3.ElementAt(0);
		f += stack4.ElementAt(0);
		f += stack5.ElementAt(0);
		f += stack6.ElementAt(0);
		f += stack7.ElementAt(0);
		f += stack8.ElementAt(0);
		f += stack9.ElementAt(0);


		Console.WriteLine(f);
	}
}