using System;
using FluentAssertions;
using MarsRoverAssignment.Domain;
using MarsRoverAssignment.Domain.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;

namespace MarsRoverAssignment.Test
{
    [TestFixture]
    public class LocationTest
    {
        [TestCase(-1, 1)]
        [TestCase(1, -1)]
        public void NegativeLocation_CannotExists(int x, int y)
        {
            Assert.That(()=> new Location(x, y), Throws.TypeOf<ArgumentException>()) ;
        }

        [TestCase(0, 0)]
        [TestCase(1, 1)]
        [TestCase(1, 2)]
        [TestCase(2, 1)]
        public void Location_Creation(int x, int y)
        {
            var location = new Location(x, y);

            location.X.Should().Be(x);
            location.Y.Should().Be(y);
        }
    }
}
