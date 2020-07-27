using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace Bowling_Score_Schema
{
  class CreateBowler
  {
    async public static Task<ScoreView> GetAndPost(
      IList<ScoreView> scoreViews, TextBlock statusBar, string url = "http://13.74.31.101/api/points")
    {
      ScoreView scoreView = null;
      Scores scores = null;
      try
      {
        //GET from Server
        statusBar.Text = "GET...";
        scores = await RESTAPI.Get(url);
        statusBar.Text = $"{scores}";

        if (scores != null && !string.IsNullOrWhiteSpace(scores.Token))
        {
          //Calculate summaries
          var frameScores = new List<IFrameScore>();
          var summaries = TraditionalScoring.GetSummaries(scores, frameScores);
          if (summaries != null &&
            summaries.Token == scores.Token)
          {
            //POST to Server
            statusBar.Text = $"POST=>{summaries}...";
            var responseMessage = await RESTAPI.Post(url, summaries);
            scoreView = MapToViews(frameScores, scores, summaries, responseMessage);
            if (scoreView != null && responseMessage.httpResponse.IsSuccessStatusCode)
            {
              statusBar.Text += "OK";
              scoreViews.Add(scoreView);
            }
            else
            {
              statusBar.Text += "failed";
              MessageBox.Show(
                $"POST to {url} value:{Environment.NewLine}{summaries}" + 
                $"{Environment.NewLine} => Failed:" + 
                $"{Environment.NewLine}{responseMessage}",
                "GetAndPost failed", MessageBoxButton.OK, MessageBoxImage.Asterisk);
            }
          }
        }
      }
      catch (Exception ex)
      {
        var baseException = ex.GetBaseException();
        MessageBox.Show(
          $"{baseException.GetType()}:{Environment.NewLine}\t{baseException.Message}" +
          $"{Environment.NewLine}\tat{Environment.NewLine}\t{baseException.StackTrace}", 
          "GetAndPost Error", MessageBoxButton.OK, MessageBoxImage.Error);
      }
      finally { }

      return scoreView;
    }

    private static ScoreView MapToViews(List<IFrameScore> frameScores, Scores scores, Summaries summaries, PostResponse responseMessage)
    {
      if (frameScores == null ||
          summaries == null)
        return null;
      ScoreView scoreView = new ScoreView(frameScores, scores, summaries, responseMessage);
      return scoreView;
    }
  }
}
