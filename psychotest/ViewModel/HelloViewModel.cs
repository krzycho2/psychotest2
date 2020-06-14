using psychotest.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;

namespace psychotest.ViewModel
{
    public class HelloViewModel : BaseViewModel, IPageViewModel
    {
        private string _userID;

        //public ICommand GoToQuizView
        //{
            //get
            //{
            //    bool IDcorrect = false;


            //    return  new RelayCommand( x => 
            //    {
            //        if (IDcorrect)
            //            Mediator.Notify("QuizBegin", "");

            //        else
            //            MessageBox.Show("Niepoprawny ID!");
            //    });
            //}
        //}

        public string UserID
        {
            get {
                Console.WriteLine("ViewModel: Pobrana wartość");
                return _userID;
            }
            set
            {
                Console.WriteLine("HelloViewModel: UserID: " + value);
                _userID = value;
            }
        }

        public GroupOf5Quests ExampleQuests
        {
            get => new GroupOf5Quests(QuestCreator.CreateExampleQuests());

        }

        public async Task<bool> IdCorrect()
        {
            try
            {
                var probe = await Database.GetProbe(UserID);
                if (probe.Done)
                    return false;
                else
                    return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        // Callbacks
        public void OnRestart(object obj)
        {

        }
    }
}
