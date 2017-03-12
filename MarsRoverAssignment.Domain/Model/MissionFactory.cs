using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarsRoverAssignment.Domain.Heading;

namespace MarsRoverAssignment.Domain.Model
{
    public class MissionFactory
    {
        public Rover CreateRover(Area area, string statement)
        {
            var headingTypes = new List<IHeading>()
            {
                new NorthHeading(), new EastHeading(), new WestHeading(), new SouthHeading()
            };

            var positionalParts = statement.Split(new[] { ' ' }, 3);
            int x, y;

            if (positionalParts.Length != 3)
            {
                throw new ArgumentException("Positional Parts should be 3!");
            }

            if (!int.TryParse(positionalParts[0], out x))
            {
                throw new ArgumentException("Positional Parts should be integer!");
            }

            if (!int.TryParse(positionalParts[1], out y))
            {
                throw new ArgumentException("Positional Parts should be integer!");
            }

            var headingCode = positionalParts[2];

            var location = new Location(x, y);
            var heading = headingTypes.FirstOrDefault(s => s.Code == headingCode);

            if (!headingTypes.Contains(heading))
            {
                throw new ArgumentException("Heading Type is invalid!");
            }

            return new Rover(area, location, heading);
        }

        public Area CreateArea(string statement)
        {
            var areaCoordinates = statement.Split(new[] { ' ' }, 2);
            int areaWidth, areaHeight;

            if (areaCoordinates.Length != 2)
            {
                throw new ArgumentException("Area coordinates length should be 2");
            }

            if (!int.TryParse(areaCoordinates[0], out areaWidth))
            {
                throw new ArgumentException("Area coordinates length integer!");
            }

            if (!int.TryParse(areaCoordinates[1], out areaHeight))
            {
                throw new ArgumentException("Area coordinates length integer!");
            }

            return new Area(areaWidth, areaHeight);
        }
    }
}
