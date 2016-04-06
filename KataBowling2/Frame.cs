namespace KataBowling2
{
	public class Frame : MinimumFrame
	{
		protected Roll SecondRoll { get; }

		public Frame(Roll firstRoll, Roll secondRoll) : base(firstRoll)
		{
			SecondRoll = secondRoll;
		}

		public override int Score()
		{
			return base.Score() + SecondRoll.KnockedPins;
		}
	}
}