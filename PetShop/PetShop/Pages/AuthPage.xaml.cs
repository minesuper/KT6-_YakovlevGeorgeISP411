using System;
using System.Collections.Generic;
using System.IO;
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

namespace PetShop.Pages
{
    /// <summary>
    /// Логика взаимодействия для AuthPage.xaml
    /// </summary>
    public partial class AuthPage : Page
    {
        int AuthClickCount = 0;
        string CaptchaAnswer { get; set; }
        public AuthPage()
        {
            InitializeComponent();
        }
        private async void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                StringBuilder errors = new StringBuilder();
                string login = LoginTextBox.Text;
                string password = PasswordBox.Password;
                string CaptchaEntered = CaptchaTextBox.Text;
                if (string.IsNullOrEmpty(login))
                {
                    errors.AppendLine("Заполните логин");
                }
                if (string.IsNullOrEmpty(password))
                {
                    errors.AppendLine("Заполните пароль");
                }
                if (AuthClickCount != 0 && string.IsNullOrEmpty(CaptchaEntered))
                {
                    errors.AppendLine("Решите каптчу");
                }
                else if (AuthClickCount != 0 && CaptchaEntered != CaptchaAnswer)
                {
                    errors.AppendLine("Каптча решена неверно");
                    GenerateCaptcha();
                }
                if (errors.Length > 0)
                {
                    MessageBox.Show(errors.ToString(), "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                if (Model.TradeEntities.GetContext().User.Where(d => d.UserLogin == login && d.UserPassword == password).Any())
                {
                    AuthClickCount = 0;
                    var user = Model.TradeEntities.GetContext().User
                        .Where(d => d.UserLogin == login && d.UserPassword == password).FirstOrDefault();
                    switch (user.Role.RoleName)
                    {
                        case "Администратор":
                            Classes.Navigation.ActiveFrame.Navigate(new Pages.ProductsPage(user));
                            break;
                        case "Клиент":
                            Classes.Navigation.ActiveFrame.Navigate(new Pages.GuestPage(user));
                            break;
                        case "Менеджер":
                            Classes.Navigation.ActiveFrame.Navigate(new Pages.GuestPage(user));
                            break;
                    }
                }
                else
                {
                    MessageBox.Show("Неправильный логин/пароль", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                    AuthClickCount++;
                    if (AuthClickCount > 1)
                    {
                        LoginButton.IsEnabled = false;
                        await Task.Delay(10000);
                        LoginButton.IsEnabled = true;
                    }
                    GenerateCaptcha();
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void GenerateCaptcha()
        {
            CaptchaTextBox.Text = "";
            CaptchaTextBox.Visibility = Visibility.Visible;
            CaptchaLabel.Visibility = Visibility.Visible;
            RegenerateCaptcha.Visibility = Visibility.Visible;
            CaptchaImage527K.Visibility = Visibility.Collapsed;
            CaptchaImageD3OL.Visibility = Visibility.Collapsed;
            CaptchaImageG7pt.Visibility = Visibility.Collapsed;
            Random rand = new Random();
            int CaptchaIndex = rand.Next(0, 3);
            string newCaptchaAnswer = "";
            switch (CaptchaIndex)
            {
                case 0:
                    CaptchaImage527K.Visibility = Visibility.Visible;
                    newCaptchaAnswer = "527K";
                    break;
                case 1:
                    CaptchaImageD3OL.Visibility = Visibility.Visible;
                    newCaptchaAnswer = "D3OL";
                    break;
                case 2:
                    CaptchaImageG7pt.Visibility = Visibility.Visible;
                    newCaptchaAnswer = "G7pt";
                    break;
            }
            if (newCaptchaAnswer == CaptchaAnswer)
            {
                GenerateCaptcha();
            }
            else
            {
                CaptchaAnswer = newCaptchaAnswer;
            }
        }

        private void GuestButton_Click(object sender, RoutedEventArgs e)
        {
            Classes.Navigation.ActiveFrame.Navigate(new Pages.GuestPage(null));
        }

        private void RegenerateCaptcha_Click(object sender, RoutedEventArgs e)
        {
            GenerateCaptcha();
        }
    }
}
