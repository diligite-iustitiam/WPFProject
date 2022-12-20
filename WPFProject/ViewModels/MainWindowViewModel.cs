
using WPFProject.ViewModels.Base;

namespace WPFProject.ViewModels
{
    internal class MainWindowViewModel : ViewModelBase
    {
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
    }
}
