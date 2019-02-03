using Coding.Problem.Bowling.Contract;
using Coding.Problem.Bowling.Model;

namespace Coding.Problem.Bowling
{
    public class BowlingGame : IGame
    {
        private BowlingFrame _firstFrame;
        private BowlingFrame _currentFrame;
        public BowlingGame()
        {
            _firstFrame = new BowlingFrame(1);
            _currentFrame = _firstFrame;
        }
        public void ThrowBall(int numberOfPinDown)
        {
            if (numberOfPinDown > 10)
                throw new System.InvalidOperationException("Input value is invalid");

            if (_currentFrame == null)
                return;

            _currentFrame.AddScore(numberOfPinDown);

            if (_currentFrame.CanRetry == false)
                LinkNewFrame();
        }
        public int? GetFrameScore(int frameNumber)
        {
            var pointer = _firstFrame;

            while (pointer != null && pointer.Index != frameNumber)
                pointer = pointer.NextFrame;
            
            return pointer?.GetFrameScore();
        }
        public int GetFinalScore()
        {
            var pointer = _firstFrame;
            var score = _firstFrame.GetFrameScore();

            while (pointer.NextFrame != null)
            {
                pointer = pointer.NextFrame;
                score = score + pointer.GetFrameScore();
            }

            return score.HasValue ? score.Value : 0;
        }
        private void LinkNewFrame()
        {
            if (_currentFrame.IsFinalFrame == false)
            {
                var newFrame = new BowlingFrame(_currentFrame.Index + 1);
                _currentFrame.TryLinkNextFrame(newFrame);
                _currentFrame = _currentFrame.NextFrame;
            }
            else
                _currentFrame = null;
        }
    }
}
