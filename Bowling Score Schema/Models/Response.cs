using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bowling_Score_Schema
{
  public class Response
  {
    [JsonProperty(PropertyName = "success")]
    public bool Success { get; set; }

    public override string ToString()
    {
      return JsonConvert.SerializeObject(this);
    }
  }

  public class PostResponse
  {
    public System.Net.Http.HttpResponseMessage httpResponse { get; set; }
    public Response contentResponse { get; set; }
    private string ToString(System.Net.Http.HttpResponseMessage httpResponse)
    {
      var rsp = $"{httpResponse}";
      var index = rsp.IndexOf("Version");
      return index > 0
         ? rsp.Substring(0, index) : rsp;
    }

    public override string ToString()
    {
      return $"{contentResponse} " + ToString(httpResponse);
    }
  }
}
