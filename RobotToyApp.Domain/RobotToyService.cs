using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotToyApp.Domain
{
    public class RobotToyService
    {
        public RobotToy Robot { get; set; }
        public RobotToyService()
        {
            this.Robot = new RobotToy();
        }

        public RobotToyService(RobotToy robot)
        {
            this.Robot = robot;
        }

        private void PlaceOnTable(int x, int y, FacingDirection d)
        {
            Robot.PositionRobot(new Position(x, y), d);

        }
        public string ExecuteCommand(string command)
        {
            string retValue = String.Empty;
            var cmd = Common.GetCommand(command);
            if (cmd == Commands.UNKNOWN)
            {
                retValue = "Invalid Command";
                return retValue;
            }
            if (!Robot.IsPlacedOnTable && cmd != Commands.PLACE)
            {
                retValue = "RobotToy is not Positioned on table";
                return retValue;
            }
            switch (cmd)
            {
                case Commands.PLACE:
                    PositionRobot(command);
                    retValue = "Success";
                    break;
                case Commands.MOVE:
                    Robot.Move();
                    retValue = "Success";
                    break;
                case Commands.LEFT:
                    Robot.TurnLeft();
                    retValue = "Success";
                    break;
                case Commands.RIGHT:
                    Robot.TurnRight();
                    retValue = "Success";
                    break;
                case Commands.REPORT:
                    retValue = Robot.Report();
                    break;

            }
            return retValue;
        }

        private void PositionRobot(string command)
        {
            string[] splitCommands = command.Split(' ');
            if (splitCommands != null && splitCommands.Length == 2)
            {
                string[] splitParams = splitCommands[1].Split(',');
                if (splitParams != null && splitParams.Length == 3)
                {
                    string xStr = splitParams[0];
                    string yStr = splitParams[1];
                    string face = splitParams[2];

                    int x=0, y=0;
                    FacingDirection d= FacingDirection.UNKNOWN;
                    try
                    {
                        x = Convert.ToInt32(xStr);
                        y = Convert.ToInt32(yStr);
                        d = Common.GetFaceDirection(face);
                    }
                    catch (System.FormatException)
                    {
                    }
                    PlaceOnTable(x, y, d);

                }


            }
        }
            
        }
    }

