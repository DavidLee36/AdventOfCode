namespace aoc2025.days
{
	class Day4
	{
		public static void Puzzle1()
		{
			char[][] floorMap = Helpers.GetFileData2DChar(4);
			int accessibleRolls = 0;

			for (int i = 0; i < floorMap.Length; i++)
			{
				for (int j = 0; j < floorMap[i].Length; j++)
				{
					if (floorMap[i][j] == '.') continue;
					int surroundedCount = 0;
					for (int k = i - 1; k < i + 2; k++)
					{
						for (int l = j - 1; l < j + 2; l++)
						{
							if (k == i && j == l) continue;
							try
							{
								if (floorMap[k][l] == '@') surroundedCount++;
							}
							catch { }
						}
					}
					if (surroundedCount < 4) accessibleRolls++;
				}
			}
			Console.WriteLine("Answer: " + accessibleRolls);
		}

		public static void Puzzle2()
		{
			char[][] floorMap = Helpers.GetFileData2DChar(4, false);
			int accessibleRolls = 0;
			int removed;
			int totalPasses = 0;
			do
			{
				totalPasses++;
				removed = 0; // Reset the count for how many rolls are removed each pass
				for (int i = 0; i < floorMap.Length; i++) // Looping through 2D array
				{
					for (int j = 0; j < floorMap[i].Length; j++)
					{
						if (floorMap[i][j] == '.') continue; // We are looking at a blank spot on the floor
						int surroundedCount = 0;
						for (int k = i - 1; k < i + 2; k++)
						{
							for (int l = j - 1; l < j + 2; l++) // Check each surrounding floor tile
							{
								if (k == i && j == l) continue; // Do not count the current tile being processed
								try // This will result in an out of bounds exception when looking at an edge tile
								{
									if (floorMap[k][l] == '@') surroundedCount++;
								}
								catch { } // Ignore
							}
						}
						if (surroundedCount < 4) // If there are less than 4 rolls surrounding the current roll
						{
							accessibleRolls++;
							removed++; // Increase the amount of removed rolls this pass
							floorMap[i][j] = '.'; // Remove the current roll from the floor
						}
					}
				}
			} while (removed > 0); // If during a pass no rolls were removed, we've reached the end

			Console.WriteLine("Answer: " + accessibleRolls);
			Console.WriteLine("Total passes: " + totalPasses);
		}
	}
}