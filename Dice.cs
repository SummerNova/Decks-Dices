using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decks_Dices
{
    public class Dice : Dice<int>
    {
        int modifier;

        public Dice() : this(1, 6, 0)
        {

        }

        public Dice(uint amount, uint baseDIe, int modifier) : base(new int[baseDIe],amount)
        {
            for (int i = 0; i < Values.Length; i++)
            {
                Values[i] = i+1;
            }
            this.modifier = modifier;
        }

        public override int Roll()
        {
            int output = modifier;
            foreach (int value in this.RollValues()) { output += value; }
            return output;
        }

        public override string ToString()
        {
            string Plus = "";
            if (modifier >= 0) Plus = "+";
            return $"{Amount}d{Values.Length}{Plus}{modifier}";
        }

        public override int GetHashCode()
        {
            int output = (int)(Amount << 4) + (int)(Values.Length << 8) + modifier;
            return output;
        }

        public override bool Equals([NotNullWhen(true)] object? obj)
        {
            return Amount == ((Dice)obj).Amount && Values.Length == ((Dice)obj).Values.Length && modifier == ((Dice)obj).modifier;
        }


    }
}
