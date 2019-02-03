using Coding.Problem.Bowling.Contract;
using Coding.Problem.Bowling.Model;

namespace Coding.Problem.Bowling.Rules
{
    internal class StrikeRule : IRule
    {
        public int Apply(BaseFrame frame)
        {
            if (frame.IsFinalFrame)
            {
                return frame.Score.TotalScore;
            }
            else
            {
                var score = frame.Score.FirstTry;

                var nextFrame = (frame as BowlingFrame).NextFrame;
                if (nextFrame == null)
                    return score;

                score = score + nextFrame.Score.FirstTry;

                if (nextFrame.IsFinalFrame)
                    return score + nextFrame.Score.SecondTry;

                if (nextFrame.IsStrike == false)
                    return score + nextFrame.Score.SecondTry;
                else
                {
                    var nextToNextFrame = nextFrame.NextFrame;
                    return nextToNextFrame != null
                        ? score + nextToNextFrame.Score.FirstTry
                        : score;
                }
            }
        }
    }
}
