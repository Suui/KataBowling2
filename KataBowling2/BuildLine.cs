namespace KataBowling2
{
	public class BuildLine
	{
		public static Line From(string rawLine)
		{
			var line = new Line();

			for (var i = 0; i < rawLine.Length; i += 2)
			{
				var firstRoll = BuildRoll.From(rawLine[i]);
				var secondRoll = BuildRoll.From(rawLine[i+1]);
				line.AddFrame(new Frame(firstRoll, secondRoll));
			}

			return line;
		}
	}
}