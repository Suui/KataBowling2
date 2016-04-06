namespace KataBowling2
{
	public class BuildRoll
	{
		public static Roll From(char rawRoll)
		{
			if (rawRoll == '-') return new Roll(0);
			return new Roll(int.Parse(rawRoll.ToString()));
		}
	}
}