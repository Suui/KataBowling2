namespace KataBowling2
{
	public class Frame
	{
		private Roll FirstRoll { get; }
		private Roll SecondRoll { get; }

		public Frame(Roll firstRoll, Roll secondRoll)
		{
			FirstRoll = firstRoll;
			SecondRoll = secondRoll;
		}

		public int Score()
		{
			return FirstRoll.KnockedPins + SecondRoll.KnockedPins;
		}
	}
}