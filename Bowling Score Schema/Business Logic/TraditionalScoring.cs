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
    public static Summaries GetSummaries(Scores scores)
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
            sum += score.Total;

            //Calculate Bonus if the current score is not the last one
            //either for strike or spare in a traditional bowling
            //See eventually at https://en.wikipedia.org/wiki/Ten-pin_bowling#Traditional_scoring
            if (i < scores.Points.Count - 1 &&
                score.Total == 10)
            {
              List<FrameScore> bonusFrames = GetBonusFrames(score, scores);
              sum += FrameScore.TraditionalBonus(score, bonusFrames);
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

    /// <summary>
    /// GetBonusFrames to be calculated from the current frame depends on
    /// strike or pair scoring rules
    /// </summary>
    /// <param name="score"></param>
    /// <param name="scores"></param>
    /// <returns></returns>
    private static List<FrameScore> GetBonusFrames(FrameScore score, Scores scores)
    {
      List<FrameScore> bonusFrames = new List<FrameScore>();
      int nextIndex = score.FrameNo;
      var bonusFrame = AddBonusFrame(scores, bonusFrames, nextIndex); //first bonus roll/frame
      if (score.Strike && bonusFrame != null && bonusFrame.Strike) //second bonus roll in the second frame
        AddBonusFrame(scores, bonusFrames, nextIndex + 1);

      return bonusFrames;
    }

    /// <summary>
    /// AddBonusFrame to collection "bonusFrames" at the index specified of the "nextIndex" 
    /// taken from the serie of scoring points "scores"
    /// </summary>
    /// <param name="scores"></param>
    /// <param name="bonusFrames"></param>
    /// <param name="nextIndex"></param>
    /// <returns></returns>
    private static FrameScore AddBonusFrame(Scores scores, List<FrameScore> bonusFrames, int nextIndex)
    {
      if (nextIndex >= scores.Points.Count) //last has been reached
        return null;

      var bonusFrame = new FrameScore(scores.Points.ElementAt(nextIndex), nextIndex);
      bonusFrames.Add(bonusFrame);
      return bonusFrame;
    }
  }
}
