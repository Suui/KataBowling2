namespace KataBowling2.Builders
{
	public class BuildRoll
	{
		public static Roll From(char rawRoll)
		{
			if (rawRoll == 'X' || rawRoll == '/') return new Roll(10);
			if (rawRoll == '-') return new Roll(0);
			return new Roll(int.Parse(rawRoll.ToString()));
		}
	}
}