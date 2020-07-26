using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bowling_Score_Schema
{
  public class FrameScore : IFrameScore
  {
    /// <summary>
    /// Construct of Score with a list points for each frame.
    /// Throw Exception if points is not a list of 2 elements of integer 
    /// </summary>
    /// <param name="points">Required</param>
    public FrameScore(List<int> points, int pointIndex)
    {
      if (points == null || points.Count != 2)
        throw new Exception("Not correct Bowling Scoring format");

      First = points[0];
      Last = points[1];
      FrameNo = pointIndex + 1;
    }

    /// <summary>
    /// Point of the first ball in the current Score
    /// </summary>
    public int First { get; private set; }
    /// <summary>
    /// Point of the last (second) ball in the current Score
    /// </summary>
    public int Last { get; private set; }
    public int FrameNo { get; private set; }

    /// <summary>
    /// Total points in the current Score
    /// </summary>
    public int Total => First + Last;
    public bool Strike => First == 10;
    /// <summary>
    /// Get Traditional Bonus in case of Strike or Spare
    /// </summary>
    /// <param name="currentScore"></param>
    /// <param name="bonusFrames"></param>
    /// <returns></returns>
    public static int TraditionalBonus(FrameScore currentScore, List<FrameScore> bonusFrames)
    {
      int bonusPoint = 0;
      int rollNo = 0;
      foreach (var nextScore in bonusFrames)
      {
        rollNo++;
        bonusPoint += currentScore != null && nextScore != null && currentScore.Total == 10
          ? currentScore.Strike && rollNo < 2 ? nextScore.Total : nextScore.First
          : 0;
      }

      return bonusPoint;
    }

    public override string ToString()
    {
      return $"[{First}, {Last}]";
    }
  }
}
