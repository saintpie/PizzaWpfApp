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

namespace WpfApp4
{
    /// <summary>
    /// Логика взаимодействия для wpfWindow.xaml
    /// </summary>
    public partial class wpfWindow : Window
    {
        public wpfWindow()
        {
            InitializeComponent();
            var application = new ApplicationContext();

            var users = application.users.AsEnumerable().ToList();
            list.ItemsSource = users;
        }
    }
}
