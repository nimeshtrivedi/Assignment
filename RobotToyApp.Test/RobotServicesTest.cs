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
    class RobotServicesTest
    {
        [Test]
        public void RobotService_InvalidCommandReportsInvalid()
        {
            var sut = new RobotToyService(new RobotToy());
            var response = sut.ExecuteCommand("Cmd1");
            Assert.AreEqual("Invalid Command", response);
        }

        [Test]
        public void RobotService_ValidCommandReportsInvalidIfRobotIsNotPlaced()
        {
            var sut = new RobotToyService(new RobotToy());
            var response = sut.ExecuteCommand("Report");
            Assert.AreEqual("RobotToy is not Positioned on table", response);
        }

        [Test]
        public void RobotService_ValidTestRunsForProperCommands1()
        {
            var sut = new RobotToyService();
            sut.ExecuteCommand("Place 1,1,North");
            sut.ExecuteCommand("Move");
            Assert.That("1,2,NORTH", Is.EqualTo(sut.ExecuteCommand("Report")));
        }

        [Test]
        public void RobotService_ValidTestRunsForProperCommands2()
        {
            var sut = new RobotToyService();
            sut.ExecuteCommand("Place 1,1,North");
            sut.ExecuteCommand("Move");
            sut.ExecuteCommand("LEFT");
            Assert.That("1,2,WEST", Is.EqualTo(sut.ExecuteCommand("Report")));
        }
        [Test]
        public void RobotService_ValidTestRunsForProperCommands3()
        {
            var sut = new RobotToyService();
            sut.ExecuteCommand("Place 1,1,North");
            sut.ExecuteCommand("Move");
            sut.ExecuteCommand("RIGHT");
            sut.ExecuteCommand("Move");
            sut.ExecuteCommand("Move");
            sut.ExecuteCommand("Move");
            Assert.That("4,2,EAST", Is.EqualTo(sut.ExecuteCommand("Report")));
        }
        [Test]
        public void RobotService_ErrorsOnInvalidMove()
        {
            var sut = new RobotToyService();
            sut.ExecuteCommand("Place 0,0,North");
            sut.ExecuteCommand("LEFT");

            Assert.That(() => sut.ExecuteCommand("Move"), Throws.TypeOf<InvalidOperationException>());
        }
    }
}

