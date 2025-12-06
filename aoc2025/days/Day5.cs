namespace aoc2025.days
{
	class Day5
	{
		public static void Puzzle1()
		{
			string[] foodDatabase = Helpers.GetFileData(5);
			long[][] freshIDs = ParseFreshIDs(foodDatabase);
			long[] availableIDs = ParseAvailableIDs(foodDatabase);

			int freshCount = 0;
			
			for (int i = 0; i < freshIDs.Length; i++)
			{
				for (int j = 0; j < availableIDs.Length; j++)
				{
					if (availableIDs[j] != -1 && availableIDs[j] >= freshIDs[i][0] && availableIDs[j] <= freshIDs[i][1])
					{
						freshCount++;
						availableIDs[j] = -1;
					}
				}
			}

			Console.WriteLine("Answer: " + freshCount);
		}

		public static void Puzzle2()
		{
			string[] foodDatabase = Helpers.GetFileData(5);
			long[][] freshIDs = ParseFreshIDs(foodDatabase);
			Array.Sort(freshIDs, (a, b) => a[0].CompareTo(b[0]));
			int totalFreshIDs = 0;

			
		}

		private static long[][] ParseFreshIDs(string[] IDs)
		{
			int blankIdx = 0;
			for (int i = 0; i < IDs.Length; i++)
			{
				if(IDs[i] == "")
				{
					blankIdx = i;
					break;
				}
			}

			long[][] ranges = new long[blankIdx][];
			for (int i = 0; i < blankIdx; i++)
			{
				string[] parts = IDs[i].Split('-');
				ranges[i] = new long[] { long.Parse(parts[0]), long.Parse(parts[1]) };
			}

			return ranges;
		}

		private static long[] ParseAvailableIDs(string[] IDs)
		{
			int blankIdx = 0;
			for (int i = 0; i < IDs.Length; i++)
			{
				if(IDs[i] == "")
				{
					blankIdx = i;
					break;
				}
			}

			int availableCount = IDs.Length - blankIdx - 1;
			long[] available = new long[availableCount];
			for (int i = 0; i < availableCount; i++)
			{
				available[i] = long.Parse(IDs[blankIdx + 1 + i]);
			}

			return available;
		}
	}
}
