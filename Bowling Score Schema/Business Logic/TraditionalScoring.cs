using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bowling_Score_Schema
{
  public class TraditionalScoring
  {
    const int MaxFrame = 10;
    /// <summary>
    /// Algorithm for calculating of scoring points after the traditional scoring system. 
    /// Return null in case of any exception
    /// </summary>
    /// <param name="scores"></param>
    /// <returns></returns>
    public static Summaries GetSummaries(Scores scores, List<IFrameScore> frameScores = null)
    {
      int total = Math.Min(scores.Points.Count, MaxFrame);
      var result = new Summaries {
        Token = scores.Token,
        Points = new int[total] };
      try
      {
        var sum = 0;
        var lastIndex = total - 1;
        for (int i=0; i <= lastIndex ; i++)
        {
          var score = new FrameScore(scores.Points.ElementAt(i), i);
          if (score != null)
          {
            if (frameScores != null)
              frameScores.Add(score);
            sum += score.Total;

            //Calculate Bonus if the current score is not the last one
            //either for strike or spare in a traditional bowling
            //See eventually at https://en.wikipedia.org/wiki/Ten-pin_bowling#Traditional_scoring
            if (i < scores.Points.Count - 1 &&
                score.Total == 10)
            {
              var bonusPoints = Scores.GetBonusPointsAtIndex(i, scores);
              sum += FrameScore.TraditionalBonus(score, bonusPoints);
              if (i == 9)
              {
                score.Points.AddRange(bonusPoints);
              }
            }
          }

          result.Points[i] = sum;
        }

        return result;
      }
      catch (Exception e)
      {
        Console.WriteLine(e.Message);
      }

      return null;
    }
  }
}
