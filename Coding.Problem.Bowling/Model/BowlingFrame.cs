using Coding.Problem.Bowling.Contract;

namespace Coding.Problem.Bowling.Model
{
    internal class BowlingFrame : BaseFrame
    {
        private BaseFrame _nextFrame;
        internal BowlingFrame(int index): base(index) { }
        private IRule _scoringRule;
        private IRule ScoringRule
        {
            get
            {
                if (_scoringRule == null)
                    _scoringRule = ScoreRuleFactory.GetRuleToApply(this);

                return _scoringRule;
            }
        }
        internal bool TryLinkNextFrame(BaseFrame nextFrame)
        {
            if (IsFinalFrame)
                return false;

            _nextFrame = nextFrame;
            return true;
        }
        internal override int? GetFrameScore()
        {
            return
                ScoringRule.Apply(this);
        }
        internal BowlingFrame NextFrame => _nextFrame as BowlingFrame;
    }
}
