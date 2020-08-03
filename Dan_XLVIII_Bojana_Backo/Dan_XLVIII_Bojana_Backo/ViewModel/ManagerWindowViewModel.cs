using Dan_XLIV_Bojana_Backo.Commands;
using Dan_XLVIII_Bojana_Backo.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace Dan_XLVIII_Bojana_Backo.ViewModel
{
    class ManagerWindowViewModel : ViewModelBase
    {
        ManagerWindow managerWindow;
        Service service = new Service();

        public ManagerWindowViewModel(ManagerWindow managerWindowOpen)
        {
            managerWindow = managerWindowOpen;
            OrderList = service.GetAllOrders();
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

        private List<tblOrder> orderList;
        public List<tblOrder> OrderList
        {
            get
            {
                return orderList;
            }
            set
            {
                orderList = value;
                OnPropertyChanged("OrderList");
            }
        }
        #endregion

        #region Commands 

        private ICommand archive;
        public ICommand Archive
        {
            get
            {
                if (archive == null)
                {
                    archive = new RelayCommand(param => ArchiveExecute(), param => CanArchiveExecute());
                }
                return archive;
            }
        }

        private void ArchiveExecute()
        {
            try
            {
                if (Order != null)
                {

                    MessageBoxResult result = MessageBox.Show("Are you sure that you want to archive this order?",
                       "My App",
                        MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No);
                    int orderID = order.OrderID;

                    switch (result)
                    {
                        case MessageBoxResult.Yes:
                            service.ArchiveOrder(orderID);
                            OrderList = service.GetAllOrders().ToList();
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private bool CanArchiveExecute()
        {
            if (Order == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private ICommand updateStatus;
        public ICommand UpdateStatus
        {
            get
            {
                if (updateStatus == null)
                {
                    updateStatus = new RelayCommand(param => UpdateStatusExecute(), param => CanUpdateStatusExecute());
                }
                return updateStatus;
            }
        }

        private void UpdateStatusExecute()
        {
            try
            {
                if (UpdateStatus != null)
                {
                    UpdateStatus updateStatus = new UpdateStatus(Order);
                    updateStatus.ShowDialog();
                    if ((updateStatus.DataContext as UpdateStatusViewModel).IsUpdateOrder == true)
                    {
                        OrderList = service.GetAllOrders().ToList();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private bool CanUpdateStatusExecute()
        {
            if (Order == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        #endregion 
    }
}
