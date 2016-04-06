namespace KataBowling2
{
	public class BuildLine
	{
		private static string RawLine { get; set; }
		private static Line Line { get; set; }
		public static int Index { get; set; }

		public static Line From(string rawLine)
		{
			Line = new Line();
			RawLine = rawLine;

			for (var i = 0; i < rawLine.Length; i += 2)
			{
				Index = i;

				if (IsStrike(FirstRoll()))
				{
					AddStrikeFrame(FirstRoll(), i);
					i -= 1;
				} else if (IsSpare(SecondRoll()))
					AddSpareFrame(SecondRoll(), FirstRoll(), i);
				else
					Line.AddFrame(new Frame(FirstRoll(), SecondRoll()));

				if (IsStrike(FirstRoll()) && i + 4 == rawLine.Length) break;
				if (i + 3 == rawLine.Length) break;
			}

			return Line;
		}

		private static Roll FirstRoll() => BuildRoll.From(RawLine[Index]);

		private static Roll SecondRoll() => BuildRoll.From(RawLine[Index + 1]);

		private static bool IsSpare(Roll secondRoll) => secondRoll.KnockedPins == 10;

		private static bool IsStrike(Roll firstRoll) => firstRoll.KnockedPins == 10;

		private static void AddSpareFrame(Roll secondRoll, Roll firstRoll, int index)
		{
			secondRoll.NextRoll = BuildRoll.From(RawLine[index + 2]);
			secondRoll.KnockedPins -= firstRoll.KnockedPins;
			Line.AddFrame(new SpareFrame(firstRoll, secondRoll));
		}

		private static void AddStrikeFrame(Roll firstRoll, int index)
		{
			firstRoll.NextRoll = BuildRoll.From(RawLine[index + 1]);
			firstRoll.NextRoll.NextRoll = BuildRoll.From(RawLine[index + 2]);
			Line.AddFrame(new StrikeFrame(firstRoll));
		}
	}
}