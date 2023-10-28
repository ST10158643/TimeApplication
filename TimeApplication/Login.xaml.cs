using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
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
using System.Xml.Linq;

namespace TimeApplication
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        string hpWord;
        public Login()
        {
            InitializeComponent();
        }

        private void submitButton_Click(object sender, RoutedEventArgs e)
        {
            // Validation: Check if the required fields are filled
            if (string.IsNullOrWhiteSpace(email.Text) || string.IsNullOrWhiteSpace(passWord.Text))
            {

                saveMsg.Foreground = Brushes.Red;
                saveMsg.Text = "Please fill in all the required fields.";
                return;
            }
            hpWord = HashPassword(returnBytes(passWord.Text));
            bool user = PullData();
            if (user)
            {
                // Create an instance of the Menu class, passing the Semester object
                Menu menu = new Menu();

                // Hide the current window and show the Menu window
                this.Hide();
                menu.Show();
            }
            else
            {
                saveMsg.Text = "What are you trying here? You ain't the one\nFailed to insert student data.";
            }
        }
        public static string HashPassword(byte[] passwordArray)
        {
            string password;
            StringBuilder stringBuilder = new StringBuilder();
            foreach (byte b in passwordArray)
            {

                stringBuilder.Append(b.ToString("X3"));
            }
            password = stringBuilder.ToString();
            return password;
        }
        public static byte[] returnBytes(string password)
        {
            // Create an instance of the SHA-256 hashing algorithm.
            using (HashAlgorithm algorithm = SHA256.Create())
            {
                // Convert the plaintext password into a byte array using UTF-8 encoding.
                byte[] passwordBytes = Encoding.UTF8.GetBytes(password);

                // Compute the hash of the password bytes.
                byte[] hashBytes = algorithm.ComputeHash(passwordBytes);

                // Return the resulting hash as a byte array.
                return hashBytes;
            }
        }
        public bool PullData()
        {

            string e_Mail = email.Text;
            string p_word = hpWord;
            bool loggedIn = false;

            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\User\\source\\repos\\TimeApplication\\TimeApplication\\TimeAppDB.mdf;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string selectQuery = "SELECT * FROM [User] WHERE EMAIL = @EMAIL";

                using (SqlCommand command = new SqlCommand(selectQuery, connection))
                {

                    command.Parameters.AddWithValue("@EMAIL", e_Mail);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read()) // Check if the email exists in the database.
                        {
                            string dbPassword = reader["P_WORD"].ToString();

                            if (p_word == dbPassword) // Check if the entered password matches the stored hashed password.
                            {
                                loggedIn = true;
                            }
                            
                        }
                        connection.Close();
                    }

                }
            }
            return loggedIn;
        }

        private void loginButton_Click(object sender, RoutedEventArgs e)
        {
            // Create an instance of the Menu class, passing the Semester object
            Login login = new Login();

            // Hide the current window and show the Menu window
            this.Hide();
            login.Show();
        }
    }
}
