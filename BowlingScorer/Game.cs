using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BowlingScorer
{
    public class Game
    {
        public Game()
        {
            this.Frames = new List<Frame>();
            
        }
        
        public void Roll(int i)
        {
            Frame frame;
            if (!Frames.Any() || Frames.Last().Complete)
            {
                frame = new Frame();
                Frames.Add(frame);
            }
            else
            {
                frame = Frames.Last();
            }
            frame.Rolls.Add(i);
        }

        public int Score {
            get { return this.Frames.Sum(x => x.Score); }
        }

        public List<Frame> Frames { get; set; }

        public override string ToString()
        {
            var results = new StringBuilder();
            results.AppendFormat("Score : {0}", this.Score).AppendLine();
            for (int i = 0; i < Frames.Count; i++ )
            {
                var frame = Frames[i];

                results.AppendFormat("{0} : {1}", i+1, frame).AppendLine();
            }
            return results.ToString();
        }
    }
}