using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BowlingScorer
{
    public class Frame
    {
        private readonly Frame _next;

        public Frame(Frame frame)
        {
            _next = frame;
            this.Rolls = new List<int>();
        }
        public int Score { get { return Rolls.Sum(); } }

        public List<int> Rolls { get; set; }
        public bool Complete
        {
            get { return Rolls.Count() == 2; }
        }

        public override string ToString()
        {
            var results = new StringBuilder();

            results.AppendFormat("Rolls : {0} | {1}", string.Join(", ", this.Rolls), this.Score);

            return results.ToString();
        }

        internal void RecordRoll(int i)
        {
            switch (Rolls.Count)
            {
                
                case 0:
                case 1:
                    Rolls.Add(i);
                    break;
                default:
                    if(_next!=null) _next.RecordRoll(i);
                    break;
            }
        }
    }
}
