using Coding.Problem.Bowling.Contract;
using Coding.Problem.Bowling.Model;

namespace Coding.Problem.Bowling.Rules
{
    internal class BasicRule : IRule
    {
        public int Apply(BaseFrame frame)
        {
            return
                frame.Score.FirstTry + frame.Score.SecondTry;
        }
    }
}
