using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotToyApp.Domain
{
    public enum FacingDirection
    { NORTH, EAST, SOUTH, WEST, UNKNOWN};

    public enum MoveDirection {LEFT, RIGHT, UNKNOWN};

    public enum Commands { PLACE, MOVE, LEFT, RIGHT, REPORT, QUIT, UNKNOWN}

    public static class Common {

        public static MoveDirection GetMoveDirection(string moveDirection)
        {
            MoveDirection retVal = MoveDirection.UNKNOWN;

            switch (moveDirection.ToUpper())
            {
                case "LEFT":
                case "L":
                    retVal = MoveDirection.LEFT;
                    break;
                case "RIGHT":
                case "R":
                    retVal = MoveDirection.RIGHT;
                    break;
                
            }
            return retVal;
        }
        public static Commands GetCommand(string command)
        {
            Commands retValue = Commands.UNKNOWN;
            if (command.ToUpper().StartsWith("PLACE"))
                retValue = Commands.PLACE;
            else
            switch (command.ToUpper())
            {
                case "MOVE":
                case "MV":
                    retValue = Commands.MOVE;
                    break;

                case "LEFT":
                case "LT":
                    retValue = Commands.LEFT;
                    break;
                case "RIGHT":
                case "RT":
                    retValue = Commands.RIGHT;
                    break;
                case "REPORT":
                case "REP":
                case "RPT":
                    retValue = Commands.REPORT;
                    break;
                case "Q":
                case "QUIT":
                case "EXIT":
                    retValue = Commands.QUIT;
                    break;
                default:
                    break;
            }
            return retValue;
        }
        public static FacingDirection GetFaceDirection(string faceValue)
        {
            FacingDirection retValue = FacingDirection.UNKNOWN;
            switch (faceValue.ToUpper())
            {
                case "NORTH":
                case "N":
                    retValue = FacingDirection.NORTH;
                    break;
                case "SOUTH":
                case "S":
                    retValue = FacingDirection.SOUTH;
                    break;
                case "EAST":
                case "E":
                    retValue = FacingDirection.EAST;
                    break;
                case "WEST":
                case "W":
                    retValue = FacingDirection.WEST;
                    break;

            }
            return retValue;
        }
    }

    public struct Position
    {
        internal int x;
        internal int y;

        public Position(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public Position movePosition(Position p, FacingDirection fd )
        {
            int newPointX =  p.x;
            int newPointY =  p.y;
            switch (fd)
            {
                case FacingDirection.NORTH:
                    newPointY++;
                    break;
                case FacingDirection.EAST:
                    newPointX++;
                    break;
                case FacingDirection.SOUTH:
                    newPointY--;
                    break;
                case FacingDirection.WEST:
                    newPointX--;
                    break;

            }
            return new Position(newPointX, newPointY);

        }
        public Position addPoint(Position p)
        {
            int newPointX = this.x + p.x;
            int newPointY = this.y + p.y;

            return new Position(newPointX, newPointY);
        }

        public override string ToString()
        {
            return "[" + this.x + ", " + this.y + "]";
        }
    }
}
