using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Dan_XLVIII_Bojana_Backo.View
{
    /// <summary>
    /// Interaction logic for LoginScreen.xaml
    /// </summary>
    public partial class LoginScreen : Window
    {
        public LoginScreen()
        {
            InitializeComponent();
        }
        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txtUsername.Text.Equals("Zaposleni") && txtPassword.Password.Equals("Zaposleni"))
                {
                    ManagerWindow dashboard = new ManagerWindow();
                    dashboard.Show();
                    this.Close();
                }
                else if (JMBGValidation.IsValid(txtUsername.Text) && txtPassword.Password.Equals("Gost"))
                {
                    Service service = new Service();

                    if (!service.IsUser(txtUsername.Text))
                    {
                        Service.userGuest = service.AddUser(txtUsername.Text);
                        MainWindow dashboard = new MainWindow();
                        dashboard.Show();
                        this.Close();
                    }
                    else
                    {
                        Service.userGuest = service.FindUser(txtUsername.Text);
                        UserWindow userWindow = new UserWindow();
                        MainWindow dashboard = new MainWindow();
                        userWindow.ShowDialog();
                        dashboard.Show();
                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Username or password is incorrect.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                //sqlCon.Close();
            }
        }
    }
}
