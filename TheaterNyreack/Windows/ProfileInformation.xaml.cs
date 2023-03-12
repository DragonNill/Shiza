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
using TheaterNyreack.Models;

namespace TheaterNyreack.Windows
{
    /// <summary>
    /// Логика взаимодействия для ProfileInformation.xaml
    /// </summary>
    public partial class ProfileInformation : Window
    {
        User currentUser;

        public ProfileInformation(User currentUser)
        {
            InitializeComponent();
            this.currentUser = currentUser;
        }

        private void exitButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (currentUser.UserRoleId != 1)
            {
                loginTextBox.Text = currentUser.UserLogin;
                nameTextBox.Text = currentUser.UserName;
                passwordTextBox.Text = currentUser.UserPassword;
                patronomycTextBox.Text = currentUser.UserPatronimyc;
                surnameTextBox.Text = currentUser.UserSurname;
            }
            else
            {
                addButton.Visibility = Visibility.Visible;
                updateButton.Visibility = Visibility.Hidden;
            }

        }

        private void updateButton_Click(object sender, RoutedEventArgs e)
        {
            if(!string.IsNullOrWhiteSpace(loginTextBox.Text) && !string.IsNullOrWhiteSpace(nameTextBox.Text) && !string.IsNullOrWhiteSpace(passwordTextBox.Text)
                && !string.IsNullOrWhiteSpace(patronomycTextBox.Text) && !string.IsNullOrWhiteSpace(surnameTextBox.Text))
            {
                currentUser.UserName = nameTextBox.Text;
                currentUser.UserLogin = loginTextBox.Text;
                currentUser.UserPatronimyc = patronomycTextBox.Text;
                currentUser.UserSurname = surnameTextBox.Text;
                currentUser.UserPassword = passwordTextBox.Text;

                TheaterNyreckContext.DbContext.SaveChanges();
                Close();
            }
            else
            {
                MessageBox.Show("Все поля должны быть заполнены", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(loginTextBox.Text) && !string.IsNullOrWhiteSpace(nameTextBox.Text) && !string.IsNullOrWhiteSpace(passwordTextBox.Text)
                && !string.IsNullOrWhiteSpace(patronomycTextBox.Text) && !string.IsNullOrWhiteSpace(surnameTextBox.Text))
            {
                User newUser = new User();

                newUser.UserRoleId = 3;
                newUser.UserName = nameTextBox.Text;
                newUser.UserLogin = loginTextBox.Text;
                newUser.UserPatronimyc = patronomycTextBox.Text;
                newUser.UserSurname = surnameTextBox.Text;
                newUser.UserPassword = passwordTextBox.Text;


                TheaterNyreckContext.DbContext.Users.Add(newUser);
                TheaterNyreckContext.DbContext.SaveChanges();
                Close();
            }
            else
            {
                MessageBox.Show("Все поля должны быть заполнены", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
