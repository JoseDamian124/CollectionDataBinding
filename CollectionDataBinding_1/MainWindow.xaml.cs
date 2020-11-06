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
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Configuration;
using ChangeNotificationSample;

namespace CollectionDataBinding_1
{

    public partial class MainWindow : Window
    {
        private ObservableCollection<User> users;

        public MainWindow()
        {
            InitializeComponent();
            users = new ObservableCollection<User>();
            agregaruser();
            DataContext = users;
                    
        }
        private void agregaruser()
        {
            users = new ObservableCollection<User>();
            users.Add(new User() { Name = "Jose Francisco Fernandez Damian" });
            //lista.ItemsSource = users;
           
        }

        private void agregarButton_Click(object sender, RoutedEventArgs e)
        {
            if(!string.IsNullOrEmpty(userTextBox.Text))
            {
                User user = new User() { Name = "Nuevo usuario" };
                users.Add(user);
                lista.SelectedItem = user;
                UpdateView();
            }
        }

        private void modificarButton_Click(object sender, RoutedEventArgs e)
        {
            if (lista.SelectedItem != null)
            {
                User user = lista.SelectedItem as User;
                user.Name = userTextBox.Text;
                lista.SelectedItem = user;
                UpdateView();
            }
        }

        private void eliminarButton_Click(object sender, RoutedEventArgs e)
        {
           if(lista.SelectedItem != null)
            {
                users.Remove(lista.SelectedItem as User);
                UpdateView();
            }
        }
        private void UpdateView()
        {
            lista.Items.Refresh();
            if(users.Count > 0)
            {
                eliminarButton.IsEnabled = false;
                modificarButton.IsEnabled = false;

            }
            else
            {
                eliminarButton.IsEnabled = false;
                modificarButton.IsEnabled = false;
                lista.SelectedIndex = -1;
            }
        }

        private void lista_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(lista.SelectedItem != null)
            {
                userTextBox.Text = (lista.SelectedItem as User).Name;
            }
        }
    }
}
