﻿namespace KataBowling2
{
	public class StrikeFrame : MinimumFrame
	{
		public StrikeFrame(Roll firstRoll) : base(firstRoll) {}

		public override int Score() => base.Score() + TwoNextRolls();

		private int TwoNextRolls() => FirstRoll.Next.KnockedPins + FirstRoll.Next.Next.KnockedPins;
	}
}