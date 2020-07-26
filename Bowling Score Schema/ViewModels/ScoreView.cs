using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bowling_Score_Schema
{
  public class ScoreView
  {
    public ScoreView(Scores scores, Summaries summaries, PostResponse responseMessage)
    {
      Bowler = $"{JsonConvert.SerializeObject(scores.Token)}" +
        $"{Environment.NewLine}{JsonConvert.SerializeObject(scores.Points)}";
      if (scores.Points.Count > 0) FrameView_01 = new FrameView(new FrameScore(scores.Points.ElementAt(0), 0), summaries.Points[0]);
      if (scores.Points.Count > 1) FrameView_02 = new FrameView(new FrameScore(scores.Points.ElementAt(1), 1), summaries.Points[1]);
      if (scores.Points.Count > 2) FrameView_03 = new FrameView(new FrameScore(scores.Points.ElementAt(2), 2), summaries.Points[2]);
      if (scores.Points.Count > 3) FrameView_04 = new FrameView(new FrameScore(scores.Points.ElementAt(3), 3), summaries.Points[3]);
      if (scores.Points.Count > 4) FrameView_05 = new FrameView(new FrameScore(scores.Points.ElementAt(4), 4), summaries.Points[4]);
      if (scores.Points.Count > 5) FrameView_06 = new FrameView(new FrameScore(scores.Points.ElementAt(5), 5), summaries.Points[5]);
      if (scores.Points.Count > 6) FrameView_07 = new FrameView(new FrameScore(scores.Points.ElementAt(6), 6), summaries.Points[6]);
      if (scores.Points.Count > 7) FrameView_08 = new FrameView(new FrameScore(scores.Points.ElementAt(7), 7), summaries.Points[7]);
      if (scores.Points.Count > 8) FrameView_09 = new FrameView(new FrameScore(scores.Points.ElementAt(8), 8), summaries.Points[8]);
      if (scores.Points.Count > 9) FrameView_10 = new FrameView(new FrameScore(scores.Points.ElementAt(9), 9), summaries.Points[9]);
      if (scores.Points.Count > 10)
        FrameView_Bonus = new FrameView(
          new FrameScore(scores.Points.ElementAt(10), 10), 
          summaries.Points.Length > 10 ? summaries.Points[10] : 0);
      Total = summaries.Points.Last();
      Comment = $"{JsonConvert.SerializeObject(summaries.Points)}{Environment.NewLine}" + 
        $"{responseMessage}";
    }

    public string Bowler { get; private set; }
    public FrameView FrameView_01 { get; private set; }
    public FrameView FrameView_02 { get; private set; }
    public FrameView FrameView_03 { get; private set; }
    public FrameView FrameView_04 { get; private set; }
    public FrameView FrameView_05 { get; private set; }
    public FrameView FrameView_06 { get; private set; }
    public FrameView FrameView_07 { get; private set; }
    public FrameView FrameView_08 { get; private set; }
    public FrameView FrameView_09 { get; private set; }
    public FrameView FrameView_10 { get; private set; }
    public FrameView FrameView_Bonus { get; private set; }
    public int Total { get; private set; }
    public string Comment { get; private set; }
  }
}
