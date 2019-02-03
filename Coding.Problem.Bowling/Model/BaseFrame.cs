namespace Coding.Problem.Bowling.Model
{
    internal abstract class BaseFrame
    {
        private readonly int _index = 1;
        private Score _score;
        private int _tryCount;
        public int Index => _index;
        public Score Score => _score;
        public BaseFrame(int index)
        {
            _index = index;
        }
        public void AddScore(int pinDown)
        {
            _tryCount++;
            _score = UpdateScore(pinDown);
        }
        private Score UpdateScore(int pinDown)
        {
            if (_tryCount == 1)
                return new Score(pinDown);
            else if (_tryCount == 2)
                return new Score(_score.FirstTry, pinDown);
            else
                return new Score(_score.FirstTry, _score.SecondTry, pinDown);
        }
        internal abstract int? GetFrameScore();
        internal virtual bool CanRetry
        {
            get
            {
                if (_tryCount == 0)
                    return true;
                else if (_index == 10)
                    return _score.TotalScore >= 10;
                else if (_tryCount == 3)
                    return false;
                else if (_tryCount == 2)
                    return false;
                else
                    return _score.TotalScore != 10;
            }
        }
        internal bool IsStrike => _score.FirstTry == 10;
        internal bool IsSpare => _score.FirstTry != 10
                            && _score.FirstTry + _score.SecondTry == 10;
        internal bool IsFinalFrame => _index == 10;
    }
}
