using System.Collections.Generic;
using System.Windows;

namespace TimeApplication
{
    /// <summary>
    /// Interaction logic for CreateModules.xaml
    /// </summary>
    public partial class CreateModules : Window
    {
        // Declare instance variables
        string nameErrorMessage, codeErrorMessage, creditErrorMessage, hrsErrorMessage;

        // Instantiate objects and initialize variables
        public Validation v = new Validation(); // Validation object
        public Module mod = new Module(); // Module object
        public List<Module> moduleList = new List<Module>(); // List to store modules
        public bool skip = false; // Boolean flag
        private Menu menu = new Menu(); // Menu object
        public Semester sem = new Semester(); // Semester object

        // Constructor without parameters
        public CreateModules()
        {
            InitializeComponent();
        }

        // Constructor with a Semester parameter
        public CreateModules(Semester sem)
        {
            InitializeComponent();
            this.sem = sem;
            this.moduleList = sem.moduleList;
        }
       
        // Event handler for nextButton_Click event
        private void nextButton_Click(object sender, RoutedEventArgs e)
        {
            if (skip)
            {
                // Create a new SemesterData instance with moduleList
                SemesterData sem = new SemesterData(moduleList);
                this.Hide();
                sem.Show();
            }
            else
            {
                // Set self-study and show the Menu
                sem.SetSelfStudy();
                this.Hide();
                menu = new Menu(sem);
                menu.Show();
            }
        }

        // Event handler for submitButton_Click event
        private void submitButton_Click(object sender, RoutedEventArgs e)
        {
            Reset1(); // Call Reset1 method to hide error messages and reset some elements
            bool validName = v.TryReceiveString(modName.Text, out nameErrorMessage);
            nameError.Text = nameErrorMessage;
            nameError.Visibility = Visibility.Visible;
            bool validCode = v.TryReceiveModuleCode(modCode.Text, out codeErrorMessage);
            codeError.Text = codeErrorMessage;
            codeError.Visibility = Visibility.Visible;
            bool validCredits = v.TryReceiveNumber(modCredits.Text, out creditErrorMessage);
            creditError.Text = creditErrorMessage;
            creditError.Visibility = Visibility.Visible;
            bool validHrs = v.TryReceiveNumber(modClassHrs.Text, out hrsErrorMessage);
            hoursError.Text = hrsErrorMessage;
            hoursError.Visibility = Visibility.Visible;

            if (validName && validCode && validCredits && validHrs)
            {
                // Add a new module to moduleList
                moduleList.Add(new Module { ModuleName = modName.Text, ModuleCode = modCode.Text, ModuleCredits = int.Parse(modCredits.Text), ModuleHrs = int.Parse(modClassHrs.Text) });
                saveMsg.Text = modCode.Text + " Created";
                saveMsg.Visibility = Visibility.Visible;
                nextButton.IsEnabled = true;
                Reset(); // Call Reset method to clear textboxes and hide error messages
            }
        }

        // Reset method to hide error messages and clear textboxes
        public void Reset()
        {
            modName.Clear();
            modCode.Clear();
            modCredits.Clear();
            modClassHrs.Clear();
            nameError.Visibility = Visibility.Hidden;
            codeError.Visibility = Visibility.Hidden;
            creditError.Visibility = Visibility.Hidden;
            hoursError.Visibility = Visibility.Hidden;
        }

        // Reset1 method to hide error messages
        public void Reset1()
        {
            nameError.Visibility = Visibility.Hidden;
            saveMsg.Visibility = Visibility.Hidden;
            codeError.Visibility = Visibility.Hidden;
            creditError.Visibility = Visibility.Hidden;
            hoursError.Visibility = Visibility.Hidden;
        }
    }
}
