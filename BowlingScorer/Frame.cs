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

        internal void RecordRoll(int i)
        {
            // if spare
            //   rolls.Count == 0, 1 add
            //   rolls.Count == 2 add, pass

            // if strike
            //   rolls.Count == 0 add
            //   rolls.Count == 1, 2 add, pass

            // otherwise
            //   rolls.Count == 0, 1 add

            switch (_rolls.Count)
            {
                case 0:
                    _rolls.Add(i);
                    break;
                case 1:
                    _rolls.Add(i);
                    //if (_rolls[0] == 10)
                    //{
                    //    if (_next != null) _next.RecordRoll(i);
                    //}
                    break;
                case 2:
                    if (_rolls.Count == 2 && _rolls[0] + _rolls[1] == 10)
                        _rolls.Add(i);
                    if (_next != null) 
                        _next.RecordRoll(i);
                    break;
                default:
                    if (_rolls.Count == 2 && _rolls[0] + _rolls[1] == 10)
                        _rolls.Add(i);
                    if (_next != null) 
                        _next.RecordRoll(i);
                    break;
            }
        }

        public override string ToString()
        {
            var results = new StringBuilder();

            results.AppendFormat("Rolls : {0} | {1}", string.Join(", ", this._rolls), this.Score);

            return results.ToString();
        }
    }
}