
using NUnit.Framework;
using RobotToyApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RobotToyApp.Test
{
    [TestFixture]
    class RobotTests
    {
        [Test]
        
        public void Robot_NotPlacedErrorsOnReport()
        {
            var sut = new RobotToy();
            Assert.That(() => sut.Report(), Throws.TypeOf<InvalidOperationException>());
            
        }
        [Test]
        public void Robot_NotPlacedErrorsOnMove()
        {
            var sut = new RobotToy();
            Assert.That(() => sut.Move(), Throws.TypeOf<InvalidOperationException>());
        }

        [Test]
        public void Robot_NotPlacedErrorsOnTurnRight()
        {
            var sut = new RobotToy();
            Assert.That(() => sut.TurnRight(), Throws.TypeOf<InvalidOperationException>());
        }

        [Test]
        public void Robot_NotPlacedErrorsOnTurnLeft()
        {
            var sut = new RobotToy();
            Assert.That(() => sut.TurnLeft(), Throws.TypeOf<InvalidOperationException>());
        }

        [Test]
        public void Robot_PlacingOnInvalidCoordinatesErrors()
        {
            var sut = new RobotToy();
            Assert.That(() => sut.PositionRobot(new Position(-3,1),FacingDirection.NORTH), Throws.TypeOf<ArgumentOutOfRangeException>());
        }

        [Test]
        public void Robot_PlacingOnInvalidDirectionErrors()
        {
            var sut = new RobotToy();
            Assert.That(() => sut.PositionRobot(new Position(1, 1), FacingDirection.UNKNOWN), Throws.TypeOf<ArgumentOutOfRangeException>());
        }

        [Test]
        public void Robot_PlacingMovingReportingDisplaysCorrectValues()
        {
            var sut = new RobotToy();
            sut.PositionRobot(new Position(1, 1), FacingDirection.NORTH);
            sut.Move();
            sut.Move();
            sut.TurnLeft();
            Assert.That("1,3,WEST", Is.EqualTo(sut.Report()));
        }
        [Test]
        public void Robot_MovingBeyondTableErrors()
        {
            var sut = new RobotToy();
            sut.PositionRobot(new Position(0, 0), FacingDirection.SOUTH);
            Assert.That(() => sut.Move(), Throws.TypeOf<InvalidOperationException>());
        }
    }
}
