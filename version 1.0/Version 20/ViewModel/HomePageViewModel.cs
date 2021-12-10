using System.Windows.Input;

namespace Version_20.ViewModel
{
    public class HomePageViewModel : ViewModelBase
    {
        public string WelcomeMessage => "welcome to my app";

        public ICommand NavigateCreateCommand { get; }
    }
}