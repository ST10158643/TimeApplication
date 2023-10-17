using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters;
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
    /// Interaction logic for Menu.xaml
    /// </summary>
    public partial class Menu : Window
    {
        Semester semester; // Declare a variable 'semester' of type 'Semester'

        public Menu()
        {
            InitializeComponent();
            semester = GetInitialSem(); // Call 'GetInitialSem' method to initialize the 'semester' variable
        }

        private Semester GetInitialSem()
        {
            // Create and return a new instance of 'Semester' which is initially empty
            // This method is used to set the 'semester' variable to a new empty 'Semester'
            return new Semester();
        }

        public Menu(Semester sem)
        {
            InitializeComponent();
            semester = sem; // Initialize 'semester' with the provided 'sem' object
            sem.DetermineRemain(); // Call a method on the 'sem' object
        }

        /*must make a way to add on to the module list in sem or */

        private void createMod_BTN_Click(object sender, RoutedEventArgs e)
        {
            if (this.semester.moduleList.Count > 0)
            {
                // Create a new 'CreateModules' window, passing the 'semester' object
                CreateModules createModules = new CreateModules(semester);

                this.Hide(); // Hide the current window
                createModules.Show(); // Show the 'createModules' window
            }
            else
            {
                // Create a new 'CreateModules' window without passing 'semester'
                CreateModules createModules = new CreateModules();

                this.Hide(); // Hide the current window
                createModules.Show(); // Show the 'createModules' window
            }
        }

        private void viewMod_BTN_Click(object sender, RoutedEventArgs e)
        {
            // Create a new 'ShowList' window, passing the 'semester' object
            ShowList sList = new ShowList(semester);

            this.Hide(); // Hide the current window
            sList.Show(); // Show the 'sList' window
        }

        private void recordHrs_BTN_Click(object sender, RoutedEventArgs e)
        {
            // Create a new 'RecordHours' window, passing the 'semester' object
            RecordHours rHrs = new RecordHours(semester);

            this.Hide(); // Hide the current window
            rHrs.Show(); // Show the 'rHrs' window
        }

        private void weeksHrs_BTN_Click(object sender, RoutedEventArgs e)
        {
            // Create a new 'CurrentHours' window, passing the 'semester' object
            CurrentHours cHrs = new CurrentHours(semester);

            this.Hide(); // Hide the current window
            cHrs.Show(); // Show the 'cHrs' window
        }
    }
}
