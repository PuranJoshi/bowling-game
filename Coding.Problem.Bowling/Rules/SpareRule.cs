using Coding.Problem.Bowling.Contract;
using Coding.Problem.Bowling.Model;

namespace Coding.Problem.Bowling.Rules
{
    internal class SpareRule : IRule
    {
        public int Apply(BaseFrame frame)
        {
            if (frame.IsFinalFrame)
            {
                return frame.Score.TotalScore;
            }
            else
            {
                var score = frame.Score.FirstTry + frame.Score.SecondTry;

                var nextFrame = (frame as BowlingFrame).NextFrame;

                return nextFrame != null
                       ? score + nextFrame.Score.FirstTry
                       : score;
            }
        }
    }
}
