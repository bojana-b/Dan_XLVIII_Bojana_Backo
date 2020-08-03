using Dan_XLVIII_Bojana_Backo.ViewModel;
using System.Windows;

namespace Dan_XLVIII_Bojana_Backo.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new MainWindowViewModel(this);
        }
    }
}
