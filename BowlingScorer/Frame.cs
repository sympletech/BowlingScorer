using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BowlingScorer
{
    public class Frame
    {
        public Frame()
        {
         this.Rolls=new List<int>();   
        }
        public int Score { get { return Rolls.Sum(); } }

        public List<int> Rolls { get; set; }
        public bool Complete { get { return Rolls.Count() == 2; }
        }

        public override string ToString()
        {
            var results = new StringBuilder();

            results.AppendFormat("Rolls : {0} | {1}", string.Join(", ", this.Rolls), this.Score);

            return results.ToString();
        }
    }
}
