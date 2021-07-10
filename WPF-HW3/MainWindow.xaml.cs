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

namespace WPF_HW3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool isUpper = false;

        public MainWindow()
        {
            InitializeComponent();
        }

        public void ProceedAllKeys()
        {
            foreach (Panel dp in KeyPanel.Children)
            {
                foreach (var item in dp.Children)
                {
                    if(item is Border border)
                    {
                        ChangeKeyContent((Button)border.Child);
                    }
                }
            }
        }

        public void ChangeKeyContent(Button button)
        {
            if (button.Content.ToString().Length > 1)
                return;

            if(isUpper)
            {
                button.Content = button.Content.ToString().ToUpper();
            }
            else
            {
                button.Content = button.Content.ToString().ToLower();
            }
        }

        private void Shift_Click(object sender, RoutedEventArgs e)
        {
            isUpper = !isUpper;
            ProceedAllKeys();
        }
    }
}
