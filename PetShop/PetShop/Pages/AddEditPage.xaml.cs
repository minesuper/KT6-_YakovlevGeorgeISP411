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
    /// Логика взаимодействия для AddEditPage.xaml
    /// </summary>
    public partial class AddEditPage : Page
    {
        bool IsAdding { get; set; }
        Model.Product newProduct { get; set; }
        public AddEditPage(Model.Product selectedProduct)
        {
            InitializeComponent();
            OnStart(selectedProduct);
        }
        private void OnStart(Model.Product selectedProduct)
        {
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
                    //SET IMAGE
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
                    errors.AppendLine("Заполните название"); //check if new in table
                }
                if (CategoryId < 1)
                {
                    errors.AppendLine("Выберите категорию");
                }
                if (string.IsNullOrEmpty(Count))
                {
                    errors.AppendLine("Заполните количество"); //check if int
                }
                if (string.IsNullOrEmpty(Unit))
                {
                    errors.AppendLine("Заполните ед. измерения"); //check if new in table
                }
                if (string.IsNullOrEmpty(Supplier))
                {
                    errors.AppendLine("Заполните поставщика"); //check if new in table
                }
                if (string.IsNullOrEmpty(Price))
                {
                    errors.AppendLine("Заполните цену"); //check if decimal with 2 after ,
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
                newProduct.ProductTypeId = Model.TradeEntities.GetContext().ProductType.Where(d => d.Name == Name).FirstOrDefault().Id;
                newProduct.ProductQuantityInStock = Int32.Parse(Count);
                newProduct.ProductUnitId = Model.TradeEntities.GetContext().Units.Where(d => d.Name == Unit).FirstOrDefault().Id;
                newProduct.ProductSupplierId = Model.TradeEntities.GetContext().Suppliers.Where(d => d.Name == Name).FirstOrDefault().Id; //Fix???
                newProduct.ProductCost = Decimal.Parse(Price);
                newProduct.ProductDescription = Description;
                Model.TradeEntities.GetContext().SaveChanges();
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
