/*

 * User: jannek.behrens
 * Date: 11.05.2020
 * Time: 08:34
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Text;
using System.Threading;

namespace Breakout
{
    /// <summary> 
    /// Description of Breakout.
    /// </summary>
    public class Breakout
    {
        private readonly Block[] _blocks = new Block[300];
        private Frame _frame;
        private Ball _ball;
        private Platform _platform;

        public Breakout()
        {
        }

        public void Init()
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.CursorVisible = false;

            _frame = new Frame(81, 30);
            _frame.Draw();

            PlaceBlocks(7 * 11);


            _ball = new Ball(1, 20);
            _ball.DirectionX = 1;
            _ball.DirectionY = 1;

            _ball.Draw();

            _platform = new Platform(5, _frame.SizeY - 3);
            _platform.Draw();
        }

        public void Run()
        {
            var run = 0;
            while (true)
            {
                run++;

                if (Console.KeyAvailable)
                {
                    _platform.Direction = Console.ReadKey().Key switch
                    {
                        ConsoleKey.LeftArrow => -1,
                        ConsoleKey.RightArrow => 1,
                        _ => _platform.Direction
                    };

                    while (Console.KeyAvailable)
                        Console.ReadKey(false);

                    _platform.Move(0, _frame.SizeX);
                }

                if (run % 2 == 0)
                {
                    MoveBall();
                }

                if (_ball.Pos.Y > _platform.Position.Y)
                {
                    break; //TODO
                }


                Thread.Sleep(50);
            }

            _frame.SetCursor();
            Console.WriteLine("Game over!");


            Console.Write("Press any key to continue . . . ");
            Console.ReadKey(true);
        }

        private void MoveBall()
        {
            var nextBallPosition = _ball.NextPos();

            var collisionStateFrame = _frame.CheckCollision(nextBallPosition);
            var collisionStatePlatform = _platform.CheckCollision(nextBallPosition);

            foreach (var block in _blocks)
            {
                if (block != null && block.CheckCollision(nextBallPosition) != -1)
                {
                    block.Erase();
                }
            }


            // von der platform abprallen
            if (collisionStatePlatform != -1)
            {
                switch (collisionStatePlatform)
                {
                    case 0:
                        _ball.DirectionX = -_ball.DirectionX;
                        _ball.DirectionY = -_ball.DirectionY;
                        break;
                    case 1:
                        _ball.DirectionY = -_ball.DirectionY;
                        break;
                    case 2:
                        _ball.DirectionX = -_ball.DirectionX;
                        break;
                }
            }

            //frame
            else
            {
                switch (collisionStateFrame)
                {
                    case 0:
                        _ball.DirectionX = -_ball.DirectionX;
                        _ball.DirectionY = -_ball.DirectionY;
                        break;
                    case 1:
                        _ball.DirectionX = -_ball.DirectionX;
                        break;
                    case 2:
                        _ball.DirectionY = -_ball.DirectionY;
                        break;
                }
            }

            _ball.Move();
        }

        private void PlaceBlocks(int count)
        {
            var i = 0;

            for (var row = 1; row <= 3; row++)
            {
                for (var column = 0; column < 11; column++)
                {
                    var block = new Block(3 + (column * 7), (row * 2));
                    block.Draw();
                    _blocks[i++] = block;
                }
            }
        }
    }
}