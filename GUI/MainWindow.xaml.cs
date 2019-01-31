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
using CsharpOgDB3layer;

namespace GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Controller con = new Controller();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void InsertPet_Click(object sender, RoutedEventArgs e)
        {
            InsertPetWindow insert = new InsertPetWindow(con);
            insert.Show();
        }

        private void ShowAllPets_Click(object sender, RoutedEventArgs e)
        {
            ShowAllPetsWindow show = new ShowAllPetsWindow(con);
            show.Show();
        }
    }
}
