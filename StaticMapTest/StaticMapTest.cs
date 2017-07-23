using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StaticMap;
using System.IO;
using System.Collections.Generic;

namespace StaticMapTest
{
    [TestClass]
    public class StaticMapTest
    {
        [TestMethod]
        public void DownloadMapTest()
        {
            StaticMap.StaticMap.ApiUrl = "https://maps.googleapis.com/maps/api/staticmap";
            StaticMap.StaticMap.GoogleKey = "AIzaSyDlHLSiBVLFijxMxz846ZAraExGOjYFLzs";

            var result = StaticMap.StaticMap.DownloadMap(18.452343, -69.952257);
            Assert.AreNotEqual(null, result);
            File.WriteAllBytes("image.png", result);
        }

        [TestMethod]
        public void DownloadMapTestWithExtra()
        {
            StaticMap.StaticMap.ApiUrl = "https://maps.googleapis.com/maps/api/staticmap";
            StaticMap.StaticMap.GoogleKey = "AIzaSyDlHLSiBVLFijxMxz846ZAraExGOjYFLzs";

            Dictionary<string, string> ops = new Dictionary<string, string>();

            ops.Add("maptype", "satellite");

            var result = StaticMap.StaticMap.DownloadMap(18.452343, -69.952257, ops);
            Assert.AreNotEqual(null, result);
            File.WriteAllBytes("imageWithParam.png", result);
        }
    }
}
