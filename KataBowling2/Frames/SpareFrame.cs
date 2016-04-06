namespace KataBowling2.Frames
{
	public class SpareFrame : Frame
	{
		public SpareFrame(Roll firstRoll, Roll secondRoll) : base(firstRoll, secondRoll) {}

		public override int Score() => base.Score() + NextRoll();

		private int NextRoll() => SecondRoll.NextRoll.KnockedPins;
	}
}