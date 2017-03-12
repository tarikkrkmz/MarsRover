using EnsureThat;

namespace MarsRoverAssignment.Domain.Model
{
    public class Area
    {
        public Area(int width, int height)
        {
            Ensure.That(width).IsGte(0);
            Ensure.That(height).IsGte(0);

            Width = width;
            Height = height;
        }

        public int Width { get; }

        public int Height { get; }

        public bool IsInside(Location location)
        {
            return location.X <= Width && location.Y <= Height;
        }
    }
}
