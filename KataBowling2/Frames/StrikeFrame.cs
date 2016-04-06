namespace KataBowling2.Frames
{
	public class StrikeFrame : MinimumFrame
	{
		public StrikeFrame(Roll firstRoll) : base(firstRoll) {}

		public override int Score() => base.Score() + TwoNextRolls();

		private int TwoNextRolls() => FirstRoll.NextRoll.KnockedPins + FirstRoll.NextRoll.NextRoll.KnockedPins;
	}
}