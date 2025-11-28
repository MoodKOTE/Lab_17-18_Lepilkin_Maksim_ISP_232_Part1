using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LoginDemo.Views
{
    public partial class LoginControl : UserControl
    {
        private string dbPath = @"Data Source=C:\SOFT\authdemo.db";
        public LoginControl()
        {
            InitializeComponent();
        }

        private void Login_Click(object sender, RoutedEventArgs e) {
            string login = InputLogin.Text;
            string password = InputPassword.Password;
            using var connection = new SqliteConnection(dbPath);
            connection.Open();
            using var command = new SqliteCommand("SELECT Role FROM Users WHERE Login = $l AND Password = $p", connection);
            command.Parameters.AddWithValue("$l", login);
            command.Parameters.AddWithValue("$p", password);
            var role = command.ExecuteScalar()?.ToString();
            if (role == null) {
                InfoText.Text = "Неверный логин или пароль";
                return;
            }
            if (role == "Admin")
                (Window.GetWindow(this) as MainWindow)?.SwitchAdmin();
            else
                (Window.GetWindow(this) as MainWindow)?.SwitchToUser();
        }
    }
}
