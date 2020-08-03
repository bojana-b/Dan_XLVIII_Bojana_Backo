using Dan_XLIV_Bojana_Backo.Commands;
using Dan_XLVIII_Bojana_Backo.View;
using System;
using System.Windows.Input;

namespace Dan_XLVIII_Bojana_Backo.ViewModel
{
    class MainWindowViewModel : ViewModelBase
    {
        MainWindow main;
        Service service = new Service();

        public MainWindowViewModel(MainWindow mainOpen)
        {
            main = mainOpen;
            order = new tblOrder();
        }

        #region Properties
        private tblOrder order;
        public tblOrder Order
        {
            get
            {
                return order;
            }
            set
            {
                order = value;
                OnPropertyChanged("Order");
            }
        }
        #endregion

        #region Commands

        // Command to add new order
        private ICommand addOrder;
        public ICommand AddOrder
        {
            get
            {
                if (addOrder == null)
                {
                    addOrder = new RelayCommand(param => SaveExecute(), param => CanSaveExecute());
                }
                return addOrder;
            }
        }

        private void SaveExecute()
        {
            LoginScreen login = new LoginScreen();
            service.AddOrder(Order);
            main.Close();
            login.ShowDialog();
        }

        private bool CanSaveExecute()
        {
            if (String.IsNullOrEmpty(order.Name))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private ICommand ok;
        public ICommand Ok
        {
            get
            {
                if (ok == null)
                {
                    ok = new RelayCommand(param => SaveOkExecute(), param => CanSaveOkExecute());
                }
                return ok;
            }
        }

        private void SaveOkExecute()
        {
            if (order.Name.Equals("Capricciosa"))
            {
                order.Price = 1200;
            }
            else if (order.Name.Equals("Margherita"))
            {
                order.Price = 1000;
            }
            else if (order.Name.Equals("Quattro Stagioni"))
            {
                order.Price = 1600;
            }
            else if (order.Name.Equals("Quattro Formaggi"))
            {
                order.Price = 1500;
            }
            else if (order.Name.Equals("Vegeteriana"))
            {
                order.Price = 1100;
            }
        }

        private bool CanSaveOkExecute()
        {
            return true;
        }
        #endregion
    }
}
