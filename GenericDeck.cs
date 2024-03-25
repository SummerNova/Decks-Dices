using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decks_Dices
{
    public class Deck<T> where T : struct, IComparable<T>
    {
        public T[] Cards;
        protected List<int> TheDeck = new List<int>();

        protected List<int> Discard = new List<int>();
        protected Random rnd = new Random();

        public Deck(int size) 
        {
            Cards = new T[size];
            for (int i = 0; i < size; i++) 
            { 
                TheDeck.Add(i);
            }
            Shuffle();
        }

        public void Shuffle()
        {
            int temp;
            int target;
            for (int i = 0;i < TheDeck.Count;i++) 
            { 
                temp = TheDeck[i];
                target = rnd.Next(TheDeck.Count);
                TheDeck[i] = TheDeck[target];
                TheDeck[target] = temp;
            }
        }

        public void Reshuffle()
        {
            foreach (int i in Discard)
            {
                TheDeck.Add(i);
            }
            Discard.Clear();
            Shuffle();
        }

        public bool TryDraw(out T card)
        {
            if (TheDeck.Count == 0)
            {
                card = default;
                return false;
            }
            card = Cards[TheDeck[0]];
            Discard.Add(TheDeck[0]);
            TheDeck.RemoveAt(0);
            return true;
        }

        public T Peek()
        {
            if (TheDeck.Count == 0)
            {
                throw new ArgumentOutOfRangeException(nameof(TheDeck));
            }
            return Cards[TheDeck[0]];
        }

        public int Size()
        {
            return Cards.Length;
        }

        public int Remaining()
        {
            return TheDeck.Count;
        }

    }
}
