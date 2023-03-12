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

namespace TheaterNyreack.UserControls
{
    /// <summary>
    /// Логика взаимодействия для ShowControl.xaml
    /// </summary>
    public partial class ShowControl : UserControl
    {
        public Show currentShow;

        public ShowControl(Show currentShow)
        {
            InitializeComponent();
            this.currentShow = currentShow;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            showBudgetLabel.Content = currentShow.ShowBudget + " руб.";
            showNameLabel.Content = currentShow.ShowName;
            showDescriptionLabel.Content = "Описание: " + currentShow.ShowDescription;
        }
    }
}
