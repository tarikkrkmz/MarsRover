using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarsRoverAssignment.Domain.Model;

namespace MarsRoverAssignment.Domain.Heading
{
    public class WestHeading : IHeading
    {
        public string Code => "W";

        public Location Move(Location location)
        {
            return new Location(location.X - 1, location.Y);
        }

        public IHeading TurnRight()
        {
            return new NorthHeading();
        }

        public IHeading TurnLeft()
        {
            return new SouthHeading();
        }
    }
}
