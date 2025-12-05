using System.Runtime.Serialization.Formatters;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace aoc2025.days
{

	/// <summary>
	/// I'm thinking this will be 2 pointer problem start at idx 0 and 1 and move r to the right, if any point r > l then l = r (ie. 31 > 29)
	/// </summary>

	class Day3
	{
		public static void Puzzle1()
		{
			int[][] batteries = Helpers.GetFileData2DInt(3);
			int totalJoltage = 0;

			foreach (int[] battery in batteries)
			{
				int l = 0;
				int r = 1;
				int maxJoltage = 0;

				while (r < battery.Length)
				{
					int currJoltage = battery[l] * 10 + battery[r];
					if (currJoltage > maxJoltage) maxJoltage = currJoltage;

					if (battery[r] > battery[l]) l = r;
					r++;
				}
				totalJoltage += maxJoltage;
			}

			Console.WriteLine("Answer: " + totalJoltage);
		}

		/// <summary>
		/// Greedy algorithm: Find the largest number from left to right going from the starting point
		/// to the end of the array subtracted by the remaining digits to find.
		/// ex for this case: Our first number can look from idx 0 - 88 (100-12) then say we find a 9
		/// at idx 37, then the second number we can look from is 38 - 89 (100-11)
		/// </summary>
		public static void Puzzle2()
		{
			int[][] batteries = Helpers.GetFileData2DInt(3);
			long totalJoltage = 0;

			foreach (int[] battery in batteries)
			{
				StringBuilder sb = new StringBuilder();
				int startingPoint = 0;
				for (int i = 12; i > 0; i--) // Start at 12 and work left to right 
				{
					int currMax = 0;
					for (int j = startingPoint; j < battery.Length - i + 1; j++) // Find the highest number in the range from starting -> end of array - the amount of digits we still need to find
					{
						if (battery[j] > currMax)
						{
							currMax = battery[j];
							startingPoint = j+1;
						}
						if (currMax == 9) break; // We can't get better than 9
					}
					sb.Append(currMax);
				}
				Console.WriteLine("Current joltage: " + sb.ToString());
				totalJoltage += long.Parse(sb.ToString());
			}
			Console.WriteLine("Answer: " + totalJoltage);
		}
	}
}