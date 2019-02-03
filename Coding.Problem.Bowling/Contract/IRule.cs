using Coding.Problem.Bowling.Model;

namespace Coding.Problem.Bowling.Contract
{
    internal interface IRule
    {
        int Apply(BaseFrame frame);
    }
}
