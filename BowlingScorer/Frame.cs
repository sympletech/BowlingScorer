using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BowlingScorer
{
    public class Frame
    {
        private readonly Frame _next;
        private readonly List<int> _rolls = new List<int>();

        public Frame(Frame frame)
        {
            _next = frame;
        }
        public int Score { get { return _rolls.Sum(); } }

        public bool Complete
        {
            get { return _rolls.Count() == 2; }
        }

        public override string ToString()
        {
            var results = new StringBuilder();

            results.AppendFormat("Rolls : {0} | {1}", string.Join(", ", this._rolls), this.Score);

            return results.ToString();
        }

        internal void RecordRoll(int i)
        {
            switch (_rolls.Count)
            {
                case 0:
                case 1:
                    _rolls.Add(i);
                    break;
                default:
                    if(_next!=null) _next.RecordRoll(i);
                    break;
            }
        }
    }
}
