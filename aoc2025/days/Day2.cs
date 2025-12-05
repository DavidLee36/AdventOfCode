namespace aoc2025.days
{
	class Day2
	{
		public static void Puzzle1()
		{
			string input = Helpers.GetFileData(2)[0];
			string[] idRanges = input.Split(",");
			long answer = 0;
			foreach (string idRange in idRanges)
			{
				long[] range = GetRange(idRange);
				for (long i = range[0]; i <= range[1]; i++)
				{
					string rString = i.ToString();
					string num1 = rString.Substring(0, rString.Length / 2);
					string num2 = rString.Substring(rString.Length / 2);
					if (num1 == num2) answer += i;
				}
			}
			Console.WriteLine("Answer: " + answer);
		}

		public static void Puzzle2()
		{
			string input = Helpers.GetFileData(2)[0];
			string[] idRanges = input.Split(",");
			long answer = 0;
			foreach (string idRange in idRanges) // Check each id range
			{
				long[] range = GetRange(idRange);
				for (long i = range[0]; i <= range[1]; i++) // for each id
				{
					string rString = i.ToString();
					for (int j = 2; j <= rString.Length; j++) // Split the ID into as many portions as possible
					{
						if (rString.Length % j != 0) continue; // if the ID cannot be evenly split into j amount of groups, skip
						bool found = true;
						string[] portions = new string[j];
						for (int k = 0; k < portions.Length; k++) // Split the ID evenly in to j portions
						{
							int start = k == 0 ? 0 : portions[k - 1].Length * k;
							portions[k] = rString.Substring(start, rString.Length / j);
						}
						for (int l = 0; l < portions.Length; l++) // Compare each portion
						{
							if (portions[0] != portions[l])
							{
								found = false;
							}
						}
						if (found) // TEEHEE invalid ID found, stupid Elf
						{
							Console.WriteLine($"{rString} split into {j} portions is: {string.Join(", ", portions)}");
							Console.WriteLine("WINNER WINNER CHICKEN DINNER");
							answer += i;
							break;
						}
					}
				}
			}
			Console.WriteLine("Answer: " + answer);
		}
		private static long[] GetRange(string range)
		{
			int idx = range.IndexOf("-");
			return new[] { long.Parse(range.Substring(0, idx)), long.Parse(range.Substring(idx + 1)) };
		}
	}
}