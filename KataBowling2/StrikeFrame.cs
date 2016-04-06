namespace KataBowling2
{
	public class StrikeFrame : MinimumFrame
	{
		public StrikeFrame(Roll firstRoll) : base(firstRoll) {}

		public override int Score()
		{
			return base.Score() + FirstRoll.Next.KnockedPins + FirstRoll.Next.Next.KnockedPins ;
		}
	}
}