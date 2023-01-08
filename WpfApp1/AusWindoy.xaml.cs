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

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для AusWindoy.xaml
    /// </summary>
    public partial class AusWindoy : Window
    {
        public AusWindoy()
        {
            InitializeComponent();
        }

        private void Button_Aus_Click(object sender, RoutedEventArgs e)
        {
            string login = Login.Text.Trim();
            string pass = Password.Password.Trim();
           


            if (pass.Length < 5)
            {
                Password.ToolTip = "некорекно";
                Password.Background = Brushes.Red;
            }
            else if(login.Length < 4)
            {
                Login.ToolTip = "некорекно";
                Login.Background = Brushes.Red;

            }
            else
            {
                Password.ToolTip = "";
                Password.Background = Brushes.Green;
                Login.ToolTip = "";
                Login.Background = Brushes.Green;

                User ausUser = null;
                using (AppContext config = new AppContext())
                
                {
                    
                    ausUser = config.Users.Where(b => b.Login == login && b.Pass == pass).FirstOrDefault();
                    
                    //ausUser = d.Users.FirstOrDefault();
                    
                }
                if (ausUser != null)
                {
                    MessageBox.Show("вы вошли на сайт");
                   // UserPageWindow userPageWindow = new UserPageWindow();
                    //userPageWindow.Show();
                    //Hide();
                }
                else
                    MessageBox.Show("неверно");

            }
        }

        private void Button_reg_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();  
            Hide();
        }
    }
}
