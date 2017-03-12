using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarsRoverAssignment.Domain.Model;

namespace MarsRoverAssignment.Domain.Heading
{
    public interface IHeading
    {
        string Code { get; }
        Location Move(Location location);
        IHeading TurnRight();
        IHeading TurnLeft();
    }
}
