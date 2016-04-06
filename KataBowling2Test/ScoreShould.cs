using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;

/* TODO
	- "-/------------------" => 10
	- "1/------------------" => 10
	- "-/1-----------------" => 11
	- "X------------------" => 10
	- "X1-----------------" => 11
	- "X11----------------" => 12
	- "11111111111111111111" => 20
	- "9-9-9-9-9-9-9-9-9-9-" => 90
	- "5/5/5/5/5/5/5/5/5/5/5" => 150
	- "XXXXXXXXXXXX" => 300
*/

namespace KataBowling2Test
{
	[TestFixture]
	class ScoreShould
	{
		[Test]
		public void calculate_the_score_for_single_rolls()
		{
			var line = BuildLine.From("11--1-1-------------");
			line.Score().Should().Be(4);
		}
	}

	public class BuildLine
	{
		public static Line From(string rawLine)
		{
			var line = new Line();

			for (var i = 0; i < rawLine.Length; i += 2)
			{
				var firstRoll = BuildRoll.From(rawLine[i]);
				var secondRoll = BuildRoll.From(rawLine[i+1]);
				line.AddFrame(new Frame(firstRoll, secondRoll));
			}

			return line;
		}
	}

	public class BuildRoll
	{
		public static Roll From(char rawRoll)
		{
			if (rawRoll == '-') return new Roll(0);
			return new Roll(int.Parse(rawRoll.ToString()));
		}
	}

	public class Roll
	{
		public int KnockedPins { get; set; }

		public Roll(int knockedPins)
		{
			KnockedPins = knockedPins;
		}
	}

	public class Line
	{
		private List<Frame> Frames { get; } = new List<Frame>();

		public void AddFrame(Frame frame) => Frames.Add(frame);

		public int Score()
		{
			var score = 0;
			Frames.ForEach(frame => score += frame.Score());
			return score;
		}
	}

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
