using EnsureThat;

namespace MarsRoverAssignment.Domain.Model
{
    public struct Location
    {
        public Location(int x, int y)
        {
            Ensure.That(x).IsGte(0);
            Ensure.That(y).IsGte(0);

            X = x;
            Y = y;
        }

        public int X { get; }

        public int Y { get; }
    }
}
