using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarsRoverAssignment.Domain.Model;

namespace MarsRoverAssignment.Domain.Heading
{
    public class EastHeading : IHeading
    {
        public string Code => "E";
        public Location Move(Location location)
        {
            return new Location(location.X + 1, location.Y);
        }

        public IHeading TurnRight()
        {
            return new SouthHeading();
        }

        public IHeading TurnLeft()
        {
            return new NorthHeading();
        }
    }
}
