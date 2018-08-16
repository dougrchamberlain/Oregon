using Microsoft.VisualStudio.TestTools.UnitTesting;
using Oregon;
using System;
using System.Collections.Generic;

namespace Test
{
    [TestClass]
    public class Weather
    {
        [TestMethod]
        public void Should_Determine_Seasons()
        {
            List<SeasonType> Seasons = new List<SeasonType> {
                 SeasonType.FromDate(new DateTime(2000,1,1)),
                  SeasonType.FromDate(new DateTime(2000,3,1)),
                  SeasonType.FromDate(new DateTime(2000,3,20)),
                  SeasonType.FromDate(new DateTime(2000,3,21)),
                  SeasonType.FromDate(new DateTime(2000,6,20)),
                  SeasonType.FromDate(new DateTime(2000,6,21)),
                  SeasonType.FromDate(new DateTime(2000,9,20)),
                  SeasonType.FromDate(new DateTime(2000,9,21)),
                  SeasonType.FromDate(new DateTime(2000,12,20)),
                  SeasonType.FromDate(new DateTime(2000,12,21))

        };

            Assert.AreEqual(SeasonType.Winter, Seasons[0]);
            Assert.AreEqual(SeasonType.Winter, Seasons[1]);
            Assert.AreEqual(SeasonType.Winter, Seasons[2]);
            Assert.AreEqual(SeasonType.Spring, Seasons[3]);
            Assert.AreEqual(SeasonType.Spring, Seasons[4]);
            Assert.AreEqual(SeasonType.Summer, Seasons[5]);
            Assert.AreEqual(SeasonType.Summer, Seasons[6]);
            Assert.AreEqual(SeasonType.Fall, Seasons[7]);
            Assert.AreEqual(SeasonType.Fall, Seasons[8]);
            Assert.AreEqual(SeasonType.Winter, Seasons[9]);

        }
    }
}
