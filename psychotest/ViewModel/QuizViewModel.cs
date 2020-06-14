using psychotest.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace psychotest.ViewModel
{
    public class QuizViewModel : BaseViewModel, IPageViewModel
    {

        public QuizViewModel()
        {
            AllQuests = QuestCreator.CreateDefaultQuests(NumOfQuests);
        }

        public List<Quest> AllQuests  { get; set; }

        // Only access - those are conversions of AllQuests
        public List<GroupOf5Quests> GroupedQuests
        {
            get => GroupOf5QuestsConverter.ConvertToGroupOf5Quests(AllQuests);
        }

        public List<GroupOf5Quests> ExampleQuests
        {
            get
            {
                var quests = QuestCreator.CreateExampleQuests();
                return GroupOf5QuestsConverter.ConvertToGroupOf5Quests(quests);
            }
        }

        public int NumOfQuests { get; } = 50;

        public int CorrectAnswerCounter { get; private set; } = 0;

        private Stopwatch stopwatch { get; set; } = new Stopwatch();

        public long ElapsedTime
        {
            get
            {
                if (!stopwatch.IsRunning)
                    return stopwatch.ElapsedMilliseconds / 1000;

                else
                    return -1;
            }
        }



        // Callbacks

        public void OnQuizBegin(object obj)
        {
            CorrectAnswerCounter = 0;
            Console.WriteLine("Start quizu.");
            stopwatch.Start();
        }

        public void OnQuizReset(object obj)
        {
            for (int i = 0; i < AllQuests.Count; i++)
            {
                AllQuests[i].UserAnswer = "";
            }
        }

        public void OnAnswerSet(object obj)
        {
            if (AllQuestsDone())
            {
                Mediator.Notify("QuizDone", "");
                Console.WriteLine("Wykonano wszystkie zadania. Czas stop.");
                stopwatch.Stop();
                CalculateCorrectAnswers();
            }
        }

        private bool AllQuestsDone()
        {
            bool ready = true;
            foreach (var quest in AllQuests)
            {
                if (!quest.Done)
                {
                    ready = false;
                    break;
                }
            }

            return ready;
        }

        private void CalculateCorrectAnswers()
        {
            int count = 0;
            foreach(var quest in AllQuests)
            {
                if (quest.UserAnswerInt == quest.CorrectAnswer)
                    count++;
            }
            CorrectAnswerCounter = count;

            Console.WriteLine("Licznik poprawnych odpowiedzi: " + CorrectAnswerCounter);
        } 
    }
}
