# Time Study WPF App 

## Overview

TimeApplication is a Windows Presentation Foundation (WPF) Console App developed on the .NET framework 4.8.

The Study Tracker Application is a user-friendly tool designed to assist students in creating and effectively managing their academic modules for the semester. With this application, students can effortlessly input the details of their current semester's modules, empowering the application to provide guidance on optimizing their study routines.

The Study Tracker Application was conceived as a project for the PROGRAMMING 2B course POE Submission, aiming to serve as a valuable tool for enhancing the learning experience throughout the semester. 

## Installation
The application is a Console App operating on .NET framework 4.8 and this can 
run on Visual Studio 2019, Visual Studio 2022 and the Microsoft .NET Framework 4.8.

To install the application, follow these steps:

1. Download the ZIP file from the project repository.
2. Unzip the file to a directory of your choice.
3. Open the "Hannah_Ruth_Michaelson__ST10158643_PROG_6212_Part_2.sln" file with VisualStudio.
4. Build the solution by pressing F6 or selecting "Build Solution" from the "Build" menu.
5. Run the application by pressing F5 or selecting "Start Debugging" from the "Debug" menu.


## UML
![image](https://github.com/user-attachments/assets/3aaa2cd1-e38c-4fb3-b1ff-9c58b17b4282)


## Usage

The Study Tracker application is designed to assist you in effectively managing your semester by tracking module information and study hours. Follow these step-by-step instructions to make the most out of the application:

### Adding Modules

1. Launching the Application:
   - Begin by launching the Study Tracker application, following the installation guidelines provided in the "Installation" section.

2. Creating Modules for the Semester:
   - Navigate to the Study Tracker app menu and select "Create Module" to add modules for your current semester.

3.Number of Weeks in the Semester: Enter the total number of weeks in the semester.
Start Date for the First Week: Choose the start date for the first week of the semester.
Entering Module Information:
- Within the "Create Module" window, provide the following details for each module:
- Module Code:** Enter a unique code for the module (e.g., PROG6212).
- Module Name:** Supply a descriptive name for the module (e.g., Programming 2B).
 - Number of Credits:** Specify the credit value for the module (e.g., 15).
  - Class Hours per Week:** Indicate the number of hours of in-class instruction per week (e.g., 5).

4. Saving Module Information:
   - Once you've filled in the module details, click the "Save" button to store the module information.

### Tracking Study Hours

5. Viewing Module Information:
   - The application automatically calculates and displays the number of self-study hours required for each module per week based on the provided data. To access this information, select the "View Modules" button from the Menu. This feature assists you in planning your study schedule effectively.

6. Recording Study Hours:
   - To record the number of hours spent studying a specific module on a particular date, access the "Update Study Hours" option from the menu. Follow these steps:
     - Navigate to the module you wish to update.
     - Select the date and input the hours devoted to studying.
     - Click "Save" to record your study hours.

### Monitoring Progress

7. Monitoring Remaining Self-Study Hours:
   - The software continuously updates and displays the remaining self-study hours for each module for the current week. You can access this information by selecting "Studied Hours" from the user menu. The calculation takes into account the hours recorded on specific dates to provide an accurate overview of your progress.

### Application Behavior

8. Data Storage:
-  The application's data persistence is facilitated through a SQL database. All user-related information, such as usernames and their corresponding hashed passwords, is securely stored in the designated SQL database.

9. User Registration and Password Management:
-   Users have the capability to register within the application using a unique username and password. The software follows a secure approach by only storing the hash of the user's password in the SQL database. This ensures that sensitive information is not stored in plain text, thereby enhancing the security of user credentials..
10. Exiting the Application:
-   Users have the flexibility to perform various actions within the application and subsequently exit as needed. The software provides a smooth exit process, allowing users to securely log out and terminate their session or exit the application altogether.



## References
Mohanty, A. (no date) How to convert WORDS TO NUMBERS IN C#, C# Corner. C# Corner. Available at: https://www.c-sharpcorner.com/blogs/convert-words-to-numbers-in-c-sharp (Accessed: September 12, 2023). Tirabassi, J. (2022) Why double.tryparse("0.0000", out doublevalue) returns false ?, CopyProgramming. CopyProgramming. Available at: https://copyprogramming.com/howto/why-double-tryparse-0-0000-out-doublevalue-returns-false (Accessed: September 12, 2023).Tirabassi, J. (2022) Why double.tryparse("0.0000", out doublevalue) returns false ?, CopyProgramming. CopyProgramming. Available at: https://copyprogramming.com/howto/why-double-tryparse-0-0000-out-doublevalue-returns-false (Accessed: September 20, 2023). 
Troelsen, A. and Japikse, P. (2021) Pro C# 9 with . NET 5: Foundational principles and practices in programming. Berkeley, CA: Apress L. 
Wagner, B. (no date) .Net documentation, Microsoft Learn. Microsoft Learn. Available at: https://learn.microsoft.com/en-us/dotnet/?view=netframework-4.8 (Accessed: September 15, 2023). OpenAI. (2021) ChatGPT (GPT-3.5). [Computer program]. Available at: https://openai.com (Accessed: September 20, 2023).
Microsoft , E.T. (2023) List.sort method (system.collections.generic), List.Sort Method (System.Collections.Generic) | Microsoft Learn. Available at: https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1.sort?view=net-7.0 (Accessed: September 12, 2023). 
Microsoft , L. (2023) Keyvaluepair struct (system.collections.Generic), KeyValuePair Struct (System.Collections.Generic) | Microsoft Learn. Available at: https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.keyvaluepair-2?view=net-7.0 (Accessed: September 15, 2023).(No date) CANVA: Visual suite for everyone. Available at: https://www.canva.com/ (Accessed: 22 September 2023). 
## License
The MIT License (MIT)

Copyright (c) 2023 Hannah Michaelson

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE


### SQL script to Create TimeAppDB Table
User Table 
CREATE TABLE [dbo].[User] (
    [Id]     INT            IDENTITY (1001, 101) NOT NULL,
    [F_NAME] NVARCHAR (MAX) NOT NULL,
    [S_NAME] NVARCHAR (MAX) NOT NULL,
    [EMAIL]  NVARCHAR (MAX) NOT NULL,
    [P_WORD] NVARCHAR (MAX) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);
Module Table 
CREATE TABLE [dbo].[MODULE] (
    [ModID]     INT            IDENTITY (1001, 101) NOT NULL,
    [UserID]    INT            NOT NULL,
    [ModName]   NVARCHAR (MAX) NOT NULL,
    [ModCode]   NVARCHAR (MAX) NOT NULL,
    [Credits]   INT            NOT NULL,
    [ClassHrs]  INT            NOT NULL,
    [ExpHrs]    INT            NOT NULL,
    [WorkedHrs] INT            NULL,
    PRIMARY KEY CLUSTERED ([ModID] ASC),
    CONSTRAINT [FK_User_Module] FOREIGN KEY ([UserID]) REFERENCES [dbo].[User] ([Id])
);
ST_Semster Table 
CREATE TABLE [dbo].[ST_SEMESTER] (
    [SemID]      INT  IDENTITY (1001, 101) NOT NULL,
    [ST_UserID]  INT  NOT NULL,
    [StartDate]  DATE NOT NULL,
    [WeeksLeft]  INT  NOT NULL,
    [TotalWeeks] INT  NOT NULL,
    PRIMARY KEY CLUSTERED ([SemID] ASC),
    CONSTRAINT [FK_User_Semester] FOREIGN KEY ([ST_UserID]) REFERENCES [dbo].[User] ([Id])
);


Study_Tracker Table 
CREATE TABLE [dbo].[STUDY_TRACKER] (
    [StudyTrackerID] INT IDENTITY (1001, 101) NOT NULL,
    [ModID]          INT NOT NULL,
    [CurWeek]        INT NOT NULL,
    [HoursWorked]    INT NOT NULL,
    [RemainHours]    INT NOT NULL,
    PRIMARY KEY CLUSTERED ([StudyTrackerID] ASC),
    CONSTRAINT [FK_Module_StudyTracker] FOREIGN KEY ([ModID]) REFERENCES [dbo].[MODULE] ([ModID])
);



Change log file 
  User Authentication:
Upon registration, users can log into the software using their previously set username and password. The authentication process involves verifying the hashed password against the stored hash in the database, granting access only if the credentials match.
 User Data Isolation:
-	The software is designed to maintain strict data isolation. Each user can only access and view their individual data. This architecture ensures that users are restricted from viewing any information belonging to other users, upholding data privacy and security.
Data Retention:
-	It's essential to highlight that the software does not retain user data between application runs. While the application is active, the information is stored in the SQL database. However, upon exiting the application, no user-specific data is persistently stored, ensuring user privacy and data security.




