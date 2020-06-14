using psychotest.ViewModel;
using psychotest.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace psychotest
{
    /// <summary>
    /// Class for controlling flow between Views and Viewmodels.
    /// It changes the Views and pass data between them.
    /// It's bases on Mediator template - this is the only object (place) in code to transmit data between
    /// objects - viewmodels.
    /// </summary>
    class Controller
    {
        public HelloViewModel helloViewModel { get; set; } = new HelloViewModel();
        public QuizViewModel quizViewModel { get; set; } = new QuizViewModel();
        public SummaryViewModel summaryViewModel { get; set; } = new SummaryViewModel();
        public MainWindowViewModel mainWindowViewModel { get; set; }
        public SurveyViewModel surveyViewModel { get; set; } = new SurveyViewModel();
        

        public Controller()
        {
            mainWindowViewModel = new MainWindowViewModel(helloViewModel);
            MainWindow app = new MainWindow
            {
                DataContext = mainWindowViewModel
            };
            app.Show();

            Mediator.Subscribe("Restart", OnRestart);
            Mediator.Subscribe("QuizDone", OnQuizDone);
            Mediator.Subscribe("QuizBegin", OnQuizBegin);
            Mediator.Subscribe("CloseProgram", OnCloseProgram);
            Mediator.Subscribe("AnswerSet", quizViewModel.OnAnswerSet);
            Mediator.Subscribe("SurveyDone", OnSurveyDone);
            Mediator.Subscribe("IdIncorrect", OnSurveyDone);
        }

        // Event methods
        private void OnRestart(object obj)
        {
            quizViewModel.OnQuizReset(obj);
            surveyViewModel.OnSurveyReset(obj);
            mainWindowViewModel.ChangeViewModel(helloViewModel);
            Console.WriteLine("OnRestart");
        }

        private void OnQuizBegin(object obj)
        {
            Console.WriteLine("quizViewModel.OnQuizBegin");
            mainWindowViewModel.ChangeViewModel(quizViewModel);
            quizViewModel.OnQuizBegin(obj);
        }

        private void OnQuizDone(object obj)
        {
            mainWindowViewModel.ChangeViewModel(surveyViewModel);
        }

        private void OnCloseProgram(object obj)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void OnSurveyDone(object obj)
        {
            mainWindowViewModel.ChangeViewModel(summaryViewModel);
            SaveQuizResultToDB();
            Console.WriteLine("Quiz done. ID: {0}, correctAnswers: {1}, time: {2}: ", helloViewModel.UserID, quizViewModel.CorrectAnswerCounter.ToString(), quizViewModel.ElapsedTime);
            Console.WriteLine("Odpowiedzi w ankiecie: : {0}, {1}, {2} ", surveyViewModel.Q1Answer, surveyViewModel.Q2Answer, surveyViewModel.Q3Answer);
        }

        public async void SaveQuizResultToDB()
        {
            var probeResult = new ProbeResult()
            {
                ID = helloViewModel.UserID,
                Score = quizViewModel.CorrectAnswerCounter,
                Time = (int)quizViewModel.ElapsedTime,
                Q1Answer = ((int)surveyViewModel.Q1Answer).ToString(),
                Q2Answer = ((int)surveyViewModel.Q2Answer).ToString(),
                Q3Answer = ((int)surveyViewModel.Q3Answer).ToString(),
                Q4Answer = surveyViewModel.Q4Answer.ToString(),
                Q5Answer = surveyViewModel.Q5AnswerGender.ToString(),
                Done = true

            };

            await Database.PostProbe(probeResult);
        }
    }
}
