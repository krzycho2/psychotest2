using psychotest.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace psychotest.View
{
    /// <summary>
    /// Logika interakcji dla klasy HelloView.xaml
    /// </summary>
    public partial class HelloView : UserControl
    {
        public HelloView()
        {
            InitializeComponent();
            HideIDInputError();
        }

        private void userIDInput_TextChanged(object sender, TextChangedEventArgs e)
        {
            Console.WriteLine("TextChanged. Text: ");
            Console.WriteLine(userIDInput.Text);
            ValidateUserID(userIDInput.Text);
        }

        private void ValidateUserID(string userInput)
        {
            bool parseOK = Regex.IsMatch(userInput, @"^\d{10}$");

            if (parseOK)
            {
                EnableQuizBegin();
                HideIDInputError();
            }

            else
            {
                ShowIDInputError();
                DisableQuizBegin();
            }
        }

        private void EnableQuizBegin()
        {
            QuizBeginButton.IsEnabled = true;
        }

        private void DisableQuizBegin()
        {
            QuizBeginButton.IsEnabled = false;
        }

        private void ShowIDInputError()
        {
            IDInputErrorMsg.Visibility = Visibility.Visible;
        }

        private void HideIDInputError()
        {
            IDInputErrorMsg.Visibility = Visibility.Hidden;
        }

        private async void QuizBeginButton_Click(object sender, RoutedEventArgs e)
        {
            string userID = userIDInput.Text;
            bool idCorrect = false; 
            try
            {
                idCorrect = await IdCorrect(userID);
                if (idCorrect)
                    Mediator.Notify("QuizBegin", "");

                else
                    MessageBox.Show("Test już wykonany!");
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Niepoprawny ID!");
            }
            
        }
        
        public async Task<bool> IdCorrect(string id)
        {
            try
            {
                var probe = await Database.GetProbe(id);
                if (probe.Done)
                    return false;
                else
                    return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
