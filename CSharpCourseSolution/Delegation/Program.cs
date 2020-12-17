using Delegation.Sticks;
using System;
using System.Timers;

namespace Delegation
{
    public class Car
    {
        int speed = 0;

        // public event TooFast TooFastDriving;

        public event Action<int> TooFastDriving;
        //public event Func<int,string> TooFastDriving;


        public delegate void TooFast(int currentSpeed);

        //private TooFast tooFast;

        public void Start()
        {
            speed = 10;
        }

        public void Accelerate()
        {
            speed += 10;
            if (speed >80)
            {
                if (TooFastDriving != null)
                {
                    TooFastDriving(speed);
                }
            }
        }

        public void Stop()
        {
            speed = 0;
        }

        //public void RegisterOnTooFast(TooFast tooFast)
        //{
        //    this.tooFast += tooFast;
        //}

        //public void UnregisterOnTooFast(TooFast tooFast)
        //{
        //    this.tooFast -= tooFast;

        //}
    }
    class Program
    {
        static Car car;
        static void Main(string[] args)
        {
            var game = new SticksGame(10, Player.Human);
            game.MachinePlayed += Game_MachinePlayed;
            game.HumanTurnToMakeMove += Game_HumanTurnToMakeMove;
            game.EndOfGame += Game_EndOfGame;

            game.Start();
        }


        private static void Game_EndOfGame(Player player)
        {
            Console.WriteLine($"Winner : {player}");
        }

        private static void Game_HumanTurnToMakeMove(object sender, int remainingSticks)
        {
            Console.WriteLine($"Remaining sticks: {remainingSticks}");
            Console.WriteLine("Take some sticks");

            bool takenCorrectly = false;
            while (!takenCorrectly)
            {
                if (int.TryParse(Console.ReadLine(), out int takenSticks))
                {
                    var game = (SticksGame)sender;
                    try
                    {
                        game.HumanTakes(takenSticks);
                        takenCorrectly = true;
                    }
                    catch (ArgumentException ex)
                    {
                        Console.WriteLine(ex.Message);
                        
                    }
                }
            }
        }

        private static void Game_MachinePlayed(int stickTaken)
        {
            Console.WriteLine($"Machine took: {stickTaken}");
        }

        static void EventDemo()
        {
            Timer timer = new Timer();
            timer.Elapsed += Timer_Elapsed;

            timer.Interval = 5000;
            timer.Start();

            Console.ReadLine();

            car = new Car();
            //car.RegisterOnTooFast(HandleOnTooFast);
            //car.RegisterOnTooFast(HandleOnTooFast);
            //car.UnregisterOnTooFast(HandleOnTooFast);


            car.TooFastDriving += HandleOnTooFast;
            car.TooFastDriving += HandleOnTooFast;
            car.TooFastDriving -= HandleOnTooFast;

            car.Start();

            for (int i = 0; i < 10; i++)
            {
                car.Accelerate();
            }
        }
        private static void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            var timer = (Timer)sender;
            Console.WriteLine("Handling Timer Elapsed Event");
        }

        private static void HandleOnTooFast(int speed)
        {
            Console.WriteLine($"Oh, I got it, calling stop! Current speed is {speed}");
            car.Stop();
        }
    }
}
