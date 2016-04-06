using System.Collections.Generic;


namespace KataBowling2
{
	public class Line
	{
		private List<Frame> Frames { get; } = new List<Frame>();

		public void AddFrame(Frame frame) => Frames.Add(frame);

		public virtual int Score()
		{
			var score = 0;
			Frames.ForEach(frame => score += frame.Score());
			return score;
		}
	}
}