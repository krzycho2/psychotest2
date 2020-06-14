using psychotest.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace psychotest.ViewModel
{
    class SurveyViewModel : BaseViewModel, IPageViewModel
    {
        private SurveyAnswer _q1Answer = SurveyAnswer.none;
        private SurveyAnswer _q2Answer = SurveyAnswer.none;
        private SurveyAnswer _q3Answer = SurveyAnswer.none;
        private string _q4Answer = "";
        private Gender _q5Answer = Gender.Unknown;

        public SurveyAnswer Q1Answer
        {
            get => _q1Answer;
            set
            {
                _q1Answer = value;
                OnPropertyChanged("Q1Answer");
                Console.WriteLine("Ustawiono odpowiedź 1 na: " + value.ToString());

                if (AllQuestionsAnswered())
                    Mediator.Notify("SurveyDone", "");
            }
        }
        public SurveyAnswer Q2Answer
        {
            get => _q2Answer;
            set
            {
                _q2Answer = value;
                OnPropertyChanged("Q2Answer");
                Console.WriteLine("Ustawiono odpowiedź 2 na: " + value.ToString());

                if (AllQuestionsAnswered())
                    Mediator.Notify("SurveyDone", "");
            }
        }

        public SurveyAnswer Q3Answer
        {
            get => _q3Answer;
            set
            {
                _q3Answer = value;
                OnPropertyChanged("Q3Answer");
                Console.WriteLine("Ustawiono odpowiedź 3 na: " + value.ToString());

                if (AllQuestionsAnswered())
                    Mediator.Notify("SurveyDone", "");
            }
        }

        public string Q4Answer
        {
            get => _q4Answer;
            set
            {
                _q4Answer = value;
                OnPropertyChanged("Q4Answer");
                Console.WriteLine("Ustawiono odpowiedź 4 na: " + value.ToString());

                if (AllQuestionsAnswered())
                    Mediator.Notify("SurveyDone", "");
            }
        }

        public SurveyAnswer Q5Answer
        {
            get
            {
                if (_q5Answer == Gender.Male)
                    return SurveyAnswer.one;

                else if (_q5Answer == Gender.Female)
                    return SurveyAnswer.two;

                else
                    return SurveyAnswer.none;
            }

            set
            {
                if (value == SurveyAnswer.one)
                    _q5Answer = Gender.Male;

                else if (value == SurveyAnswer.two)
                    _q5Answer = Gender.Female;

                else if (value == SurveyAnswer.none)
                    _q5Answer = Gender.Unknown;

                else
                    throw new ArgumentOutOfRangeException("Niepoprawna płeć");

                OnPropertyChanged("Q5Answer");
                Console.WriteLine("Ustawiono odpowiedź 5 na: " + Q5AnswerGender.ToString());

                if (AllQuestionsAnswered())
                    Mediator.Notify("SurveyDone", "");
            }
        }

        public Gender Q5AnswerGender
        {
            get => _q5Answer;
        }

        private bool AllQuestionsAnswered()
        {
            if (Q1Answer == SurveyAnswer.none || Q2Answer == SurveyAnswer.none || Q3Answer == SurveyAnswer.none || Q4Answer == "" || Q5Answer == SurveyAnswer.none)
                return false;
            else
                return true;
        }

        // Callbacks
        public void OnSurveyReset(object obj)
        {
            Q1Answer = SurveyAnswer.none;
            Q2Answer = SurveyAnswer.none;
            Q3Answer = SurveyAnswer.none;
            Q4Answer = "";
            Q5Answer = SurveyAnswer.none;
        }
    }
}
