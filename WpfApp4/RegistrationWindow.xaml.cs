using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApp4
{

    public partial class RegistrationWindow : Window
    {
        private ApplicationContext appc;
        public string ViewModel { get; set; }

        public RegistrationWindow()
        {
            InitializeComponent();
            appc = new ApplicationContext();
        }

        public void ShowViewModel()
        {
            MessageBox.Show(ViewModel);
        }

        private void Create_one(object sender, RoutedEventArgs e)
        {
            checkNames();
            checkEmail();
            checkPassword();
        }

        private void Create(object sender, RoutedEventArgs e)
        {
            if (checkEmail() && checkNames() && checkPassword())
            {
                var user = new User
                {
                    name = NameTxtBox.Text,
                    Fname = SurNameTxtBox.Text,
                    Email = EmailTxtBox.Text,
                    adress = AdressTxtBox.Text,
                    Password = PassworddTxtBox.Password,
                    PhoneNumber = PNTxtBox.Text,

                };
                appc.users.Add(user);
                appc.SaveChanges();
            }

        }
        private bool checkNames()
        {
            if (string.IsNullOrWhiteSpace(NameTxtBox.Text) && string.IsNullOrWhiteSpace(SurNameTxtBox.Text))
            {
                SnackBarRegister.MessageQueue.Enqueue("Please fill name's field");
                return false;
            }
            return true;
        }

        private bool checkEmail()
        {
            try
            {
                var mail = new MailAddress(EmailTxtBox.Text);
                return true;
            }
            catch (ArgumentException)
            {
                SnackBarRegister.MessageQueue.Enqueue("Please insert email");
                return false;
            }
            catch (FormatException)
            {
                SnackBarRegister.MessageQueue.Enqueue("Please insert correct email");
                return false;
            }
        }

        private bool checkPassword()
        {
            if (PassworddTxtBox.Password.Length > 4)
            {
                return true;
            }
            SnackBarRegister.MessageQueue.Enqueue("Invalid password, should contain more than 4");
            return false;
        }

        private void PNTxtBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
