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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        AppContext db;
        public MainWindow()
        {
            InitializeComponent();
            db = new AppContext();  

            List<User> users = db.Users.ToList();
            string str = "";

            foreach (User user in users)
            {
                str += "   Login: " + user.Login + "   "+ user.Pass + "   " + user.Email + " ";
            }

            sql.Text = str;
        }

        private void Button_reg_Click(object sender, RoutedEventArgs e)
        {
            string login = Login.Text.Trim();
            string pass = Password.Password;
            string pass2 = Password2.Password;
            string Email = tEmail.Text.ToLower();

            if (pass.Length < 5)
            {
                Password.ToolTip = "некорекно";
                Password.Background = Brushes.Red;
            }
            else if(pass2.Length < 5) 
            {
                Password2.ToolTip = "некорекно";
                Password2.Background = Brushes.Red;
            }
            else if (pass != pass2)
            {
                Password2.Background = Brushes.Red;
            }
            else if (!Email.Contains("@") || !Email.Contains("."))
            {
                tEmail.Background = Brushes.Red;

            }
            else
            {
                Password.Background = Brushes.Green;
                Password2.Background = Brushes.Green;
                tEmail.Background = Brushes.Green;
                Login.Background = Brushes.Green;

                MessageBox.Show("вы вошли на сайт");
                User user = new User(login,pass,Email);

                //db.Users.Add(user);
                db.Users.Remove(user);
                db.SaveChanges();
               
            }
        }

        private void Button_win_aus_Click(object sender, RoutedEventArgs e)
        {
            AusWindoy aus = new AusWindoy();
            aus.Show();
            Hide();
        }

        
    }
}
