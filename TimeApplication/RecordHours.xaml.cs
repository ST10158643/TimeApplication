using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
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
    /// Interaction logic for RecordHours.xaml
    /// </summary>
    public partial class RecordHours : Window
    {
        // Declare an instance of the Semester class
        Semester semester = new Semester();

        // Declare variables to store error messages
        string hrsErrorMessage, dateErrorMessage;

        // Create an instance of the Validation class
        public Validation v = new Validation();

        // Constructor for RecordHours, takes a Semester object as a parameter
        public RecordHours(Semester sem)
        {
            InitializeComponent();
            this.semester = sem;

            // Check if the moduleList in the Semester object is not null
            if (semester.moduleList != null)
            {
                // Set the ItemsSource of the modComboBox to the moduleList
                modComboBox.ItemsSource = semester.moduleList;
            }
            else
            {
                // Handle the case where no student data is provided.
                MessageBox.Show("No student data to display.");
            }
        }

        // Event handler for the EnterButton's Click event
        private void EnterButton_Click(object sender, RoutedEventArgs e)
        {
            // Get the index of the selected module in the ComboBox
            int selectedMod = modComboBox.SelectedIndex;
            DateTime d;
            // Validate the input for hours and store the error message
            bool validHours = v.TryReceiveNumber(numHrs.Text, out hrsErrorMessage);
            hoursError.Text = hrsErrorMessage;
            hoursError.Visibility = Visibility.Visible;
            bool validDate = v.TryStudyDate (studyDate.Text, out dateErrorMessage, out d );
            dateError.Text = dateErrorMessage;
            dateError.Visibility = Visibility.Visible;
            // Check if the input for hours is valid
            if (validHours&&validDate)
            {
                // Parse the entered hours as an integer
                int stHrs = int.Parse(numHrs.Text);

                // Call the SaveHours method of the Semester object
                semester.SaveHours(DateTime.Parse(studyDate.Text), selectedMod, stHrs);

                // Display a message indicating that hours are saved
                saveMsg.Text = semester.moduleList[selectedMod].ModuleName + "'s Hours Saved ";
                saveMsg.Visibility = Visibility.Visible;
                remainHrs.Visibility = Visibility.Hidden;  
            }
        }

        // Event handler for the MenuButton's Click event
        private void MenuButton_Click(object sender, RoutedEventArgs e)
        {
            // Create an instance of the Menu class, passing the Semester object
            Menu menu = new Menu(semester);

            // Hide the current window and show the Menu window
            this.Hide();
            menu.Show();
        }

        // Event handler for the studyDate's SelectedDateChanged event
        private void studyDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            DateTime d;
            // Get the index of the selected module in the ComboBox
            int selectedMod = modComboBox.SelectedIndex;

            // Check if a study date is selected
            if (studyDate.Text != "")
            {
                if (v.TryStudyDate(studyDate.Text, out dateErrorMessage, out d))
                {
                    remainHrs.Text = dateErrorMessage;
                    remainHrs.Visibility = Visibility.Visible;
                }
                else
                {
                    // Calculate and display the remaining hours based on the selected date
                    remainHrs.Text = semester.RemainingHours(DateTime.Parse(studyDate.Text), selectedMod);
                    remainHrs.Visibility = Visibility.Visible;
                }
            }

        }

        // Method to reset input fields and hide error messages
        public void Rest()
        {
            numHrs.Text = "";
            studyDate.Text = "";
            hoursError.Visibility = Visibility.Collapsed;
            dateError.Visibility = Visibility.Collapsed;
        }
    }
}
