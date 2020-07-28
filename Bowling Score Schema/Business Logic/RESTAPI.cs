using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Bowling_Score_Schema
{
  class RESTAPI
  {
    async public static Task<Scores> Get(string url)
    {
      Scores result = null;
      try
      {
        using (HttpClient client = new HttpClient())
        {
          using (var response = await client.GetAsync(url))
          {
            using (var content = response.Content)
            {
              result = await content.ReadAsAsync<Scores>();
            }
          }
        }
      }
      catch (Exception ex)
      {
        var baseException = ex.GetBaseException();
        Console.WriteLine($"{baseException.GetType()}:\n\t{baseException.Message}" +
          $"\n\tat\n\t{baseException.StackTrace}");
      }

      return result;
    }

    async public static Task<PostResponse> Post(string url, Summaries summaries)
    {
      PostResponse result = null;
      try
      {
        using (HttpClient client = new HttpClient())
        {
          using (var responseMessage = await client.PostAsJsonAsync(url, summaries))
          {
            result = new PostResponse { httpResponse = responseMessage };
            using (var content = responseMessage.Content)
            {
              var response = await content.ReadAsAsync<Response>();
              result.contentResponse = response;
            }
          }
        }
      }
      catch (Exception ex)
      {
        var baseException = ex.GetBaseException();
        Console.WriteLine($"{baseException.GetType()}:\n\t{baseException.Message}" +
          $"\n\tat\n\t{baseException.StackTrace}");
      }

      return result;
    }

  }
}
