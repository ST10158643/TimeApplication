using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace TimeApplication
{
    public class Module
    {
        // VARIABLES

        // Variables to store module-related information
        public string modCode;
        public string modName;
        public int modCredits;
        public int classHrs;

        // Variables to track study hours
        public int expectedStudyHrs = 0;
        public int actualStudyHrs = 0;

        // Dictionary to track study hours per week (week -> actual study hours)
        public Dictionary<int, int> studyTrack = new Dictionary<int, int>();


        // Default constructor
        public Module() { }

        // Parameterized constructor to initialize module properties
        public Module(string code, string name, int credits, int classHours)
        {
            this.modCode = code;
            this.modName = name;
            this.modCredits = credits;
            this.classHrs = classHours;
        }

       

        // Method to track study hours for a specific week
        public void StudyTracker(int week, int actualHrs)
        {
            // Add the week and actual study hours to the studyTrack dictionary
            studyTrack.Add(week, actualHrs);

            // Assign the value of actualHrs to the actualStudyHrs property
            // Note: This line seems to be intended to update the actualStudyHrs property,
            // but it's currently assigning actualHrs to itself, which may not be the desired behavior.
            actualHrs = actualStudyHrs;
        }

        
        // Getter and setter properties for module-related information
        public string ModuleCode { get => modCode; set => modCode = value; }
        public string ModuleName { get => modName; set => modName = value; }
        public int ModuleCredits { get => modCredits; set => modCredits = value; }
        public int ModuleHrs { get => classHrs; set => classHrs = value; }

        // Getter and setter properties for expected and actual study hours
        public int ExeStudyHrs { get => expectedStudyHrs; set => expectedStudyHrs = value; }
        public int ActStudyHrs { get => actualStudyHrs; set => actualStudyHrs = value; }
    }
}
