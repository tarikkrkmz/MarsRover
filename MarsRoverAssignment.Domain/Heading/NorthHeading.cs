using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarsRoverAssignment.Domain.Model;

namespace MarsRoverAssignment.Domain.Heading
{
    public class NorthHeading : IHeading
    {
        public string Code => "N";

        public Location Move(Location location)
        {
            return new Location(location.X, location.Y + 1);
        }

        public IHeading TurnRight()
        {
            return new EastHeading();
        }

        public IHeading TurnLeft()
        {
            return new WestHeading();
        }
    }
}
