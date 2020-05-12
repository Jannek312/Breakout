/*

 * User: jannek.behrens
 * Date: 11.05.2020
 * Time: 08:35
 * 
 * To change this template dont use Tools | Options | Coding | Edit Standard Headers.
 */

using System;

namespace Breakout
{
    /// <summary>
    /// Description of Frame.
    /// </summary>
    public class Frame : Collidable
    {
        private const char FrameChar = '■';
        public int SizeX { get; private set; }
        public int SizeY { get; private set; }

        public Frame(int sizeX, int sizeY)
        {
            this.SizeX = sizeX;
            this.SizeY = sizeY;
        }

        public void Draw()
        {
            for (var line = 0; line < SizeY; line++)
            {
                for (var column = 0; column < SizeX; column++)
                {
                    Console.SetCursorPosition(column, line);
                    if (
                        (line == 0)
                        || (line == SizeY - 1)
                        || (column == 0)
                        || (column == SizeX - 1)
                    )
                    {
                        Console.Write(FrameChar);
                    }
                }
            }
        }

        public void SetCursor()
        {
            Console.SetCursorPosition(0, SizeY);
        }

        public override int CheckCollision(Position position)
        {
            int state = -1;

            if (position.X == SizeX - 1
                || position.X == 0)
            {
                state = 1;
            }

            if (position.Y == SizeY - 1
                || position.Y == 0)
            {
                state = (state == 1) ? 0 : 2;
            }

            return state;
        }
    }
}