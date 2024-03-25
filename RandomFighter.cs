using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decks_Dices
{
    public static class RandomFighter<T> where T: struct , IComparable<T>
    {
        static int DeckWins;
        static int DiceWins;
        static int Ties;

        public static void Algorithm(Deck<T> deck,Dice<T> dice)
        {
            T Card;
            T DieRoll;
            DeckWins = 0;
            DiceWins = 0;
            Ties = 0;


            while (deck.Remaining() > 0)
            {
                deck.TryDraw(out Card);
                DieRoll = dice.Roll();

                if (Card.CompareTo(DieRoll)>0)
                {
                    DeckWins++;
                }
                else if (Card.CompareTo(DieRoll)<0) 
                { 
                    DiceWins++;
                }
                else
                {
                     Ties++;
                }
            }

            Console.WriteLine($"The Results of the Algorithm are: \nDeck Wins: {DeckWins} \nDice Wins: {DiceWins} \nTies: {Ties}");

        }
    }
}
