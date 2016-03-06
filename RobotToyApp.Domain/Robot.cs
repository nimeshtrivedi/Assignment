using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotToyApp.Domain
{
    public class RobotToy
    {

        const int TableDimension = 5;
        public Position Point { get; set; }
        public bool IsPlacedOnTable { get; set; }

        public FacingDirection Facing { get; set; }
        internal bool ValidPosition {
            get
            {
                if (this.Point.x > TableDimension || this.Point.x < 0 || this.Point.y > TableDimension || this.Point.y < 0 || this.Facing == FacingDirection.UNKNOWN)
                {
                    return false;
                }

                return true;
            }
        }

        public RobotToy()
        {
            Point = new Position(0, 0);
            Facing = FacingDirection.NORTH;
            IsPlacedOnTable = false;
        }

        public void PositionRobot(Position position, FacingDirection d)
        {
            this.Point = position;
            this.Facing = d;


            if (!ValidPosition)
            {
                throw new ArgumentOutOfRangeException("Invalid Coordinates: " + this.Point + " " + d.ToString());
            }
            else
                IsPlacedOnTable = true;
        }

        public void TurnRight()
        {
            if (!IsPlacedOnTable)
                throw new InvalidOperationException("This Operation can not be performed at the moment");
            switch (this.Facing)
            {
                case FacingDirection.NORTH:
                    this.Facing = FacingDirection.EAST;
                    break;
                case FacingDirection.EAST:
                    this.Facing = FacingDirection.SOUTH;
                    break;
                case FacingDirection.SOUTH:
                    this.Facing = FacingDirection.WEST;
                    break;
                case FacingDirection.WEST:
                    this.Facing = FacingDirection.NORTH;
                    break;
                
            }
        }

        public string Report()
        {
            if (!IsPlacedOnTable)
                throw new InvalidOperationException("This Operation can not be performed at the moment");
            return String.Format("{0},{1},{2}", Point.x.ToString(), Point.y.ToString(), Facing.ToString());
        }

        public void TurnLeft()
        {
            if (!IsPlacedOnTable)
                throw new InvalidOperationException("This Operation can not be performed at the moment");
            switch (this.Facing)
            {
                case FacingDirection.NORTH:
                    this.Facing = FacingDirection.WEST;
                    break;
                case FacingDirection.EAST:
                    this.Facing = FacingDirection.NORTH;
                    break;
                case FacingDirection.SOUTH:
                    this.Facing = FacingDirection.EAST;
                    break;
                case FacingDirection.WEST:
                    this.Facing = FacingDirection.SOUTH;
                    break;
                
            }
        }

        public void Move()
        {
            if (!IsPlacedOnTable)
                throw new InvalidOperationException("This Operation can not be performed at the moment");
            var currentPoint = Point;
            Point = Point.movePosition(this.Point, this.Facing);
            if (!ValidPosition)
            {
                string message = "Can't move the robot to this point: " + this.Point + " " + this.Facing.ToString();
                Point = currentPoint;
                throw new InvalidOperationException(message);
            }
        }
    }
}
