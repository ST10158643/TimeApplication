using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Windows;
using StudyDLL; // Import a custom DLL named "StudyDLL"

namespace TimeApplication
{
    public class Semester
    {
        // VARIABLES
        public int weeksLeft; // Number of weeks left in the semester
        public DateTime startDate; // Start date of the semester
        public List<(DateTime WeekStart, DateTime WeekEnd)> weekSpan = new List<(DateTime WeekStart, DateTime WeekEnd)>(); // List to store weekly periods
        public List<Module> moduleList = new List<Module>(); // List to store modules

        // DLL
        StudyD dLL = new StudyD(); // Create an instance of the StudyD class from the StudyDLL

        // CONSTRUCTORS
        public Semester() { } // Default constructor
        public Semester(List<Module> modules, int weeks, DateTime date)
        {
            // Parameterized constructor
            this.moduleList = modules; // Initialize the moduleList with the provided modules
            this.weeksLeft = weeks; // Initialize weeksLeft with the provided weeks
            this.startDate = date; // Initialize startDate with the provided date
            SetSelfStudy(); // Calculate and set self-study hours for modules
            StudyWeeks(); // Calculate and set the weekly periods
        }

        // Method to Set Remaining Hours for All Modules, according to the day and therefore week
        public void SetRemainingHours(DateTime day)
        {
           
            int week = FindWeek(day);            

            // Loop through all modules to calculate remaining hours
            for (int i = 0; i < moduleList.Count; i++)
            {
                if (moduleList[i].studyTrack.ContainsKey(week))
                {
                    // Calculate and assign remaining hours for each module
                    this.moduleList[i].actualStudyHrs = dLL.RemainderCalculator(moduleList[i].ExeStudyHrs, moduleList[i].studyTrack.ContainsKey(week), moduleList[i].studyTrack[week]);
                }
                else
                {
                    MessageBox.Show("Invalid date format,Please enter a valid date.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
       
        // Method to return Remaining Hours according to the week (record page)
        public string 
        RemainingHours(DateTime day, int module)
        {
            int week = FindWeek(day) + 1;
            string mess = "Week " + week + ": " + this.moduleList[module].actualStudyHrs + " Study Hours Left";
            return mess;
        }

        // Method to set expected self-study hours for all modules
        public void SetSelfStudy()
        {
            for (int i = 0; i < moduleList.Count; i++)
            {
                this.moduleList[i].expectedStudyHrs = dLL.StudyCalculator(this.moduleList[i].ModuleCredits, this.moduleList[i].ModuleHrs, SemWeeks);
            }
        }

        // Private method to find the week for a given date
        private int FindWeek(DateTime date)
        {
            for (int week = 0; week < weeksLeft; week++)
            {
                if (date >= weekSpan[week].WeekStart && date <= weekSpan[week].WeekEnd)
                {
                    return week;
                }
            }
            // Return -1 if the current date is not within any week
            return -1;
        }

        // Method to determine remaining hours for modules
        public void DetermineRemain()
        {
            DateTime day = DateTime.Now;
            int week = FindWeek(day);

            // Loop through all modules
            for (int i = 0; i < moduleList.Count; i++)
            {
                // If the module's study tracker does not contain the current week
                if (!this.moduleList[i].studyTrack.ContainsKey(week))
                {
                    // Assign module's ExeStudyHrs to actualStudyHrs for the week
                    this.moduleList[i].actualStudyHrs = this.moduleList[i].ExeStudyHrs;
                }
            }
        }

        // Method to save hours studied according to the week, passing week and the module number and hours
        public void SaveHours(DateTime studyDay, int module, int hrsWorked)
        {
            int week = FindWeek(studyDay);

            if (this.moduleList[module].studyTrack.ContainsKey(week))
            {
                this.moduleList[module].studyTrack[week] += hrsWorked;
            }
            else
            {
                // Adding module week's studied hours (populate dictionary)
                moduleList[module].StudyTracker(week, hrsWorked);
            }

            // Set module remaining hours
            SetRemainingHours(studyDay);
        }

        // Method to calculate and set the weekly periods
        public List<(DateTime WeekStart, DateTime WeekEnd)> StudyWeeks()
        {
            // Calculate the weekly periods for the remaining weeks in the semester
            DateTime currentDate = startDate;
            for (int week = 0; week < weeksLeft; week++)
            {
                DateTime weekStart = currentDate;
                DateTime weekEnd = currentDate.AddDays(6); // Saturday is the end of the week
                weekSpan.Add((weekStart, weekEnd));

                // Move to the next week
                currentDate = currentDate.AddDays(7);
            }

            return weekSpan; // Return the list of weekly periods
        }

        // GETTERS AND SETTERS
        public List<Module> SemModules { get => moduleList; set => moduleList = value; }
        public int SemWeeks { get => weeksLeft; set => weeksLeft = value; }
        public DateTime SemStart { get => startDate; set => startDate = value; }

        public Module Module
        {
            get => default;
            set{
            }
        }
    }
}
