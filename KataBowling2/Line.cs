using System.Collections.Generic;


namespace KataBowling2
{
	public class Line
	{
		private List<MinimumFrame> Frames { get; } = new List<MinimumFrame>();

		public void AddFrame(MinimumFrame frame) => Frames.Add(frame);

		public virtual int Score()
		{
			var score = 0;
			Frames.ForEach(frame => score += frame.Score());
			return score;
		}
	}
}