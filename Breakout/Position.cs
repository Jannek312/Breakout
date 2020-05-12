/*

 * User: jannek.behrens
 * Date: 11.05.2020
 * Time: 10:07
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Breakout
{
    /// <summary>
    /// Description of Position.
    /// </summary>
    public class Position
    {
        public Position()
        {
        }

        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; set; }

        public int Y { get; set; }
    }
}