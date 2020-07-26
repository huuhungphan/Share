using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bowling_Score_Schema
{
  public class Summaries
  {
    [JsonProperty(PropertyName = "token")]
    public string Token { get; set; }
    [JsonProperty(PropertyName = "points")]
    public int[] Points { get; set; }

    public override string ToString()
    {
      return JsonConvert.SerializeObject(this);
    }
  }
}
