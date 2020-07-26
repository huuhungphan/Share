using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bowling_Score_Schema
{
  public interface IFrameScore
  {
    int First { get; }
    int Last { get; }
    int Total { get; }
    int FrameNo { get; }
  }
}
