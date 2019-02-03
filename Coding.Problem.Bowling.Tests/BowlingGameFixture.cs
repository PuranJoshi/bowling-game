using System.Collections.Generic;
using Xunit;

namespace Coding.Problem.Bowling.Tests
{
    public class BowlingGameFixture
    {
        [Fact(DisplayName ="Final frame is neither spare not strike")]
        public void BowlingGame_FullGame_FinalScore_1()
        {
            #region ARRANGE
            var bowlingGame = new BowlingGame();
            var throwBalls
                = new List<int> { 10, 5, 4, 0, 10, 10, 10, 10, 5, 5, 3, 2, 0, 1, 9, 0};
            #endregion

            #region ACT
            throwBalls.ForEach(@throw => {
                bowlingGame.ThrowBall(@throw);
            });
            #endregion

            #region ASSERT
            Assert.Equal(19, bowlingGame.GetFrameScore(1));
            Assert.Equal(9, bowlingGame.GetFrameScore(2));
            Assert.Equal(20, bowlingGame.GetFrameScore(3));
            Assert.Equal(30, bowlingGame.GetFrameScore(4));
            Assert.Equal(25, bowlingGame.GetFrameScore(5));
            Assert.Equal(20, bowlingGame.GetFrameScore(6));
            Assert.Equal(13, bowlingGame.GetFrameScore(7));
            Assert.Equal(5, bowlingGame.GetFrameScore(8));
            Assert.Equal(1, bowlingGame.GetFrameScore(9));
            Assert.Equal(9, bowlingGame.GetFrameScore(10));
            Assert.Equal(151, bowlingGame.GetFinalScore());
            #endregion
        }

        [Fact(DisplayName = "Final frame is a spare")]
        public void BowlingGame_FullGame_FinalScore_2()
        {
            #region ARRANGE
            var bowlingGame = new BowlingGame();
            var throwBalls
                = new List<int> { 10, 5, 4, 0, 10, 10, 10, 10, 5, 5, 3, 2, 0, 1, 10, 0, 9 };
            #endregion

            #region ACT
            throwBalls.ForEach(@throw => {
                bowlingGame.ThrowBall(@throw);
            });
            #endregion

            #region ASSERT
            Assert.Equal(19, bowlingGame.GetFrameScore(1));
            Assert.Equal(9, bowlingGame.GetFrameScore(2));
            Assert.Equal(20, bowlingGame.GetFrameScore(3));
            Assert.Equal(30, bowlingGame.GetFrameScore(4));
            Assert.Equal(25, bowlingGame.GetFrameScore(5));
            Assert.Equal(20, bowlingGame.GetFrameScore(6));
            Assert.Equal(13, bowlingGame.GetFrameScore(7));
            Assert.Equal(5, bowlingGame.GetFrameScore(8));
            Assert.Equal(1, bowlingGame.GetFrameScore(9));
            Assert.Equal(19, bowlingGame.GetFrameScore(10));
            Assert.Equal(161, bowlingGame.GetFinalScore());
            #endregion
        }

        [Fact(DisplayName = "Final frame is an strike")]
        public void BowlingGame_FullGame_FinalScore_3()
        {
            #region ARRANGE
            var bowlingGame = new BowlingGame();
            var throwBalls
                = new List<int> { 10, 5, 4, 0, 10, 10, 10, 10, 5, 5, 3, 2, 0, 1, 10, 10, 9 };
            #endregion

            #region ACT
            throwBalls.ForEach(@throw => {
                bowlingGame.ThrowBall(@throw);
            });
            #endregion

            #region ASSERT
            Assert.Equal(19, bowlingGame.GetFrameScore(1));
            Assert.Equal(9, bowlingGame.GetFrameScore(2));
            Assert.Equal(20, bowlingGame.GetFrameScore(3));
            Assert.Equal(30, bowlingGame.GetFrameScore(4));
            Assert.Equal(25, bowlingGame.GetFrameScore(5));
            Assert.Equal(20, bowlingGame.GetFrameScore(6));
            Assert.Equal(13, bowlingGame.GetFrameScore(7));
            Assert.Equal(5, bowlingGame.GetFrameScore(8));
            Assert.Equal(1, bowlingGame.GetFrameScore(9));
            Assert.Equal(29, bowlingGame.GetFrameScore(10));
            Assert.Equal(171, bowlingGame.GetFinalScore());
            #endregion
        }

        [Fact(DisplayName = "User input values even after final frame")]
        public void BowlingGame_FullGame_FinalScore_4()
        {
            #region ARRANGE
            var bowlingGame = new BowlingGame();
            var throwBalls
                = new List<int> { 10, 5, 4, 0, 10, 10, 10, 10, 5, 5, 3, 2, 0, 1, 9, 0, 9, 1, 5, 5 };
            #endregion

            #region ACT
            throwBalls.ForEach(@throw => {
                bowlingGame.ThrowBall(@throw);
            });
            #endregion

            #region ASSERT
            Assert.Equal(19, bowlingGame.GetFrameScore(1));
            Assert.Equal(9, bowlingGame.GetFrameScore(2));
            Assert.Equal(20, bowlingGame.GetFrameScore(3));
            Assert.Equal(30, bowlingGame.GetFrameScore(4));
            Assert.Equal(25, bowlingGame.GetFrameScore(5));
            Assert.Equal(20, bowlingGame.GetFrameScore(6));
            Assert.Equal(13, bowlingGame.GetFrameScore(7));
            Assert.Equal(5, bowlingGame.GetFrameScore(8));
            Assert.Equal(1, bowlingGame.GetFrameScore(9));
            Assert.Equal(9, bowlingGame.GetFrameScore(10));
            Assert.Null(bowlingGame.GetFrameScore(11));
            Assert.Equal(151, bowlingGame.GetFinalScore());
            #endregion
        }

        [Fact(DisplayName = "User input invalid value")]
        public void BowlingGame_FullGame_FinalScore_5()
        {
            #region ARRANGE
            var bowlingGame = new BowlingGame();
            #endregion

            #region ACT & ASSERT
            Assert.Throws<System.InvalidOperationException>(() => bowlingGame.ThrowBall(11));
            #endregion
        }
    }
}
