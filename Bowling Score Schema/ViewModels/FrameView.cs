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
    public int Score { get; private set; } //Frame's Summary point

    public FrameView(List<IFrameScore> frames, Summaries summaries, int index)
    {
      frameScore = index < frames.Count ? frames[index] : null;
      Score = index < summaries.Points.Length ? summaries.Points[index] : 0;
    }

    private static string DisplayPoint(int value, int? prevValue = null)
    {
      if (value == 10)
        return " X ";
      else if (prevValue != default(int?) && value + prevValue == 10)
        return value > 0 ? " / " : string.Empty;

      return $" {value} ";
    }

    public override string ToString()
    {
      int? prevValue = default(int?);
      string result = frameScore.Points.Count < 3 ? "   " : string.Empty;
      foreach (var point in frameScore.Points)
      {
        result += DisplayPoint(point, prevValue);
        prevValue = point;
      }

      result += $"{Environment.NewLine}{Score}";
      return result;
    }
  }
}
