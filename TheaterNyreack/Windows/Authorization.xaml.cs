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
using System.Windows.Navigation;
using System.Windows.Shapes;
using TheaterNyreack.Models;
using TheaterNyreack.Windows;


namespace TheaterNyreack
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void loginInButton_Click(object sender, RoutedEventArgs e)
        {
            if(!string.IsNullOrWhiteSpace(loginTextBox.Text) && !string.IsNullOrWhiteSpace(passwordPasswordBox.Password))
            {
                User user = TheaterNyreckContext.DbContext.Users.FirstOrDefault(l => l.UserLogin == loginTextBox.Text && l.UserPassword == passwordPasswordBox.Password);

                if (user != null)
                {
                    MessageBox.Show($"Вы успешно авторизовались как: {user.UserName} {user.UserSurname} {user.UserPatronimyc}", "Уведомление",
                            MessageBoxButton.OK, MessageBoxImage.Information);

                    Window nextWindows = new MenuForAll(user);
                    Hide();
                    nextWindows.ShowDialog();
                    Show();
                }
                else
                {
                    MessageBox.Show("Такого пользователя не существует", "Предупреждение", 
                        MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
        }
    }
}
