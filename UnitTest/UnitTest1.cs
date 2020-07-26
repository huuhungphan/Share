using System;
using System.Collections.Generic;
using Bowling_Score_Schema;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest
{
  [TestClass]
  public class TestTraditionalScoring
  {
    [TestMethod]
    public void TestStrikeScoring()
    {
      var scores = new Scores
      {
        Points = new List<List<int>> {
          new List<int> {10, 0 },
          new List<int> {3, 6 } },
        Token = "Strike"
      };

      var summaries = TraditionalScoring.GetSummaries(scores);
      Assert.IsNotNull(summaries);
      Assert.AreEqual(summaries.Points[0], 19);
      Assert.AreEqual(summaries.Points[1], 28);
    }

    [TestMethod]
    public void TestMaxStrikeScoring()
    {
      var scores = new Scores
      {
        Points = new List<List<int>> {
          new List<int> {10, 0 },
          new List<int> {10, 0 },
          new List<int> {10, 0 },
          new List<int> {10, 0 },
          new List<int> {10, 0 },
          new List<int> {10, 0 },
          new List<int> {10, 0 },
          new List<int> {10, 0 },
          new List<int> {10, 0 },
          new List<int> {10, 0 },
          new List<int> {10, 10 } },
        Token = "Strike"
      };

      var summaries = TraditionalScoring.GetSummaries(scores);
      Assert.IsNotNull(summaries);
      Assert.AreEqual(summaries.Points[0], 30);
      Assert.AreEqual(summaries.Points[1], 60);
      Assert.AreEqual(summaries.Points[9], 300);
    }

    [TestMethod]
    public void TestSpareScoring()
    {
      var scores = new Scores
      {
        Points = new List<List<int>> {
          new List<int> {7, 3 },
          new List<int> {4, 2 } },
        Token = "Spare"
      };

      var summaries = TraditionalScoring.GetSummaries(scores);
      Assert.IsNotNull(summaries);
      Assert.AreEqual(summaries.Points[0], 14);
      Assert.AreEqual(summaries.Points[1], 20);
    }
  }
}
