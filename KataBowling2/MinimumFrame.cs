namespace KataBowling2
{
	public class MinimumFrame
	{
		protected Roll FirstRoll { get; }

		public MinimumFrame(Roll firstRoll)
		{
			FirstRoll = firstRoll;
		}

		public virtual int Score()
		{
			return FirstRoll.KnockedPins;
		}
	}
}