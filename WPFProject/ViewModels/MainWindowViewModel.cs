
using System.Windows;
using System.Windows.Input;
using WPFProject.Infrastructure.Commands;
using WPFProject.ViewModels.Base;

namespace WPFProject.ViewModels
{
    internal class MainWindowViewModel : ViewModelBase
    {
        #region Title
        private string _Title = "WPFProject";
        /// <summary>Window title</summary>
        public string Title
        {
            get { return _Title; }
            set => Set(ref _Title, value);
        }

        private string _Status ="Ready";
        /// <summary>Program status</summary>
        public string Status
        {
            get { return _Status; }
            set => Set(ref _Status, value);
        }
        #endregion
        #region Commands
        #region CloseApplicationCommand
        public ICommand CloseApplicationCommand { get; }

        private bool CanCloseApplicationCommandExecute(object p) => true;
        private void OnCloseApplicationCommandExecuted(object p)
        {
            Application.Current.Shutdown();
        }
        #endregion

        #endregion

        public MainWindowViewModel()
        {
            #region Commands


            CloseApplicationCommand = new LambdaCommand(OnCloseApplicationCommandExecuted, CanCloseApplicationCommandExecute);


            #endregion
        }
    }
}
