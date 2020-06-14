using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace psychotest.ViewModel
{
    class SummaryViewModel : BaseViewModel, IPageViewModel
    {
        private ICommand _goToHelloView;
        private ICommand _closeProgram;

        public ICommand GoToHelloView
        {
            get
            {
                Console.WriteLine("Wywołanie restart");
                return _goToHelloView ?? (_goToHelloView = new RelayCommand( x => Mediator.Notify("Restart", "")) );
            }
        }

        public ICommand CloseProgram
        {
            get
            {
                return _closeProgram ?? (_closeProgram = new RelayCommand(x => Mediator.Notify("CloseProgram", "")));
            }
        }
    }
}
