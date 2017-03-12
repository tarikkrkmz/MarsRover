using System;
using System.Data;
using MarsRoverAssignment.Domain;
using MarsRoverAssignment.Domain.Model;

namespace MarsRoverAssignment.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            Area area = null;
            Rover rover = null;

            var missionFactory = new MissionFactory();

            while (true)
            {
                var statement = Console.ReadLine().Trim().ToUpper();

                if (statement == string.Empty)
                {
                    break;
                }

                if (area == null)
                {
                    area = missionFactory.CreateArea(statement);
                }
                else if (rover == null)
                {
                    rover = missionFactory.CreateRover(area, statement);
                }
                else
                {
                    rover.Process(statement);
                    Console.WriteLine(rover);
                    rover = null;
                }
            }
        }
    }
}
