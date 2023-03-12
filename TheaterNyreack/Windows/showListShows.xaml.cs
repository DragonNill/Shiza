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
using TheaterNyreack.UserControls;

namespace TheaterNyreack.Windows
{
    /// <summary>
    /// Логика взаимодействия для showListShows.xaml
    /// </summary>
    public partial class showListShows : Window
    {
        User currentUser;

        public showListShows(User currentUser)
        {
            InitializeComponent();
            this.currentUser = currentUser;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (currentUser.UserRoleId == 1)
            {
                deleteShowsButton.Visibility = Visibility.Visible;
                addShowsButton.Visibility = Visibility.Visible;
            }
            else if (currentUser.UserRoleId == 2)
            {
                informationAboutShowsButton.Content = "Оформить контракт";
            }
            FillComboBox();
            FillListView();
        }

        private void FillComboBox()
        {
            sortingComboBox.Items.Add("Без сортировки");
            sortingComboBox.Items.Add("По дате ↑");
            sortingComboBox.Items.Add("По дате ↓");
        }

        private void FillListView()
        {
            showsListView.Items.Clear();

            List<Show> showsList = TheaterNyreckContext.DbContext.Shows.ToList();

            if (!string.IsNullOrWhiteSpace(findTextBox.Text))
            {
                showsList = showsList.Where(w => w.ShowName.ToLower().Contains(findTextBox.Text.ToLower())).ToList();
            }

            switch(sortingComboBox.SelectedIndex)
            {
                case 0:
                    break;

                case 1:
                    showsList = showsList.OrderBy(s => s.ShowData).ToList();
                    break;

                case 2:
                    showsList = showsList.OrderByDescending(s => s.ShowData).ToList();
                    break;
            }

            foreach (Show show in showsList)
            {
                showsListView.Items.Add(new ShowControl(show)
                {
                    Width = GetOprimizedWidth()
                });
            }

            if (showsListView.Items.Count == 0)
            {
                MessageBox.Show("Спектакля по вашему запросу не найдено", "Уведомление",
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private double GetOprimizedWidth()
        {
            if (WindowState == WindowState.Maximized)
            {
                return RenderSize.Width - 55;
            }
            else
            {
                return Width - 55;
            }
        }

        private void findTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            FillListView();
        }

        private void sortingComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            FillListView();

        }

        private void informationAboutShowsButton_Click(object sender, RoutedEventArgs e)
        {
            if (showsListView.SelectedItem != null)
            {
                Show show = ((ShowControl)showsListView.SelectedItem).currentShow;
                if (currentUser.UserRoleId == 3)
                {
                    Window nextWindow = new InformationAboutShowWindow(show, 0);
                    nextWindow.ShowDialog();
                }
                else if (currentUser.UserRoleId == 2)
                {
                    Window nextWindow = new ShowListActor(show, currentUser);
                    nextWindow.ShowDialog();
                }
                else if (currentUser.UserRoleId == 1)
                {
                    Window nextWindow = new InformationAboutShowWindow(show, 3);
                    nextWindow.ShowDialog();

                }
                FillListView();
            }
        }

        private void addShowsButton_Click(object sender, RoutedEventArgs e)
        {
            Window nextWindow = new InformationAboutShowWindow(null, 2);
            nextWindow.ShowDialog();
            FillListView();
        }

        private void deleteShowsButton_Click(object sender, RoutedEventArgs e)
        {
            Show show = ((ShowControl)showsListView.SelectedItem).currentShow;
            TheaterNyreckContext.DbContext.Shows.Remove(show);
            TheaterNyreckContext.DbContext.SaveChanges();
            FillListView();
        }
    }
}
