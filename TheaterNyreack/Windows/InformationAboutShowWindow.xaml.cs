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
    /// Логика взаимодействия для InformationAboutShowWindow.xaml
    /// </summary>
    public partial class InformationAboutShowWindow : Window
    {
        Show currentShow;
        int currentAction;

        public InformationAboutShowWindow(Show currentShow, int i)
        {
            InitializeComponent();
            this.currentShow = currentShow;
            this.currentAction = i;
        }

        private void exitButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void addOrUpdateButton_Click(object sender, RoutedEventArgs e)
        {

            if (!string.IsNullOrWhiteSpace(nameTextBox.Text) && !string.IsNullOrWhiteSpace(descriptionTextBox.Text)
                && !string.IsNullOrWhiteSpace(budgetTextBox.Text) && dateDataPicker.SelectedDate != null)
            {
                if (currentAction == 2)
                {
                    Show newShow = new Show();
                    newShow.ShowName = nameTextBox.Text;
                    newShow.ShowDescription = descriptionTextBox.Text;
                    newShow.ShowBudget = Convert.ToInt32(budgetTextBox.Text);
                    newShow.ShowData = dateDataPicker.SelectedDate;

                    TheaterNyreckContext.DbContext.Add(newShow);
                    TheaterNyreckContext.DbContext.SaveChanges();
                    Close();
                }
                else if (currentAction == 3)
                {
                    currentShow.ShowName = nameTextBox.Text;
                    currentShow.ShowDescription = descriptionTextBox.Text;
                    currentShow.ShowBudget = Convert.ToInt32(budgetTextBox.Text);
                    currentShow.ShowData = dateDataPicker.SelectedDate;

                    TheaterNyreckContext.DbContext.SaveChanges();
                    Close();
                }

            }
            else
            {
                MessageBox.Show("Поля не должны быть пустыми", "Предупреждение",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
            }

        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            TheaterNyreckContext.DbContext.Shows.Remove(currentShow);
            TheaterNyreckContext.DbContext.SaveChanges();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (currentAction == 1) //Delete
            {
                deleteButton.Visibility = Visibility.Hidden;
                FillInformationAboutShow();
            }
            else if(currentAction == 2)//Add
            {
                addOrUpdateButton.Visibility = Visibility.Visible;

            }
            else if (currentAction == 3)//UpdateOrDelete
            {
                addOrUpdateButton.Visibility = Visibility.Visible;
                deleteButton.Visibility = Visibility.Hidden;
                addOrUpdateButton.Content = "Редактировать";
                FillInformationAboutShow();

            }
            else if (currentAction == 4)//Оформить контракт
            {
                addOrUpdateButton.Visibility = Visibility.Visible;
                addOrUpdateButton.Content = "Оформить контракт";
                EnabledOrDisabledInformation();
                FillInformationAboutShow();

            }
            else
            {
                EnabledOrDisabledInformation();
                FillInformationAboutShow();
            }
        }

        private void FillInformationAboutShow()
        {
            nameTextBox.Text = currentShow.ShowName;
            descriptionTextBox.Text = currentShow.ShowDescription;
            budgetTextBox.Text = currentShow.ShowBudget.ToString();
            dateDataPicker.SelectedDate = currentShow.ShowData;
        }

        private void EnabledOrDisabledInformation()
        {
            nameTextBox.IsEnabled = false;
            descriptionTextBox.IsEnabled = false;
            budgetTextBox.IsEnabled = false;
            dateDataPicker.IsEnabled = false;
        }

        private void budgetTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }
        }

        private void budgetTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!char.IsDigit(e.Text, e.Text.Length - 1) && e.Text != "-")
            {
                e.Handled = true;
            }
        }
    }
}
