using Coding.Problem.Bowling.Contract;
using Coding.Problem.Bowling.Model;
using Coding.Problem.Bowling.Rules;

namespace Coding.Problem.Bowling
{
    internal class ScoreRuleFactory
    {
        internal static IRule GetRuleToApply(BowlingFrame frame)
        {
            if (frame.IsStrike)
                return new StrikeRule();

            else if (frame.IsSpare)
                return new SpareRule();

            return new BasicRule();
        }
    }
}
