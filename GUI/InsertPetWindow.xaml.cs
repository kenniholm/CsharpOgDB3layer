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
using CsharpOgDB3layer;

namespace GUI
{
    /// <summary>
    /// Interaction logic for InsertPetWindow.xaml
    /// </summary>
    public partial class InsertPetWindow : Window
    {
        Controller con;
        public InsertPetWindow(Controller controller)
        {
            InitializeComponent();
            con = controller;
        }

        private void Send_Click(object sender, RoutedEventArgs e)
        {
            string PetName, PetType, PetBreed, PetDOB, PetWeight, OwnerID;
            PetName = PetNameBox.Text;
            PetType = PetTypeBox.Text;
            PetBreed = PetBreedBox.Text;
            PetDOB = PetDOB_Box.Text;
            PetWeight = PetWeightBox.Text;
            OwnerID = OwnerIdBox.Text;
            con.InsertPet(PetName, PetType, PetBreed, PetDOB, PetWeight, OwnerID);

        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();

        }
    }
}
