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
    /// Логика взаимодействия для ShowListContracts.xaml
    /// </summary>
    public partial class ShowListContracts : Window
    {
        User currentUser;

        public ShowListContracts(User currentUsers)
        {
            InitializeComponent();
            this.currentUser = currentUsers;
        }

        private void exitButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {
            FillListView();
        }

        private void FillListView()
        {
            showContractListView.Items.Clear();

            List<Contract> contractsList = TheaterNyreckContext.DbContext.Contracts.ToList();

            if (currentUser.UserRoleId == 3)
            {
                contractsList = contractsList.Where(w => w.ContractActorId == currentUser.UserId).ToList();
            }

            if (!string.IsNullOrWhiteSpace(findTextBox.Text))
            {
                contractsList = contractsList.Where(f => f.ContractShow.ShowName.ToLower().Contains(findTextBox.Text.ToLower())).ToList();
            }

            foreach(Contract contract in contractsList)
            {
                showContractListView.Items.Add(new ContractControl(contract)
                {
                    Width = GetOprimizedWidth()
                });
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
    }
}
