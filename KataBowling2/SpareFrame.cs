namespace KataBowling2
{
	public class SpareFrame : Frame
	{
		public SpareFrame(Roll firstRoll, Roll secondRoll) : base(firstRoll, secondRoll) {}

		public override int Score()
		{
			return base.Score() + SecondRoll.NextRoll.KnockedPins;
		}
	}
}