namespace KataBowling2
{
	public class Roll
	{
		public int KnockedPins { get; set; }
		public Roll Next { get; set; }

		public Roll(int knockedPins)
		{
			KnockedPins = knockedPins;
		}
	}
}