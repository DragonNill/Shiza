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
    /// Логика взаимодействия для ContractControl.xaml
    /// </summary>
    public partial class ContractControl : UserControl
    {
        Contract currentContract;

        public ContractControl(Contract currentContract)
        {
            InitializeComponent();
            this.currentContract = currentContract;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            nameShowLabel.Content = $"Наименование спектакля: {currentContract.ContractShow.ShowName}";
            actorLabel.Content = $"Актер: {currentContract.ContractActor.UserName} {currentContract.ContractActor.UserSurname} {currentContract.ContractActor.UserPatronimyc}";
            directorLabel.Content = $"Директор: {currentContract.ContractDirector.UserName} {currentContract.ContractDirector.UserSurname} {currentContract.ContractDirector.UserPatronimyc}";
        }
    }
}
