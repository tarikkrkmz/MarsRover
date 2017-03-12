using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using MarsRoverAssignment.Domain;
using MarsRoverAssignment.Domain.Model;
using NUnit.Framework;

namespace MarsRoverAssignment.Test
{
    [TestFixture]
    public class AreaTest
    {
        [TestCase(4, 5, 1, 1, true)]
        [TestCase(4, 5, 4, 5, true)]
        [TestCase(5, 4, 5, 4, true)]
        [TestCase(2, 2, 3, 2, false)]
        public void LocationIn(int areaWidth, int areaHeight, int x, int y, bool isInside)
        {
            var area = new Area(areaWidth, areaHeight);
            var location = new Location(x, y);

            area.IsInside(location).Should().Be(isInside);
        }

        [TestCase(-1, 1)]
        [TestCase(1, -1)]
        public void NegativeOrZeroArea_CannotExists(int x, int y)
        {
            Assert.That(() => new Area(x, y), Throws.TypeOf<ArgumentException>());
        }

        [TestCase(1, 1)]
        [TestCase(1, 2)]
        [TestCase(2, 1)]
        public void Location_Creation(int x, int y)
        {
            var area = new Area(x, y);

            area.Width.Should().Be(x);
            area.Height.Should().Be(y);
        }
    }
}
