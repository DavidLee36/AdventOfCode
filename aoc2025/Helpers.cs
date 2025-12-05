namespace aoc2025
{
	public class Helpers()
	{
		public static string[] GetFileData(int day, bool useSample = false)
		{
			string path = @$"C:\Users\david\Desktop\Projects\AdventOfCode\aoc2025\inputs\Day{day}{(useSample ? "Sample" : "")}.txt";
			return File.ReadAllLines(path);
		}

		public static int[][] GetFileData2DInt(int day, bool useSample = false)
		{
			string[] data = GetFileData(day, useSample);
			int[][] result = new int[data.Length][];

			for (int i = 0; i < data.Length; i++)
			{
				result[i] = data[i].Select(c => c - '0').ToArray();
			}

			return result;
		}

		public static char[][] GetFileData2DChar(int day, bool useSample = false)
		{
			string[] data = GetFileData(day, useSample);
			char[][] result = new char[data.Length][];

			for (int i = 0; i < data.Length; i++)
			{
				result[i] = data[i].ToArray();
			}

			return result;
		}
	}
}