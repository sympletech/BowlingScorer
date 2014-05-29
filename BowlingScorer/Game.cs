using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BowlingScorer
{
    public class Game
    {
        public Game()
        {
            this.Frames = new Frame[10];
            Frame previous = null;
            for (var i = Frames.Length - 1; i >= 0; i--)
            {
                previous = Frames[i] = new Frame(previous);
            }
        }
        
        public void Roll(int i)
        {
            Frames[0].RecordRoll(i);

        }

        public int Score 
        {
            get { return this.Frames.Sum(x => x.Score); }
        }

        public Frame [] Frames { get; set; }

        public override string ToString()
        {
            var results = new StringBuilder();
            results.AppendFormat("Score : {0}", this.Score).AppendLine();
            for (int i = 0; i < Frames.Length; i++ )
            {
                var frame = Frames[i];

                results.AppendFormat("{0} : {1}", i+1, frame).AppendLine();
            }
            return results.ToString();
        }
    }
}