using System.Collections.Generic;
using System.Linq;
using KataBowling2.Frames;


namespace KataBowling2
{
	public class Line
	{
		private List<MinimumFrame> Frames { get; } = new List<MinimumFrame>();

		public void AddFrame(MinimumFrame frame) => Frames.Add(frame);

		public virtual int Score() => Frames.Sum(frame => frame.Score());
	}
}