using ApprovalTests;
using ApprovalTests.Reporters;

using NUnit.Framework;

namespace BowlingScorer
{
    [TestFixture]
    [UseReporter(typeof(DiffReporter))]
    public class BowlingScorerTests
    {
        [Test]
        public void GutterBallTest()
        {
            // arrange
            var game = new Game();

            // act
            for (var i = 0; i < 20; i++)
                game.Roll(0);

            // assert
            Assert.AreEqual(0, game.Score);
        }

        [Test]
        public void Roll_a_Five()
        {
            // arrange
            var game = new Game();

            // act
            game.Roll(5);

            // assert
            Assert.AreEqual(5, game.Score);
        }

        [Test]
        public void Roll_Three_and_Four()
        {
            // arrange
            var game = new Game();

            // act
            game.Roll(3);
            game.Roll(4);

            // assert
            Approvals.Verify(game);
        }

        [Test]
        public void Roll_Three_Times()
        {
            // arrange
            var game = new Game();

            // act
            game.Roll(3);
            game.Roll(4);
            game.Roll(5);

            // assert
            Approvals.Verify(game);
        }

        [Test]
        public void CompleteFrame()
        {
            var frame = new Frame(null);

            frame.Rolls.Add(1);
            Assert.IsFalse(frame.Complete);
            frame.Rolls.Add(1);
            Assert.IsTrue(frame.Complete);
        }
    }
}
