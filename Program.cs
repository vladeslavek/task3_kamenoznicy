namespace task3_kamenoznicy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                CheckArgs(args);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }

            HMACGenerator computerMove = new(args.Length);
            while (true)
            {
                Console.WriteLine($"HMAC: {computerMove.HMACValue}");
                Console.WriteLine("Moves menu:");
                for (int i = 0; i < args.Length; i++)
                {
                    Console.WriteLine($"{i + 1}. {args[i]}");
                }
                Console.WriteLine("0. exit\n?. help");
                string input = GetValidInput(args.Count());
                switch (input)
                {
                    case "0":
                        {
                            Environment.Exit(0);
                            break;    
                        }
                    case "?":
                        {
                            Table table = new(args);
                            Console.WriteLine(table.ToString());
                            break;
                        }
                    default:
                        {
                            int move = int.Parse(input)-1;
                            Console.WriteLine($"Your move: {args[move]}");
                            Console.WriteLine($"Computer move: {args[computerMove.SelectedMove]}");
                            Console.WriteLine(GetResult(move, computerMove.SelectedMove, args.Length));
                            Console.WriteLine($"HMAC key: {computerMove.HMACKey}");
                            computerMove = new(args.Length);
                            break;
                        }
                }
                Console.WriteLine("/////");
            }

        }

        static string GetResult(int userMove, int computerMove, int argsCount)
        {
            if (userMove == computerMove)
            {
                return "Tie!";
            }
            else
            {
                string row = Table.GetStartString(argsCount);
                while (row[userMove] != '0')
                {
                    row = Table.ShiftString(row);
                }
                if (row[computerMove] == '1')
                {
                    return "You win!";
                }
                else
                {
                    return "You lose!";
                }
            }
        }

        static string GetValidInput(int argsCount)
        {
            string input = "";
            Console.WriteLine("Enter your move:");
            while (true)
            {
                input = Console.ReadLine();
                if (input == "?") break;
                else if (int.TryParse(input, out int result) && result >= 0 && result <= argsCount) break;
                else Console.WriteLine("Invalid input. Enter your move:");
            }

            return input;
        }

        static void CheckArgs(string[] args)
        {
            if (args.Length < 3)
            {
                throw new Exception("Error: Invalid amount of arguments, argument amount must be an odd value larger than 2. ");
            }
            else if (args.Length % 2 == 0)
            {
                throw new Exception("Error: Amount of arguments must be odd.");
            }
            else if (!isDistinct(args))
            {
                throw new Exception("Error: Input must not contain duplicate arguments.");
            }
        }

        static bool isDistinct(string[] arr)
        {
            HashSet<string> s = new(arr);
            return (s.Count == arr.Length);
        }
    }
}