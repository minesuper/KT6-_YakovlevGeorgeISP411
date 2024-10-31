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
    /// Логика взаимодействия для AddEditPage.xaml
    /// </summary>
    public partial class AddEditPage : Page
    {
        bool IsAdding { get; set; }
        Model.Product newProduct { get; set; }
        Model.User selectedUser { get; set; }
        public AddEditPage(Model.Product selectedProduct, Model.User currentUser)
        {
            InitializeComponent();
            OnStart(selectedProduct, currentUser);
        }
        private void OnStart(Model.Product selectedProduct, Model.User currentUser)
        {
            selectedUser = currentUser;
            CategoryComboBox.ItemsSource = Model.TradeEntities.GetContext().ProductCategory.ToList();
            if (selectedProduct == null)
            {
                newProduct = new Model.Product();
                IsAdding = true;
                IdLabel.Visibility = Visibility.Collapsed;
                IdTextBox.Visibility = Visibility.Collapsed;
            }
            else
            {
                newProduct = selectedProduct;
                IsAdding = false;
                IdTextBox.Text = newProduct.ProductId.ToString();
                NameTextBox.Text = newProduct.ProductType.Name;
                CategoryComboBox.SelectedIndex = newProduct.ProductCategoryId - 1;
                CountTextBox.Text = newProduct.ProductQuantityInStock.ToString();
                UnitTextBox.Text = newProduct.Units.Name;
                SupplierTextBox.Text = newProduct.Suppliers.Name;
                PriceTextBox.Text = newProduct.ProductCost.ToString();
                DescriptionTextBox.Text = newProduct.ProductDescription;
                if (newProduct.ProductPhoto != null)
                {
                    //ImageElement.Source = new BitmapImage(); FIX IMAGE
                }
            }
        }

        private void SaveChangesButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                StringBuilder errors = new StringBuilder();
                string Name = NameTextBox.Text;
                int CategoryId = CategoryComboBox.SelectedIndex + 1;
                string Count = CountTextBox.Text;
                string Unit = UnitTextBox.Text;
                string Supplier = SupplierTextBox.Text;
                string Price = PriceTextBox.Text;
                string Description = DescriptionTextBox.Text;
                if (string.IsNullOrEmpty(Name))
                {
                    errors.AppendLine("Заполните название");
                }
                if (CategoryId < 1)
                {
                    errors.AppendLine("Выберите категорию");
                }
                if (string.IsNullOrEmpty(Count))
                {
                    errors.AppendLine("Заполните количество");
                }
                else if (!Int32.TryParse(Count, out var res))
                {
                    errors.AppendLine("Количество - целое неотрицательное число");
                }
                else
                {
                    int CountTemp = Int32.Parse(Count);
                    if (CountTemp < 0)
                    {
                        errors.AppendLine("Количество - целое неотрицательное число");
                    }
                }
                if (string.IsNullOrEmpty(Unit))
                {
                    errors.AppendLine("Заполните ед. измерения");
                }
                if (string.IsNullOrEmpty(Supplier))
                {
                    errors.AppendLine("Заполните поставщика");
                }
                if (string.IsNullOrEmpty(Price))
                {
                    errors.AppendLine("Заполните цену");
                }
                else if (!Decimal.TryParse(Price, out var res))
                {
                    errors.AppendLine("Цена - дробное положительное число с 2мя знаками после запятой (разделитель запятая)");
                }
                else
                {

                    decimal PriceParsed = decimal.Parse(Price);
                    List<string> PriceTemp = decimal.Parse(Price).ToString().Split(',').ToList();
                    if (PriceParsed < 0)
                    {
                        errors.AppendLine("Цена - дробное положительное число с 2мя знаками после запятой (разделитель запятая)");
                    }
                    else if (PriceTemp.Count != 2)
                    {
                        errors.AppendLine("Цена - дробное положительное число с 2мя знаками после запятой (разделитель запятая)");
                    }
                    else if (PriceTemp.Last().Length != 2)
                    {
                        errors.AppendLine("Цена - дробное положительное число с 2мя знаками после запятой (разделитель запятая)");
                    }
                }
                if (string.IsNullOrEmpty(Description))
                {
                    errors.AppendLine("Заполните описание");
                }
                if (errors.Length > 0)
                {
                    MessageBox.Show(errors.ToString(), "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                if (!Model.TradeEntities.GetContext().Units.Where(d => d.Name == Unit).Any())
                {
                    Model.TradeEntities.GetContext().Units.Add(new Model.Units() { Name = Unit });
                    Model.TradeEntities.GetContext().SaveChanges();
                }
                if (!Model.TradeEntities.GetContext().ProductType.Where(d => d.Name == Name).Any())
                {
                    Model.TradeEntities.GetContext().ProductType.Add(new Model.ProductType() { Name = Name });
                    Model.TradeEntities.GetContext().SaveChanges();
                }
                if (!Model.TradeEntities.GetContext().Suppliers.Where(d => d.Name == Supplier).Any())
                {
                    Model.TradeEntities.GetContext().Suppliers.Add(new Model.Suppliers() { Name = Supplier });
                    Model.TradeEntities.GetContext().SaveChanges();
                }
                newProduct.ProductTypeId = Model.TradeEntities.GetContext().ProductType.Where(d => d.Name == Name).FirstOrDefault().Id;
                newProduct.ProductCategoryId = CategoryComboBox.SelectedIndex + 1;
                newProduct.ProductQuantityInStock = Int32.Parse(Count);
                newProduct.ProductUnitId = Model.TradeEntities.GetContext().Units.Where(d => d.Name == Unit).FirstOrDefault().Id;
                newProduct.ProductSupplierId = Model.TradeEntities.GetContext().Suppliers.Where(d => d.Name == Supplier).FirstOrDefault().Id;
                newProduct.ProductCost = Decimal.Parse(Price);
                //IMAGE
                newProduct.ProductDescription = Description;
                if (IsAdding)
                {
                    Model.TradeEntities.GetContext().Product.Add(newProduct);
                    MessageBox.Show("Товар успешно добавлен!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Товар успешно отредактирован!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                Model.TradeEntities.GetContext().SaveChanges();
                Classes.Navigation.ActiveFrame.RemoveBackEntry();
                Classes.Navigation.ActiveFrame.Navigate(new Pages.ProductsPage(selectedUser));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            if (Classes.Navigation.ActiveFrame.CanGoBack)
            {
                Classes.Navigation.ActiveFrame.GoBack();
            }
        }
    }
}
