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

    public override string ToString()
    {
      return JsonConvert.SerializeObject(this);
    }
  }
}
