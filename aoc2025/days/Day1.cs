using System.IO;

namespace aoc2025.days
{
	class Day1
	{
		static string document = @"C:\Users\david\Desktop\Projects\AdventOfCode\aoc2025\inputs\Day1.txt";
		public static void Puzzle1()
		{
			string[] rotations = File.ReadAllLines(document);
			int dialLocation = 50;
			int answer = 0;

			foreach (string rotation in rotations)
			{
				bool dir = rotation[0] == 'R'; // R = true, L = false
				int clicks = int.Parse(rotation.Substring(1)) % 100;

				if (dir) // Rotate right
				{
					dialLocation += clicks;
					if (dialLocation > 99)
					{
						dialLocation -= 100;
					}
					//Console.WriteLine($"Moving right {clicks} clicks, ended at: {dialLocation}");
				}
				else // Rotate Left
				{
					dialLocation -= clicks;
					if (dialLocation < 0)
					{
						dialLocation = 100 - Math.Abs(dialLocation);
					}
					//Console.WriteLine($"Moving left {clicks} clicks, ended at: {dialLocation}");
				}
				if (dialLocation == 0)
				{
					answer++;
					//Console.WriteLine("Found a 0, current 0 count: " + answer);
				}
			}
			Console.WriteLine("answer: " + answer);
		}

		public static void Puzzle2()
		{
			string[] rotations = File.ReadAllLines(document);
			int startingPoint = 50;
			int currentLocation = startingPoint;
			int counter = 0;

			foreach (var line in rotations)
			{
				var direction = line[0] == 'L' ? -1 : 1;
				var distance = int.Parse(line[1..]);

				var fullRotations = distance / 100;
				counter += fullRotations;

				var startLocation = currentLocation;

				currentLocation += direction * (distance % 100);

				if (startLocation != 0 && (currentLocation < 0 || currentLocation > 100))
				{
					counter++;
				}

				currentLocation %= 100;
				if (currentLocation < 0)
				{
					currentLocation += 100;
				}

				if (startLocation != 0 && currentLocation == 0)
				{
					counter++;
				}
			}

			Console.WriteLine("Number of passes past 0: " + counter);
		}
		
		public static void Puzzl1Improved()
		{
			string[] rotations = File.ReadAllLines(document);
			int dial = 50;
			int counter = 0;

			foreach (string rotation in rotations)
			{
				int distance = int.Parse(rotation.Replace("L", "-").Replace("R", ""));

				dial += distance; // Move dial completely
				dial %= 100; // Convert dial to be 0-99

				if (dial == 0)
				{
					counter++;
				}
			}

			Console.WriteLine("Answer: " + counter);
		}

		public static void Puzzle2Improved()
		{
			string[] rotations = File.ReadAllLines(document);
			int start = 50;
			int dial = start;
			int counter = 0;

			foreach (string rotation in rotations)
			{
				int turn = int.Parse(rotation.Replace("L", "-").Replace("R", ""));

				int fullRotations;
				if (turn > 0) fullRotations = Math.Abs(turn) / 100;
				else fullRotations = Math.Abs(turn) / -100;
				counter += fullRotations;
				turn %= 100;

				dial += turn; // Move dial completely
				dial %= 100; // Convert dial to be 0-99

				if (dial == 0)
				{
					counter++;
				}
			}

			Console.WriteLine("Answer: " + counter);
		}
	}
}
