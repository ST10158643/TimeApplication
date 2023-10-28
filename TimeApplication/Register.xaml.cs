using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
using System.Xml.Linq;
using System.Security.Cryptography;

namespace TimeApplication
{
    /// <summary>
    /// Interaction logic for Register.xaml
    /// </summary>
    public partial class Register : Window
    {
        string hpWord;
        public Register()
        {
            InitializeComponent();
        }

        private void submitButton_Click(object sender, RoutedEventArgs e)
        {
            // Validation: Check if the required fields are filled
            if (string.IsNullOrWhiteSpace(fName.Text) || string.IsNullOrWhiteSpace(sName.Text) || string.IsNullOrWhiteSpace(email.Text) || string.IsNullOrWhiteSpace(passWord.Text))
            {
               
                saveMsg.Foreground = Brushes.Red;
                saveMsg.Text = "Please fill in all the required fields.";
                return;
            }
            hpWord = HashPassword(returnBytes(passWord.Text));
            SaveData();
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
        public void SaveData()
        {
            string f_Name = fName.Text;
            string s_Name = sName.Text;
            string e_Mail = email.Text;
            string p_word = hpWord;

            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\User\\source\\repos\\TimeApplication\\TimeApplication\\TimeAppDB.mdf;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                  string insertQuery = "INSERT INTO [User] (F_NAME, S_NAME, EMAIL, P_WORD) " +
                    "VALUES (@F_NAME, @S_NAME, @EMAIL, @P_WORD)";


                using (SqlCommand command = new SqlCommand(insertQuery, connection))
                {
                    command.Parameters.AddWithValue("@F_NAME", f_Name);
                    command.Parameters.AddWithValue("@S_NAME", s_Name);
                    command.Parameters.AddWithValue("@EMAIL", e_Mail);
                    command.Parameters.AddWithValue("@P_WORD", p_word);

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {

                        saveMsg.Foreground = Brushes.Red;
                        saveMsg.Text = "Registration successful! You can now log in.";
                    }
                    else
                    {
                        saveMsg.Text = "What are you trying here? You ain't the one\nFailed to insert student data.";
                    }
                }
                connection.Close();
            }             

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
