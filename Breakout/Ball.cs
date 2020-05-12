/*

 * User: jannek.behrens
 * Date: 20.06.2019
 * Time: 08:34
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;

namespace Breakout
{
    /// <summary>
    /// Description of Ball: Nö
    /// </summary>
    public class Ball
    {
        private const char BallChar = '●';
        public Position Pos;
        public int DirectionX, DirectionY;

        public Ball()
        {
            Pos = new Position();
        }

        public Ball(int posX, int posY)
        {
            Pos = new Position(posX, posY);
        }

        public Position NextPos()
        {
            var pos = new Position(this.Pos.X, this.Pos.Y);
            pos.X += DirectionX;
            pos.Y += DirectionY;
            return pos;
        }

        public void Move()
        {
            Erase();
            Pos = NextPos();
            Draw();
        }

        public void Draw()
        {
            Console.SetCursorPosition(Pos.X, Pos.Y);
            Console.Write(BallChar);
        }

        private void Erase()
        {
            Console.SetCursorPosition(Pos.X, Pos.Y);
            Console.Write(' ');
        }
    }
}