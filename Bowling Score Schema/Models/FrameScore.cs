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
    private List<int> scorePoints;
    /// <summary>
    /// Construct of Score with a list points for each frame.
    /// Throw Exception if points is not a list of 2 elements of integer 
    /// </summary>
    /// <param name="points">Required</param>
    public FrameScore(List<int> points, int pointIndex)
    {
      if (points == null || points.Count != 2)
        throw new Exception("Not correct Bowling Scoring format");

      scorePoints = points.ToList(); //make a copy of list
      FrameNo = pointIndex + 1;
    }

    /// <summary>
    /// Point of the first ball in the current Score
    /// </summary>
    public int First => scorePoints != null ? scorePoints.First() : 0;
    /// <summary>
    /// Identication the order number of frame in a serie of bowling frames
    /// </summary>
    public int FrameNo { get; private set; }
    /// <summary>
    /// Points returns scoring points in the frame
    /// </summary>
    public List<int> Points => scorePoints;

    /// <summary>
    /// Total points in the current Score
    /// </summary>
    public int Total => scorePoints != null ? scorePoints.Sum() : 0;
    public bool Strike => First == 10;
    /// <summary>
    /// Get Traditional Bonus in case of Strike or Spare
    /// </summary>
    /// <param name="currentScore"></param>
    /// <param name="bonusPoints"></param>
    /// <returns></returns>
    public static int TraditionalBonus(FrameScore currentScore, List<int> bonusPoints)
    {
      int bonusPoint = 0;
      if (currentScore == null || currentScore.Total < 10 ||
          bonusPoints == null || bonusPoints.Count < 1)
        return bonusPoint;

      bonusPoint += bonusPoints[0];
      if (currentScore.Strike && bonusPoints.Count > 1)
        bonusPoint += bonusPoints[1];

      return bonusPoint;
    }

    public override string ToString()
    {
      return "[" + String.Join(" ", scorePoints.Select(x => x.ToString("D"))) + "]";
    }
  }
}
