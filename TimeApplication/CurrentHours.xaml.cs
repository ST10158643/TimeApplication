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
    /// Interaction logic for CurrentHours.xaml
    /// </summary>
    public partial class CurrentHours : Window
    {
        // Declare an instance of the Semester class and instantiate it.
        Semester semester = new Semester();

        // Constructor that takes a Semester object as a parameter.
        public CurrentHours(Semester sem)
        {
            InitializeComponent();

            // Initialize the semester instance with the provided parameter.
            this.semester = sem;

            // Check if the moduleList in the Semester object is not null.
            if (semester.moduleList != null)
            {
                // Populate the modComboBox with module names and hours for each module in the list.
                modComboBox.ItemsSource = semester.moduleList;

                // Populate the weekComboBox with week numbers.
                for (int i = 0; i <= semester.weekSpan.Count; i++)
                {
                    weekComboBox.Items.Add("Week " + (i + 1));
                }
            }
            else
            {
                // Handle the case where no student data is provided.
                MessageBox.Show("No student data to display.");
            }
        }

        // Event handler for the weekComboBox's SelectionChanged event.
        private void weekComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Clear the moduleListView.
            moduleListView.Items.Clear();

            // Get the selected module index and week index from the combo boxes.
            int selectedMod = modComboBox.SelectedIndex;
            int selectedWeek = weekComboBox.SelectedIndex;
            int hrs = 0;

            // Check if the selected module has study hours for the selected week.
            if (semester.moduleList[selectedMod].studyTrack.ContainsKey(selectedWeek))
            {
                // Get the study hours for the selected module and week.
                hrs = semester.moduleList[selectedMod].studyTrack[selectedWeek];
            }

            // Create a ListViewItem with module name and actual study hours information.
            ListViewItem item = new ListViewItem();
            item.Content = new
            {
                ModuleName = semester.moduleList[selectedMod].ModuleName,
                ActStudyHrs = hrs
            };

            // Show or hide a message depending on whether there are study hours for the selected week.
            if (hrs == 0)
            {
                msgHrs.Visibility = Visibility.Visible;
            }
            else
            {
                msgHrs.Visibility = Visibility.Hidden;
            }

            // Add the item to the moduleListView.
            moduleListView.Items.Add(item);
        }

        // Event handler for the MenuButton's Click event.
        private void MenuButton_Click(object sender, RoutedEventArgs e)
        {
            // Create and show a Menu window, passing the semester object to it.
            Menu menu = new Menu(semester);
            this.Hide();
            menu.Show();
        }
    }
}
