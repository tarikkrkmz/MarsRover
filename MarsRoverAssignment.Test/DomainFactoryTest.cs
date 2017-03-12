using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using MarsRoverAssignment.Domain;
using MarsRoverAssignment.Domain.Heading;
using MarsRoverAssignment.Domain.Model;
using NUnit.Framework;

namespace MarsRoverAssignment.Test
{
    [TestFixture]
    public class DomainFactoryTest
    {
        
        [TestCase(5, 5, "1 2 N", typeof(NorthHeading))]
        [TestCase(5, 5, "3 3 E", typeof(EastHeading))]
        [TestCase(5, 5, "0 0 W", typeof(WestHeading))]
        [TestCase(5, 5, "0 0 S", typeof(SouthHeading))]
        public void RoverCreationFromSyntax(int areaWidth, int areaHeight, string statement, Type T)
        {
            var area = new Area(areaWidth, areaHeight);
            var roverFactory = new MissionFactory();

            var rover = roverFactory.CreateRover(area, statement);

            rover.Area.Width.Should().Be(areaWidth);
            rover.Area.Height.Should().Be(areaHeight);
            rover.Heading.Should().BeOfType(T);

            rover.ToString().Should().Be(statement);
        }
        [TestCase("5 5",5,5)]
        [TestCase("4 1",4,1)]
        public void AreaCreationFromSyntax(string statement, int width, int height)
        {
            var roverFactory = new MissionFactory();

            var area = roverFactory.CreateArea(statement);
            area.Width.Should().Be(width);
            area.Height.Should().Be(height);
        }
    }
}
