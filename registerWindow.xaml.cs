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
using System.Data.SqlClient;
using System.Data;

namespace GreenLife
{
    /// <summary>
    /// Логика взаимодействия для registerWindow.xaml
    /// </summary>
    public partial class registerWindow : Window
    {
        public registerWindow()
        {
            InitializeComponent();
            invalidLogOrPass.Visibility = Visibility.Collapsed;
        }
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
                
            }
        }

        private void svernyt_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }
        private void zakrit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        private void CheckTextBlockLength(Control control)
        {
            if (control is TextBox textBox)
            {
                if (textBox.Text.Length < 5)
                {
                    textBox.BorderBrush = Brushes.Red;
                }
                else
                {
                    textBox.BorderBrush = Brushes.Green;
                }
            }
            else if (control is PasswordBox passwordBox)
            {
                if (passwordBox.Password.Length < 5)
                {
                    passwordBox.BorderBrush = Brushes.Red;
                }
                else
                {
                    passwordBox.BorderBrush = Brushes.Green;
                }
            }
        }
        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            if (txtLogin.Text.Length < 5 || txtName.Text.Length < 5 || txtSurname.Text.Length < 5 || txtPassword.Password.Length < 5 || txtLogin.Text == "Введите другой логин")
            {
                CheckTextBlockLength(txtLogin);
                CheckTextBlockLength(txtName);
                CheckTextBlockLength(txtSurname);
                CheckTextBlockLength(txtPassword);
                invalidLogOrPass.Visibility = Visibility.Visible;
            }
            else
            {
                DB db = new DB();
                SqlConnection connection = db.getConnection();

                DataTable table = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter();

                SqlCommand command = new SqlCommand("SELECT * FROM [Greenlife] WHERE [Login]=@login", connection);
                command.Parameters.Add("@login", SqlDbType.VarChar).Value = txtLogin.Text;

                adapter.SelectCommand = command;
                adapter.Fill(table);
                if (table.Rows.Count > 0)
                {
                    messageBoxEst messageBoxEst = new messageBoxEst();
                    messageBoxEst.Show();
                    txtLogin.Text = "Введите другой логин";
                }
                else
                {
                    command = new SqlCommand("INSERT INTO [Greenlife] ([Login], [Name], [Surname], [Password]) VALUES (@login, @name, @surname, @password)", connection);
                    command.Parameters.Add("@login", SqlDbType.VarChar).Value = txtLogin.Text;
                    command.Parameters.Add("@name", SqlDbType.VarChar).Value = txtName.Text;
                    command.Parameters.Add("@surname", SqlDbType.VarChar).Value = txtSurname.Text;
                    command.Parameters.Add("@password", SqlDbType.VarChar).Value = txtPassword.Password;

                    db.openConnection();
                    command.ExecuteNonQuery();
                    db.closeConnection();
                    messageBoxSuccess messageBoxSuccess = new messageBoxSuccess();
                    messageBoxSuccess.Show();
                    txtLogin.Text = "";
                    txtName.Text = "";
                    txtSurname.Text = "";
                    txtPassword.Password = "";
                }
            }
        }
        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            loginWindow loginWindow = new loginWindow();
            this.Hide();
            loginWindow.Show();
        }

        private void txtLogin_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(txtLogin.BorderBrush == Brushes.Red)
            {
                invalidLogOrPass.Visibility = Visibility.Visible;
            }
            else
            {
                invalidLogOrPass.Visibility = Visibility.Collapsed;
            }
            CheckTextBlockLength(txtLogin);

        }

        private void txtName_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtName.BorderBrush == Brushes.Red)
            {
                invalidLogOrPass.Visibility = Visibility.Visible;
            }
            else
            {
                invalidLogOrPass.Visibility = Visibility.Collapsed;
            }
            CheckTextBlockLength(txtName);
        }

        private void txtSurname_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtSurname.BorderBrush == Brushes.Red)
            {
                invalidLogOrPass.Visibility = Visibility.Visible;
            }
            else
            {
                invalidLogOrPass.Visibility = Visibility.Collapsed;
            }
            CheckTextBlockLength(txtSurname);
        }

        private void txtPassword_TextChanged(object sender, RoutedEventArgs e)
        {
            if (txtPassword.BorderBrush == Brushes.Red)
            {
                invalidLogOrPass.Visibility = Visibility.Visible;
            }
            else
            {
                invalidLogOrPass.Visibility = Visibility.Collapsed;
            }
            CheckTextBlockLength(txtPassword);
        }
    }
}
