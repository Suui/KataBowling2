namespace KataBowling2.Frames
{
	public class Frame : MinimumFrame
	{
		protected Roll SecondRoll { get; }

		public Frame(Roll firstRoll, Roll secondRoll) : base(firstRoll)
		{
			SecondRoll = secondRoll;
		}

		public override int Score() => base.Score() + SecondRoll.KnockedPins;
	}
}