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
            List<Season> Seasons = new List<Season> {
                 WeatherService.GetSeason(new DateTime(2000,1,1)),
                  WeatherService.GetSeason(new DateTime(2000,3,1)),
                  WeatherService.GetSeason(new DateTime(2000,3,20)),
                  WeatherService.GetSeason(new DateTime(2000,3,21)),
                  WeatherService.GetSeason(new DateTime(2000,6,20)),
                  WeatherService.GetSeason(new DateTime(2000,6,21)),
                  WeatherService.GetSeason(new DateTime(2000,9,20)),
                  WeatherService.GetSeason(new DateTime(2000,9,21)),
                  WeatherService.GetSeason(new DateTime(2000,12,20)),
                  WeatherService.GetSeason(new DateTime(2000,12,21))

        };

            Assert.AreEqual(Season.Winter, Seasons[0]);
            Assert.AreEqual(Season.Winter, Seasons[1]);
            Assert.AreEqual(Season.Winter, Seasons[2]);
            Assert.AreEqual(Season.Spring, Seasons[3]);
            Assert.AreEqual(Season.Spring, Seasons[4]);
            Assert.AreEqual(Season.Summer, Seasons[5]);
            Assert.AreEqual(Season.Summer, Seasons[6]);
            Assert.AreEqual(Season.Fall, Seasons[7]);
            Assert.AreEqual(Season.Fall, Seasons[8]);
            Assert.AreEqual(Season.Winter, Seasons[9]);

        }
    }
}
