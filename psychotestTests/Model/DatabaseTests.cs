
using psychotest.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;

namespace psychotest.Model.Tests
{
    [TestClass]
    public class DatabaseTests
    {

        [TestMethod()]
        public async Task GetProbeTest_CorrectID()
        {
            string correctProbeID = "112";
            var p = await Database.GetProbe(correctProbeID);
            Console.WriteLine("id: " + p.ID);
            Console.WriteLine("score: " + p.Score.ToString());
            Console.WriteLine("Time: " + p.Time.ToString());
            Console.WriteLine("Done: " + p.Done.ToString());

            Assert.IsTrue(true);
        }

        [TestMethod()]
        public async Task GetProbeTest_InCorrectID()
        {
            string inCorrectProbeID = "999";
            await Assert.ThrowsExceptionAsync<ArgumentOutOfRangeException>(async () => await Database.GetProbe(inCorrectProbeID));

        }

        [TestMethod()]
        public async Task GetProbeTest_ConnectionIssue()
        {
            string inCorrectProbeID = "999";
            await Assert.ThrowsExceptionAsync<WebException>(async () => await Database.GetProbe(inCorrectProbeID));

        }

        [TestMethod()]
        public async Task PostProbeTest()
        {
            var probe = new ProbeResult()
            {
                ID = "5555555555",
                Done = true,
                Q1Answer = "1",
                Q2Answer = "1",
                Q3Answer = "1",
                Q4Answer = "1",
                Q5Answer = "male",
                Score = 30,
                Time = 99
            };

            await Database.PostProbe(probe);
            Assert.IsTrue(true);
        }
    }
}