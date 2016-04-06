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
			return BuiltLine();
		}

		private static Line BuiltLine()
		{
			for (Index = 0; Index < RawLine.Length; Index += 2)
			{
				if (IsStrike())
					AddStrikeFrame();
				else if (IsSpare())
					AddSpareFrame();
				else
					AddFrame();

				if (ThereAreNoMoreFrames()) break;
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
			Index -= 1;
		}

		private static bool ThereAreNoMoreFrames()
		{
			if (BuildRoll.From(RawLine[Index + 1]).KnockedPins == 10 && Index + 4 == RawLine.Length) return true;
			if (Index + 3 == RawLine.Length) return true;
			return false;
		}
	}
}