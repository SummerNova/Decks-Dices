using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decks_Dices
{
    public class Dice<T> where T : IComparable<T>
    {
        protected T[] Values;
        protected uint Amount;
        protected Random rnd = new Random();

        public Dice(T[] values, uint amount)
        {
            this.Values = values;
            this.Amount = amount;
        }

        public List<T> RollValues()
        {
            List<T> list = new List<T>();
            for (int i = 0; i < Amount; i++) { list.Add(Values[rnd.Next(Values.Length)]); }
            return list;
        }

        public virtual T Roll()
        {
            

            return RollValues()[0];
        }
    }
}
