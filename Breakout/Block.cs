/*

 * User: jannek.behrens
 * Date: 11.05.2020
 * Time: 08:29
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;

namespace Breakout
{
    /// <summary>
    /// Description of Block.
    /// </summary>
    public class Block : Collidable
    {
        private const int Size = 5;
        private const char C = '■';

        private readonly Position _position;

        public Block(int x, int y)
        {
            _position = new Position(x, y);
        }


        public void Draw()
        {
            Console.SetCursorPosition(_position.X, _position.Y);
            Console.Write(new string(C, Size));
        }

        public void Erase()
        {
            Console.SetCursorPosition(_position.X, _position.Y);
            Console.Write(new string(' ', Size));
        }


        public override int CheckCollision(Position position)
        {
            var state = -1;

            if (position.X >= this._position.X
                && position.X <= this._position.X + Size + 1
                && position.Y == this._position.Y)
            {
                state = 0;
            }

            return state;
        }
    }
}