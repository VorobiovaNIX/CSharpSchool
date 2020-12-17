using System;
using System.Collections.Generic;
using System.Text;

namespace Delegation.Sticks
{
    public class SticksGame
    {
        private readonly Random randomizer;
        public int InitialStickNumber { get; }
        public Player Turn { get; private set;}

        public int RemainingSticks { get; private set; }

        public GameStatus GameStatus { get; private set; }

        public event Action<int> MachinePlayed;
        public event EventHandler<int> HumanTurnToMakeMove;

        public event Action<Player> EndOfGame;

        public SticksGame(int initialStickNumber, Player whoMakesFirstMove)
        {
            if (initialStickNumber <7 || initialStickNumber >30)
            {
                throw new ArgumentException("Initial number of sticks should be >= 7 and <= 30");
            }
            randomizer = new Random();
            InitialStickNumber = initialStickNumber;
            GameStatus = GameStatus.NotStarted;
            RemainingSticks = InitialStickNumber;
            Turn = whoMakesFirstMove;
        }

        public void HumanTakes(int sticks)
        {
            if (sticks <1|| sticks>3)
            {

                throw new ArgumentException("You can take from 1 to 3 sticks in a single move");
            }

            if (sticks > RemainingSticks)
            {
                throw new ArgumentException($"You cannot take more than remaining. Remains: {RemainingSticks}");
            }
            TakeSticks(sticks);

        }

        public void Start()
        {
            if (GameStatus==GameStatus.GameIsOver)
            {
                RemainingSticks = InitialStickNumber;
            }
            if (GameStatus ==GameStatus.InProgress)
            {
                throw new InvalidOperationException("Cannot call start when game is already in progress ");
            }
            GameStatus = GameStatus.InProgress;
            while (GameStatus==GameStatus.InProgress)
            {
                if (Turn == Player.Machine)
                {
                    CompMakesMove();
                }
                else
                {
                    HumanMakesMove();
                }

                FireEndOfGameIfRequired();

                Turn = Turn == Player.Machine ? Player.Human : Player.Machine;

            }
        }

        private void FireEndOfGameIfRequired()
        {
            if (RemainingSticks ==0)
            {
                GameStatus = GameStatus.GameIsOver;
                if (EndOfGame!=null)
                {
                    EndOfGame(Turn == Player.Machine ? Player.Human : Player.Machine);
                }
            }
        }

        private void HumanMakesMove()
        {
            if (HumanTurnToMakeMove != null)
            {
                HumanTurnToMakeMove(this, RemainingSticks);

            }
        }

        private void CompMakesMove()
        {
            int maxNumber= RemainingSticks >= 3 ? 3 : RemainingSticks;
            int sticks = randomizer.Next(1, maxNumber);

            TakeSticks(sticks);
            if (MachinePlayed!=null)
            {
                MachinePlayed(sticks);
            }
        }

        private void TakeSticks(int sticks)
        {
            RemainingSticks -= sticks;
        }
    }
}
