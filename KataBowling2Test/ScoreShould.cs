using FluentAssertions;
using KataBowling2;
using NUnit.Framework;

/* TODO
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

		[Test]
		public void calculate_the_score_for_spare_frames()
		{
			var line = BuildLine.From("-/------------------");
			line.Score().Should().Be(10);

			line = BuildLine.From("1/------------------");
			line.Score().Should().Be(10);

			line = BuildLine.From("1/1-----------------");
			line.Score().Should().Be(12);
		}

		[Test]
		public void calculate_the_score_for_strike_frames()
		{
			var line = BuildLine.From("X------------------");
			line.Score().Should().Be(10);

			line = BuildLine.From("X1-----------------");
			line.Score().Should().Be(12);
		}
	}
}
