namespace KataBowling2
{
	public class BuildLine
	{
		private static string RawLine { get; set; }
		private static Line Line { get; set; }

		public static Line From(string rawLine)
		{
			Line = new Line();
			RawLine = rawLine;

			for (var i = 0; i < rawLine.Length; i += 2)
			{
				var firstRoll = BuildRoll.From(rawLine[i]);
				var secondRoll = BuildRoll.From(rawLine[i+1]);

				if (IsStrike(firstRoll))
				{
					AddStrikeFrame(firstRoll, i);
					i -= 1;
				} else if (IsSpare(secondRoll))
					AddSpareFrame(secondRoll, firstRoll, i);
				else
					Line.AddFrame(new Frame(firstRoll, secondRoll));
			}

			return Line;
		}

		private static void AddStrikeFrame(Roll firstRoll, int index)
		{
			firstRoll.Next = BuildRoll.From(RawLine[index + 1]);
			firstRoll.Next.Next = BuildRoll.From(RawLine[index + 2]);
			Line.AddFrame(new StrikeFrame(firstRoll));
		}

		private static bool IsStrike(Roll firstRoll)
		{
			return firstRoll.KnockedPins == 10;
		}

		private static void AddSpareFrame(Roll secondRoll, Roll firstRoll, int index)
		{
			secondRoll.Next = BuildRoll.From(RawLine[index + 2]);
			secondRoll.KnockedPins -= firstRoll.KnockedPins;
			Line.AddFrame(new SpareFrame(firstRoll, secondRoll));
		}

		private static bool IsSpare(Roll secondRoll)
		{
			return secondRoll.KnockedPins == 10;
		}
	}
}