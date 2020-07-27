using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bowling_Score_Schema
{
  public interface IFrameScore
  {
    List<int> Points { get; }
    int First { get; }
    int Total { get; }
    int FrameNo { get; }
  }
}
