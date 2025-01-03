﻿using System;
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

namespace UP2_BaRu_421_MasterPol.Pages
{
    /// <summary>
    /// Логика взаимодействия для PartnersPage.xaml
    /// </summary>
    public partial class PartnersPage : Page
    {
        public PartnersPage()
        {
            // ctrl k c       ctrl k u
            InitializeComponent();
            var context = Entities.GetContext();
            var currentPartners = context.Partners.ToList();
            ListPartners.ItemsSource = currentPartners;
            UpdatePartners();
        }
        private void UpdatePartners()
        {
            //загружаем всех пользователей в список
            var currentUsers = Entities.GetContext().Partners.ToList();
        }
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddPage(null, true));
        }


        private void Realise_Click(object sender, RoutedEventArgs e)
        {

            var selectedItem = ListPartners.SelectedItem as Partners;
            if (selectedItem != null)
            {
                NavigationService.Navigate(new Product(selectedItem));
            }
            else
            {
                MessageBox.Show("Выберите партнера");
            }
        }

        private void Redact_Click(object sender, RoutedEventArgs e)
        {
            Partners partners = ListPartners.SelectedItem as Partners;
            NavigationService?.Navigate(new AddPage(partners, false));
        }
    }
}
