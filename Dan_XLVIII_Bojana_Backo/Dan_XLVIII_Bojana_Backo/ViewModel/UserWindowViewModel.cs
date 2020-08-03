using Dan_XLVIII_Bojana_Backo.View;
using System.Collections.Generic;

namespace Dan_XLVIII_Bojana_Backo.ViewModel
{
    class UserWindowViewModel : ViewModelBase
    {
        UserWindow userWindow;
        Service service = new Service();

        public UserWindowViewModel(UserWindow userWindowOpen)
        {
            userWindow = userWindowOpen;
            OrderList = service.GetUserOrder();
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
    }
}
