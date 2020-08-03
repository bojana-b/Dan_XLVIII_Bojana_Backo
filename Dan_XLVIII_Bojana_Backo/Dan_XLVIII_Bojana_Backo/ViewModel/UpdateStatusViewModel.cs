using Dan_XLIV_Bojana_Backo.Commands;
using Dan_XLVIII_Bojana_Backo.View;
using System;
using System.Windows;
using System.Windows.Input;

namespace Dan_XLVIII_Bojana_Backo.ViewModel
{
    class UpdateStatusViewModel : ViewModelBase
    {
        UpdateStatus updateStatus;
        Service service = new Service();

        public UpdateStatusViewModel(UpdateStatus updateStatusOpen, tblOrder orderEdit)
        {
            updateStatus = updateStatusOpen;
            order = orderEdit;

            oldOrder = new tblOrder();
            oldOrder.OrderID = oldOrder.OrderID;
            oldOrder.Name = oldOrder.Name;
            oldOrder.OrderDate = oldOrder.OrderDate;
            oldOrder.Price = oldOrder.Price;
            oldOrder.UserID = oldOrder.UserID;
            oldOrder.OrderStatus = order.OrderStatus;
        }

        public UpdateStatusViewModel(tblOrder order)
        {
            this.order = order;
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

        private tblOrder oldOrder;

        private string status = "approved";
        public string Status
        {
            get { return status; }
            set
            {
                status = value;
                OnPropertyChanged("Status");
            }
        }

        private bool isUpdateOrder;
        public bool IsUpdateOrder
        {
            get
            {
                return isUpdateOrder;
            }
            set
            {
                isUpdateOrder = value;
            }
        }
        #endregion

        #region Commands
        private ICommand chooseStatus;
        public ICommand ChooseStatus
        {
            get
            {
                if (chooseStatus == null)
                {
                    chooseStatus = new RelayCommand(ChooseStatusExecute, CanChooseStatusExecute);
                }
                return chooseStatus;
            }
        }

        private void ChooseStatusExecute(object parameter)
        {
            Status = (string)parameter;
        }

        private bool CanChooseStatusExecute(object parameter)
        {
            if (parameter != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private ICommand save;
        public ICommand Save
        {
            get
            {
                if (save == null)
                {
                    save = new RelayCommand(param => SaveExecute(), param => CanSaveExecute());
                }
                return save;
            }
        }

        private void SaveExecute()
        {
            try
            {
                if (Status.Equals("approved"))
                {
                    order.OrderStatus = "approved";
                }
                else if (Status.Equals("rejected"))
                {
                    order.OrderStatus = "rejected";
                }
                service.EditOrderStatus(order);
                isUpdateOrder = true;

                updateStatus.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        internal void ShowDialog()
        {
            throw new NotImplementedException();
        }

        private bool CanSaveExecute()
        {
            return true;
        }
        #endregion
    }
}
