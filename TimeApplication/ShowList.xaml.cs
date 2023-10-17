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

namespace TimeApplication
{
    /// <summary>
    /// Interaction logic for ShowList.xaml
    /// </summary>
    public partial class ShowList : Window
    {
        // Declare a Semester object and initialize it with a new instance
        Semester semester = new Semester();

        // Constructor for ShowList window, accepts a Semester object as a parameter
        public ShowList(Semester sem)
        {
            InitializeComponent();

            // Assign the parameter 'sem' to the 'semester' variable
            this.semester = sem;

            // Set the data source for 'moduleListView' to the 'moduleList' property of the 'semester' object
            moduleListView.ItemsSource = semester.moduleList;
        }

        // Event handler for the MenuButton click event
        private void MenuButton_Click(object sender, RoutedEventArgs e)
        {
            // Create a new Menu window with the 'semester' object as a parameter
            Menu menu = new Menu(semester);

            // Hide the current ShowList window
            this.Hide();

            // Show the Menu window
            menu.Show();
        }
    }
}
