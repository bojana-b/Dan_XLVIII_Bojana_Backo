using Dan_XLVIII_Bojana_Backo.ViewModel;
using System.Windows;

namespace Dan_XLVIII_Bojana_Backo.View
{
    /// <summary>
    /// Interaction logic for UpdateStatus.xaml
    /// </summary>
    public partial class UpdateStatus : Window
    {
        public UpdateStatus(tblOrder orderUpdate)
        {
            InitializeComponent();
            this.DataContext = new UpdateStatusViewModel(this, orderUpdate);
        }
    }
}
