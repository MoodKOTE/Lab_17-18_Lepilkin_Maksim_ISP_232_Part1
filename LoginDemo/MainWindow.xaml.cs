using LoginDemo.Views; 
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LoginDemo {
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
            MainContent.Content = new LoginControl();
        }
        public void SwitchAdmin() {
            MainContent.Content = new AdminControl();
        }
        public void SwitchToUser() {
            MainContent.Content = new UserControl();
        }
        public void SwitchToLogin() {
            MainContent.Content = new LoginControl();
        }
    }
}
