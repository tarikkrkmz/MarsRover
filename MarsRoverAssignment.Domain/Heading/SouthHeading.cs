using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarsRoverAssignment.Domain.Model;

namespace MarsRoverAssignment.Domain.Heading
{
    public class SouthHeading : IHeading
    {
        public string Code => "S";

        public Location Move(Location location)
        {
            return new Location(location.X, location.Y - 1);
        }

        public IHeading TurnRight()
        {
            return new WestHeading();
        }

        public IHeading TurnLeft()
        {
            return new EastHeading();
        }
    }
}
