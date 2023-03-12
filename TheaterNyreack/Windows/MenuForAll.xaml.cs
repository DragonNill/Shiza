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
    /// Логика взаимодействия для MenuForAll.xaml
    /// </summary>
    public partial class MenuForAll : Window
    {
        User currentUser;

        public MenuForAll(User currentUser)
        {
            InitializeComponent();
            this.currentUser = currentUser;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (currentUser.UserRoleId == 1)
            {
                profileAndAddNewActorButton.Content = "Добавить нового актера";
                showListContractsButton.Visibility = Visibility.Hidden;
            }
        }

        private void exitButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void showListShowsButton_Click(object sender, RoutedEventArgs e)
        {
            Window nextWindow = new showListShows(currentUser);
            nextWindow.ShowDialog();
            
        }

        private void profileAndAddNewActorButton_Click(object sender, RoutedEventArgs e)
        {
            Window nextWindow = new ProfileInformation(currentUser);
            nextWindow.ShowDialog();
        }

        private void showListContractsButton_Click(object sender, RoutedEventArgs e)
        {
            Window nextWindow = new ShowListContracts(currentUser);
            nextWindow.ShowDialog();

        }
    }
}
