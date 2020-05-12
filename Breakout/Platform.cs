/*

 * User: jannek.behrens
 * Date: 11.05.2020
 * Time: 10:46
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;

namespace Breakout
{
    /// <summary>
    /// Description of Platform.
    /// </summary>
    public class Platform : Collidable
    {
        private const int Size = 5;
        private const char C = '■';

        public readonly Position Position;
        public int Direction; //-1: left, 1 right

        public Platform(int x, int y)
        {
            Position = new Position(x, y);
            Direction = 1;
        }

        public void Move(int minBound, int maxBound)
        {
            Erase();
            var newPosX = Position.X + Direction;
            if (newPosX <= minBound)
            {
                Direction = 1;
            }
            else if (newPosX + Size >= maxBound)
            {
                Direction = -1;
            }

            Position.X += Direction;
            Draw();
        }

        public void Draw()
        {
            Console.SetCursorPosition(Position.X, Position.Y);
            Console.Write(new string(C, Size));
        }

        private void Erase()
        {
            Console.SetCursorPosition(Position.X, Position.Y);
            Console.Write(new string(' ', Size));
        }


        public override int CheckCollision(Position position)
        {
            var state = -1;

            if (position.X >= this.Position.X
                && position.X <= this.Position.X + Size
                && position.Y == this.Position.Y)
            {
                state = 1;
            }

            return state;
        }
    }
}