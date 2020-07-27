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
    public ScoreView(List<IFrameScore> frameScores, Scores scores, Summaries summaries, PostResponse responseMessage)
    {
      Bowler = $"{JsonConvert.SerializeObject(scores.Token)}" +
        $"{Environment.NewLine}{JsonConvert.SerializeObject(scores.Points)}";
      if (frameScores.Count > 0) FrameView_01 = new FrameView(frameScores, summaries, 0);
      if (frameScores.Count > 1) FrameView_02 = new FrameView(frameScores, summaries, 1);
      if (frameScores.Count > 2) FrameView_03 = new FrameView(frameScores, summaries, 2);
      if (frameScores.Count > 3) FrameView_04 = new FrameView(frameScores, summaries, 3);
      if (frameScores.Count > 4) FrameView_05 = new FrameView(frameScores, summaries, 4);
      if (frameScores.Count > 5) FrameView_06 = new FrameView(frameScores, summaries, 5);
      if (frameScores.Count > 6) FrameView_07 = new FrameView(frameScores, summaries, 6);
      if (frameScores.Count > 7) FrameView_08 = new FrameView(frameScores, summaries, 7);
      if (frameScores.Count > 8) FrameView_09 = new FrameView(frameScores, summaries, 8);
      if (frameScores.Count > 9) FrameView_10 = new FrameView(frameScores, summaries, 9);
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
    public int Total { get; private set; }
    public string Comment { get; private set; }
  }
}
