/*

 * User: jannek.behrens
 * Date: 11.05.2020
 * Time: 08:33
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace Breakout
{
	class Program
	{
		public static void Main(string[] args)
		{
			Breakout breakout = new Breakout();
			
			breakout.Init();
			breakout.Run();
		}
		
		
	}
}