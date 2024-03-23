using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using Почтовое_отправление;

namespace Почтовое_отправление
{
    public class dds
    {

        public int retint()
        {
            return 666;
        }
    }
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Label_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            Window1 window1 = new Window1();
            window1.Show();
            this.Close();
        }

        private void TextBox_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            par.Clear();
        }

        private void Logi_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            logi.Clear();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var dir = from s in Class1.context.TestTech
                      where s.LOGIN == logi.Text && s.PASSWORD == par.Text
                      select new
                      {
                          logi = s.LOGIN,
                          par = s.PASSWORD
                      };
            if (dir.Count() != 0)
            {
                ProcessStartInfo sInfo = new ProcessStartInfo("https://www.youtube.com/watch?v=GFq6wH5JR2A");
                Process.Start(sInfo);
            }

            else
            {
                MessageBox.Show("Данные введены неправильно");
            }

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

    }
}
