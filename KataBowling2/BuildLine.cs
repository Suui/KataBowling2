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

				if (IsStrike())
				{
					AddStrikeFrame();
					i -= 1;
				} else if (IsSpare())
					AddSpareFrame();
				else
					AddFrame();

				if (IsStrike() && i + 4 == rawLine.Length) break;
				if (i + 3 == rawLine.Length) break;
			}

			return Line;
		}

		private static Roll FirstRoll() => BuildRoll.From(RawLine[Index]);

		private static Roll SecondRoll() => BuildRoll.From(RawLine[Index + 1]);

		private static bool IsSpare() => SecondRoll().KnockedPins == 10;

		private static bool IsStrike() => FirstRoll().KnockedPins == 10;

		private static void AddFrame()
		{
			Line.AddFrame(new Frame(FirstRoll(), SecondRoll()));
		}

		private static void AddSpareFrame()
		{
			var secondRoll = SecondRoll();
			secondRoll.NextRoll = BuildRoll.From(RawLine[Index + 2]);
			secondRoll.KnockedPins -= FirstRoll().KnockedPins;
			Line.AddFrame(new SpareFrame(FirstRoll(), secondRoll));
		}

		private static void AddStrikeFrame()
		{
			var firstRoll = FirstRoll();
			firstRoll.NextRoll = BuildRoll.From(RawLine[Index + 1]);
			firstRoll.NextRoll.NextRoll = BuildRoll.From(RawLine[Index + 2]);
			Line.AddFrame(new StrikeFrame(firstRoll));
		}
	}
}