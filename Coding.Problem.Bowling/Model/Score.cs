namespace Coding.Problem.Bowling.Model
{
    public class Score
    {
        private readonly int _firstTry, _secondTry, _extraTry;
        public Score(int firstTry)
        {
            _firstTry = firstTry;
        }
        public Score(int firstTry, int secondTry)
        {
            _firstTry = firstTry;
            _secondTry = secondTry;
        }
        public Score(int firstTry, int secondTry, int extraTry)
        {
            _firstTry = firstTry;
            _secondTry = secondTry;
            _extraTry = extraTry;
        }
        internal int FirstTry => _firstTry;
        internal int SecondTry => _secondTry;
        internal int TotalScore => _firstTry + _secondTry + _extraTry;
    }
}
