
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using WPFProject.Models.Decanat;

namespace WPFProject
{  
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void GroupsCollection_Filter(object sender, System.Windows.Data.FilterEventArgs e)
        {
            if (!(e.Item is Group group)) return;
            if(group.GroupName is null) return;

            var filter_text = GroupNameFilterText.Text;
            if(filter_text.Length == 0) return;

            if (group.GroupName.Contains(filter_text, System.StringComparison.OrdinalIgnoreCase));
            if(group.Description != null &&group.Description.Contains(filter_text, System.StringComparison.OrdinalIgnoreCase));

            e.Accepted = false;

        }

        private void OnGroupsFilterTextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            var text_box = (TextBox)sender;
            var collection = (CollectionViewSource)text_box.FindResource("GroupsCollection");
            collection.View.Refresh();
        }
    }
}
