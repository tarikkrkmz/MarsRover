using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using MarsRoverAssignment.Domain;
using MarsRoverAssignment.Domain.Exception;
using MarsRoverAssignment.Domain.Heading;
using MarsRoverAssignment.Domain.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;

namespace MarsRoverAssignment.Test
{
    [TestFixture]
    public class DomainTest
    {
        [Test]
        public void When_Rover_Created_Then_Rover_And_Location_And_Heading_Should_Be_Same_With_Given()
        {
            var area = new Area(4, 4);
            var location = new Location(1, 1);

            IHeading heading = new NorthHeading();
            var rover = new Rover(area, location, heading);

            rover.Location.Should().NotBeNull();
            rover.Location.Should().Be(location);

            rover.Area.Should().NotBeNull();
            rover.Area.Should().Be(area);

            rover.Heading.Should().NotBeNull();
            rover.Heading.Should().Be(heading);

        }


        [TestCase(5, 5, "1 2 N", "LMLMLMLMM", "1 3 N")]
        [TestCase(5, 5, "3 3 E", "MMRMMRMRRM", "5 1 E")]
        public void RoverMovement(int areaWidth, int areaHeight, string statement, string thirdLine, string result)
        {
            var area = new Area(areaWidth, areaHeight);
            var roverFactory = new MissionFactory();

            var rover = roverFactory.CreateRover(area, statement);
            rover.Process(thirdLine);

            rover.ToString().Should().Be(result);
        }

        [TestCase(3, 3, "3 3 E", "M", "")]
        public void RoverMovement_With_Wrong_Result(int areaWidth, int areaHeight, string statement, string thirdLine, string result)
        {
            var area = new Area(areaWidth, areaHeight);
            var roverFactory = new MissionFactory();

            var rover = roverFactory.CreateRover(area, statement);

            Assert.Throws<OutOfAreaException>(() => rover.Process(thirdLine));
        }
    }
}
