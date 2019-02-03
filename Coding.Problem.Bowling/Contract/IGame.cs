namespace Coding.Problem.Bowling.Contract
{
    internal interface IGame
    {
        void ThrowBall(int numberOfPinDown);
        int? GetFrameScore(int frameNumber);
        int GetFinalScore();
    }
}
