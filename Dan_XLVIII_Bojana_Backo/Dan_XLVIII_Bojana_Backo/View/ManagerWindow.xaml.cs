using Dan_XLVIII_Bojana_Backo.ViewModel;
using System.Windows;

namespace Dan_XLVIII_Bojana_Backo.View
{
    /// <summary>
    /// Interaction logic for ManagerWindow.xaml
    /// </summary>
    public partial class ManagerWindow : Window
    {
        public ManagerWindow()
        {
            InitializeComponent();
            this.DataContext = new ManagerWindowViewModel(this);
        }
    }
}
