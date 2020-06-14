
using Microsoft.VisualStudio.TestTools.UnitTesting;
using psychotest.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace psychotest.Model.Tests
{
    [TestClass]
    public class GroupOf5QuestsConverterTests
    {
        [TestMethod]
        public void ConvertToGroupOf5QuestsTest()
        {
            var quests = QuestCreator.CreateDefaultQuests(5);
            var groupedQuests = GroupOf5QuestsConverter.ConvertToGroupOf5Quests(quests);

            foreach(var group in groupedQuests)
            {
                Console.WriteLine("First: " + group.First.shape.shapeType.ToString());
                Console.WriteLine("Second: " + group.Second.shape.shapeType.ToString());
                Console.WriteLine("Third: " + group.Third.shape.shapeType.ToString());
                Console.WriteLine("Fourth: " + group.Fourth.shape.shapeType.ToString());
                Console.WriteLine("Fifth: " + group.Fifth.shape.shapeType.ToString());
                Console.WriteLine();
            }

            Assert.IsTrue(true);
        }
    }
}