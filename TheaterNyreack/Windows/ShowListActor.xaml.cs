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
using Word = Microsoft.Office.Interop.Word;

namespace TheaterNyreack.Windows
{
    /// <summary>
    /// Логика взаимодействия для ShowListActor.xaml
    /// </summary>
    public partial class ShowListActor : Window
    {
        User currentUser;
        Show currentShow;

        public ShowListActor(Show currentShow, User currentUser)
        {
            InitializeComponent();
            this.currentUser = currentUser;
            this.currentShow = currentShow;
        }

        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {
            FillListView();
        }

        private void issueAcContractButton_Click(object sender, RoutedEventArgs e)
        {
            if (showListViewActor.SelectedItem != null)
            {
                Contract newContract = new Contract();


                User user = ((ActorControl)showListViewActor.SelectedItem).currentUser;

                newContract.ContractStatusId = 1;
                newContract.ContractActorId = user.UserId;
                newContract.ContractDirectorId = currentUser.UserId;
                newContract.ContractShowId = currentShow.ShowId;
                newContract.ContractFee = currentShow.ShowBudget / 2;


                Word.Application wordApp = new Word.Application();
                wordApp.Visible = true;
                Object template = Type.Missing;
                Object newTemplate = false;
                Object documentType = Word.WdNewDocumentType.wdNewBlankDocument;
                Object visible = true;
                object missing = Type.Missing;
                Word._Document wordDoc = wordApp.Documents.Add(
                    ref missing, ref missing, ref missing, ref missing);
                object start = 0, end = 0;

                // создаем диапазон, в котором будем выводить информацию
                Word.Range range = wordDoc.Range(ref start, ref end);
                range.Text = $"Башкирский Театр Драмы\n".ToUpper();
                range.Text = $"Заказ № {TheaterNyreckContext.DbContext.Contracts.Count() + 1}\n".ToUpper();
                // формат диапазона
                range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                range.ParagraphFormat.SpaceAfter = 0;
                range.Font.Name = "Times New Roman";

                range.Font.Size = 14;

                start = wordDoc.Range().End - 1; end = wordDoc.Range().End - 1;
                range = wordDoc.Range(ref start, ref end);

                range.Text = $"Номер спектакля: {newContract.ContractShowId}\n";
                range.Text += $"Дата начала спектакля: {newContract.ContractShow.ShowData}\n";
                range.Text += $"Контракт заключен на актера: {newContract.ContractActor.UserName} {newContract.ContractActor.UserSurname} {newContract.ContractActor.UserPatronimyc}\n";
                range.Text += $"Гонорар: {newContract.ContractFee} руб.\n";
                range.Text += $"Контракт был оформлен директор: {newContract.ContractDirector.UserName} {newContract.ContractDirector.UserSurname} {newContract.ContractDirector.UserPatronimyc}\n";

                range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphRight;
                range.ParagraphFormat.SpaceAfter = 0;
                range.Font.Name = "Times New Roman";

                range.Font.Size = 14;

                range.Text += $"Подпись Актера: _______\n";
                range.Text += $"Подпись Директора: _______";

                TheaterNyreckContext.DbContext.Contracts.Add(newContract);
                TheaterNyreckContext.DbContext.SaveChanges();
                Close();
            }
            else
            {
                MessageBox.Show("Вы не выбрали актера", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void FillListView()
        {
            showListViewActor.Items.Clear();

            List<User> listUsers = TheaterNyreckContext.DbContext.Users.ToList();

            if (currentUser.UserRoleId == 2)
            {
                listUsers = listUsers.Where(w => w.UserRoleId == 3).ToList();
            }

            if(!string.IsNullOrWhiteSpace(findTextBox.Text))
            {
                listUsers = listUsers.Where(f => f.UserName.ToLower().Contains(findTextBox.Text.ToLower()) || f.UserPatronimyc.ToLower().Contains(findTextBox.Text.ToLower()) 
                || f.UserSurname.ToLower().Contains(findTextBox.Text.ToLower())).ToList();
            }

            foreach (User user in listUsers)
            {
                showListViewActor.Items.Add(new ActorControl(user)
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
