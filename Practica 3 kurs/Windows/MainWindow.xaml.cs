using Practica;
using System;
using pr.Class;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Practica_3_kurs.Windows;
using System.Windows.Media;

namespace Practica_3_kurs
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        static void UpdateUser()
        {
            var userId = 1;

            var context = new AppDbContext();

            var update_user = new User { Id = userId, Login = "admin", Password = "admin" };

            context.Users.Update(update_user);
            context.SaveChanges();
        }
 

        private void reg_Click(object sender, RoutedEventArgs e)
        {
            Registration main = new Registration();

            main.Show();
            this.Hide();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var login = loginTextBox.Text;
            string password = PasswordBox.Password;

            var context = new AppDbContext();
            var user_exists = context.Users.SingleOrDefault(x => x.Login == login && x.Password == password);
            if (user_exists is null)
            {
                errorTextBlock.Text = "Логин или пароль введены неверно!";
                errorTextBlock.Visibility = Visibility.Visible;
                loginTextBox.Foreground = Brushes.Red;
                PasswordBox.Foreground = Brushes.Red;
                return;
            }
            
            string log = loginTextBox.Text;
            MessageBox.Show("Вы успешно вошли в аккаунт!");
            Hide();
            new personalAccount(log).ShowDialog();
            


        }



        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Environment.Exit(0);
        }


        private BitmapImage firstImage = new BitmapImage(new Uri("C:\\Users\\0303m\\Desktop\\Practica3\\Practica 3 kurs\\Windows\\eye_slash_visible_hide_hidden_show_icon_145987.png"));
        private BitmapImage secondImage = new BitmapImage(new Uri("C:\\Users\\0303m\\Desktop\\Practica3\\Practica 3 kurs\\Windows\\eye_visible_hide_hidden_show_icon_145988.png"));

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            if (image.Source == firstImage)
            {
                image.Source = secondImage;
            }
            else
            {
                image.Source = firstImage;
            }

            if (PasswordBox.Visibility == Visibility.Visible)
            {
                PasswordBox.Visibility = Visibility.Hidden;
                passsss.Text = PasswordBox.Password;
                passsss.Visibility = Visibility.Visible;
            }
            else
            {
                passsss.Visibility = Visibility.Hidden;
                PasswordBox.Visibility = Visibility.Visible;
            }
        }
    }
}