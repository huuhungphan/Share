using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bowling_Score_Schema
{
  public class Scores
  {
    [JsonProperty(PropertyName = "points")]
    public List<List<int>> Points { get; set; }
    [JsonProperty(PropertyName = "token")]
    public string Token { get; set; }

    /// <summary>
    /// GetBonusPointsAtIndex returns the next scores (max=2)
    /// to calculation as bonus points at current index of frame
    /// depending on Strike or Pair scoring
    /// </summary>
    /// <param name="index"></param>
    /// <param name="scores"></param>
    /// <returns></returns>
    public static List<int> GetBonusPointsAtIndex(int index, Scores scores)
    {
      var bonusPoints = new List<int>();
      if (index > 9 ||
        scores.Points == null || scores.Points.Count <= index + 1 ||
        scores.Points[index].Sum() < 10) //neither Strike nor Pair
        return null;

      bonusPoints.Add(scores.Points[index + 1][0]);
      if (scores.Points[index][0] == 10) //Strike => find second roll from index
      {
        if (index == 9 || scores.Points[index + 1][0] < 10)
          bonusPoints.Add(scores.Points[index + 1][1]);
        else if (scores.Points[index + 1][0] == 10 && scores.Points.Count > index + 2)
          bonusPoints.Add(scores.Points[index + 2][0]);
      }

      return bonusPoints;
    }

    public override string ToString()
    {
      return JsonConvert.SerializeObject(this);
    }
  }
}
