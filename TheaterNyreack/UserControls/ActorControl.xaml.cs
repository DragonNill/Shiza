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
    /// Логика взаимодействия для ActorControl.xaml
    /// </summary>
    public partial class ActorControl : UserControl
    {
        public User currentUser;

        public ActorControl(User currentUser)
        {
            InitializeComponent();
            this.currentUser = currentUser;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            nameLabel.Content = currentUser.UserName;
            surnameDescriptionLabel.Content = currentUser.UserSurname;
            patronomycBudgetLabel.Content = currentUser.UserPatronimyc;
        }
    }
}
