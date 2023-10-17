using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace TimeApplication
{
    public partial class SemesterData : Window
    {
        // Declare an instance of the Validation class for input validation
        public Validation v = new Validation();

        // Declare a list of Module objects to store module data
        public List<Module> mList = new List<Module>();

        // Declare an instance of the Menu class
        Menu menu = new Menu();

        // Constructor that takes a list of Module objects as a parameter
        public SemesterData(List<Module> mList)
        {
            InitializeComponent();

            // Initialize the local mList with the parameter passed to the constructor
            this.mList = mList;
        }

        // Event handler for the Enter button click
        private void EnterButton(object sender, RoutedEventArgs e)
        {
            string errorMessage = "";
            DateTime date;

            // Validate and receive the number of weeks left input
            bool validInput = v.TryReceiveNumber(weeksLeft.Text, out errorMessage);
            weeksError.Text = errorMessage;
            weeksError.Visibility = Visibility.Visible;

            // Validate and receive the start date input
            bool validDate = v.TryDate(startDate.Text, out errorMessage, out date);
            dateError.Text = errorMessage;
            dateError.Visibility = Visibility.Visible;

            if (validInput && validDate)
            {
                // Create an instance of the Semester class, passing module data, weeks left, and start date
                Semester s = new Semester(mList, int.Parse(weeksLeft.Text), date);

                // Hide the current window
                this.Hide();

                // Create an instance of the Menu class and pass the Semester object
                menu = new Menu(s);

                // Show the Menu window
                menu.Show();
            }
        }
    }
}
