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

namespace PetShop.Pages
{
    /// <summary>
    /// Логика взаимодействия для AuthPage.xaml
    /// </summary>
    public partial class AuthPage : Page
    {
        public AuthPage()
        {
            InitializeComponent();
            LoginTextBox.Text = "pixil59@gmail.com"; //УБРАТЬ
            PasswordBox.Password = "2L6KZG"; //УБРАТЬ
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                StringBuilder errors = new StringBuilder();
                string login = LoginTextBox.Text;
                string password = PasswordBox.Password;
                if (string.IsNullOrEmpty(login))
                {
                    errors.AppendLine("Заполните логин");
                }
                if (string.IsNullOrEmpty(password))
                {
                    errors.AppendLine("Заполните пароль");
                }
                if (errors.Length > 0)
                {
                    MessageBox.Show(errors.ToString(), "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                if (Model.TradeEntities.GetContext().User.Where(d => d.UserLogin == login && d.UserPassword == password).Any())
                {
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
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void GuestButton_Click(object sender, RoutedEventArgs e)
        {
            Classes.Navigation.ActiveFrame.Navigate(new Pages.GuestPage(null));
        }
    }
}
