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
using Microsoft.SqlServer.Server;
using System.Data;
using System.Xml.Linq;

namespace GreenLife
{
    /// <summary>
    /// Логика взаимодействия для loginWindow.xaml
    /// </summary>
    public partial class loginWindow : Window
    {
        public loginWindow()
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
        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            DB db = new DB();
            SqlConnection connection = db.getConnection();

            DataTable table = new DataTable();

            SqlDataAdapter adapter = new SqlDataAdapter();

            SqlCommand command = new SqlCommand("SELECT * FROM [Greenlife] WHERE [Login] = @uN AND [Password] =@uP", connection);

            command.Parameters.Add("@uN", SqlDbType.VarChar).Value = txtLogin.Text;
            command.Parameters.Add("@uP", SqlDbType.VarChar).Value = txtPassword.Password;

            adapter.SelectCommand = command;
            adapter.Fill(table);
            if (txtLogin.Text.Length < 5 || txtPassword.Password.Length < 5)
            {
                invalidLogOrPass.Visibility = Visibility.Visible;
                txtLogin.BorderBrush = Brushes.Red;
                txtPassword.BorderBrush = Brushes.Red;
            }
            else if (table.Rows.Count > 0)
            {
                MainWindow MainWindow = new MainWindow();
                this.Hide();
                MainWindow.Show();
            }
            else
            {
                invalidLogOrPass.Visibility = Visibility.Visible;
                txtLogin.BorderBrush = Brushes.Red;
                txtPassword.BorderBrush = Brushes.Red;
            }
        }
        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            registerWindow registerWindow = new registerWindow();
            this.Hide();
            registerWindow.Show();
        }

        private void txtLogin_TextChanged(object sender, TextChangedEventArgs e)
        {
            invalidLogOrPass.Visibility = Visibility.Collapsed;
            if (txtLogin.Text.Length < 5 || txtLogin.Text.Length > 5)
            {
                txtLogin.BorderBrush = Brushes.Gray;
                txtPassword.BorderBrush = Brushes.Gray;
            }
        }
        private void txtPassword_TextChanged(object sender, RoutedEventArgs e)
        {
            invalidLogOrPass.Visibility = Visibility.Collapsed;
            if (txtPassword.Password.Length < 5 || txtPassword.Password.Length > 5)
            {
                txtLogin.BorderBrush = Brushes.Gray;
                txtPassword.BorderBrush = Brushes.Gray;
            }
        }
    }
}
