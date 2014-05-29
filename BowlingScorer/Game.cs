using System.Linq;
using System.Text;

namespace BowlingScorer
{
    public class Game
    {
        private readonly Frame[] _frames = new Frame[10];        
        
        public Game()
        {
            Frame previous = null;
            for (var i = _frames.Length - 1; i >= 0; i--)
            {
                previous = _frames[i] = new Frame(previous);
            }
        }
        
        public void Roll(int i)
        {
            _frames[0].RecordRoll(i);
        }

        public int Score 
        {
            get { return this._frames.Sum(x => x.Score); }
        }

        public override string ToString()
        {
            var results = new StringBuilder();
            results.AppendFormat("Score : {0}", this.Score).AppendLine();
            for (int i = 0; i < _frames.Length; i++ )
            {
                var frame = _frames[i];

                results.AppendFormat("{0} : {1}", i+1, frame).AppendLine();
            }
            return results.ToString();
        }
    }
}