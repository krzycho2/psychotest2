using NUnit.Framework;
using psychotest.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace psychotest.ViewModel.Tests
{
    public class HelloViewModelTests
    {
        [TestCase("2222222222", false)]
        [TestCase("3333333333", false)]
        [TestCase("5555555555", true)]
        [TestCase("7777777777", false)]
        [TestCase("8888888888", false)]

        public async Task IdCorrectTest(string ID, bool expectedDecision)
        {
            var viewmodel = new HelloViewModel
            {
                UserID = ID
            };

             Assert.AreEqual(expectedDecision, await viewmodel.IdCorrect());
        }

    }
}