using ConsoleTables;

namespace task3_kamenoznicy
{
	class Table
	{
		ConsoleTable table;

		public static string ShiftString(string t)
		{
			return t.Substring(t.Length - 1, 1) + t.Substring(0, t.Length - 1);
		}

		public static string GetStartString(int numberOfArgs)
		{
			string rows = "0";
			for (int i = 1; i <= numberOfArgs / 2; i++)
			{
				rows += '1';
			}
			for (int i = numberOfArgs / 2 + 1; i < numberOfArgs; i++)
			{
				rows += '2';
			}
			return rows;
		}

		private string[] CreateResultRow(string result, string argument)
		{
			string[] row = new string[result.Length + 1];
			row[0] = argument;
			for (int i = 0; i < result.Length; i++)
			{
				switch (result[i])
				{
					case ('0'):
						{
							row[i + 1] = "Tie";
							break;
						}
					case ('1'):
						{
							row[i + 1] = "Win";
							break;
						}
					default:
						{
							row[i + 1] = "Draw";
							break;
						}
				}
			}
			return row;
		}

		private string[] CreateRow(string[] args, string firstArgument)
		{
			string[] firstRow = new string[args.Length + 1];
			firstRow[0] = firstArgument;
			for (int i = 0; i < args.Length; i++)
			{
				firstRow[i + 1] = args[i];
			}
			return firstRow;
		}

		private void FillTable(string[] args)
		{
			string result = GetStartString(args.Length);
			table = new ConsoleTable(CreateRow(args, "You/PC"));
			for (int i = 0; i < args.Length; i++)
			{
				table.AddRow(CreateResultRow(result, args[i]));
				result = ShiftString(result);
			}
		}

		public Table(string[] args)
		{
			FillTable(args);
		}

		public override string ToString()
		{
			return table.ToStringAlternative();
		}

	}
}