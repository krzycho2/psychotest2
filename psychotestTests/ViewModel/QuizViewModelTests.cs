
using Microsoft.VisualStudio.TestTools.UnitTesting;
using psychotest.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace psychotest.ViewModel.Tests
{
    [TestClass]
    public class QuizViewModelTests
    {
        [TestMethod]
        public void DoneButtonActiveTest_1unDoneInTheMiddle()
        {
            // Arrange
            var qvm = new QuizViewModel();
            for (int i = 0; i < qvm.AllQuests.Count - 1; i++)
                qvm.AllQuests[i].UserAnswer = "1";

            qvm.AllQuests[2].UserAnswer = "";
            // Assert

        }

        [TestMethod]
        public void DoneButtonActiveTest_1unDoneInTheEnd()
        {
            // Arrange
            var qvm = new QuizViewModel();
            for (int i = 0; i < qvm.AllQuests.Count - 1; i++)
                qvm.AllQuests[i].UserAnswer = "1";

            // Assert


        }


    }
}