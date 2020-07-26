using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bowling_Score_Schema
{
  public class FrameView
  {
    private IFrameScore frameScore;
    public int Score { get; private set; }

    public FrameView(IFrameScore frame, int score)
    {
      frameScore = frame;
      Score = score;
    }

    public string First => frameScore.First == 10 ? "X" : frameScore.First.ToString("D");
    public string Last => frameScore.First == 10 && frameScore.Last == 0 ? " " : frameScore.Total == 10 
          ? "/" : frameScore.Last == 10 ? "X" : frameScore.Last.ToString("D");
    public override string ToString()
    {
      return frameScore.FrameNo <= 10
        ? $"   {First}  {Last}{Environment.NewLine}{Score}"
        : $"   {First}  {Last}";
    }
  }
}
