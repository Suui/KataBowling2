namespace KataBowling2
{
	public class Frame
	{
		protected Roll FirstRoll { get; }
		protected Roll SecondRoll { get; }

		public Frame(Roll firstRoll, Roll secondRoll)
		{
			FirstRoll = firstRoll;
			SecondRoll = secondRoll;
		}

		public virtual int Score()
		{
			return FirstRoll.KnockedPins + SecondRoll.KnockedPins;
		}
	}
}