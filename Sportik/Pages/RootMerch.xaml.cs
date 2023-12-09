using Sportik.Classes;
using Sportik.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity.Infrastructure;
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
using System.Data.Entity;

namespace Sportik.Pages
{
    /// <summary>
    /// Логика взаимодействия для RootMerch.xaml
    /// </summary>
    public partial class RootMerch : Page
    {
        private ObservableCollection<merch> merchCollection;
        public RootMerch()
        {
            InitializeComponent();
            merchCollection = new ObservableCollection<merch>(UchebnayaEntities.GetContext().merch.ToList());
            MerchBD.ItemsSource = merchCollection;
        }

        private void Add(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new EditMerch(null));
        }

        private void Edit(object sender, RoutedEventArgs e)
        {
            try
            {
                Manager.MainFrame.Navigate(new EditMerch((sender as Button).DataContext as merch));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при редактировании: " + ex.Message);
            }
        }

        private void Delete(object sender, RoutedEventArgs e)
        {
            
        }

        private void Orders(object sender, RoutedEventArgs e)
        {
            OrdersWindow ordersWindow = new OrdersWindow();
            this.Visibility = Visibility.Hidden;
            ordersWindow.Show();
        }

        private void RefreshPage()
        {
            merchCollection.Clear();
            foreach (var merch in UchebnayaEntities.GetContext().merch.ToList())
            {
                merchCollection.Add(merch);
            }
        }

        private void Ref(object sender, RoutedEventArgs e)
        {
            RefreshPage();
        }

        private void History(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new HistoryPage());
        }
    }
}
