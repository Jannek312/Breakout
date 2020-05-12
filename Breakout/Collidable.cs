/*

 * User: jannek.behrens
 * Date: 11.05.2020
 * Time: 10:26
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace Breakout
{
    /// <summary>
    /// Description of Collidable.
    /// </summary>
    public abstract class Collidable
    {
        /*
         * Gibt zurück, ob diese Position kollidiert
         * reutnr 
         * -1: nein
         *  0: x 
         *  1: y
         *  2: x und y
         */
        public abstract int CheckCollision(Position position);
    }
}