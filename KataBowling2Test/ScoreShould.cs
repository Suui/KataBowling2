using FluentAssertions;
using KataBowling2;
using NUnit.Framework;


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

			line = BuildLine.From("X11----------------");
			line.Score().Should().Be(14);
		}

		[Test]
		public void calculate_acceptance_scores()
		{
			var line = BuildLine.From("11111111111111111111");
			line.Score().Should().Be(20);

			line = BuildLine.From("9-9-9-9-9-9-9-9-9-9-");
			line.Score().Should().Be(90);

			line = BuildLine.From("5/5/5/5/5/5/5/5/5/5/5");
			line.Score().Should().Be(150);

			line = BuildLine.From("XXXXXXXXXXXX");
			line.Score().Should().Be(300);
		}
	}
}
