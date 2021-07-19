using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace WPF_HW5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ColorModel colorModel;

        public MainWindow()
        {
            colorModel = new ColorModel();
            InitializeComponent();

            ColorPresentationRectangle.Fill = colorModel.GetColor();
            colorModel.ColorChanged += ColorChanged;
        }

        private void AlphaValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            var slider = sender as Slider;
            int newValue = (int)e.NewValue;
            ChangeSliderValue(slider, newValue);

            AlphaAmount.Text = newValue.ToString();
            colorModel.Alpha = newValue;
        }

        private void RedValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            var slider = sender as Slider;
            int newValue = (int)e.NewValue;
            ChangeSliderValue(slider, newValue);

            RedAmount.Text = newValue.ToString();
            colorModel.Red = newValue;
        }

        private void GreenValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            var slider = sender as Slider;
            int newValue = (int)e.NewValue;
            ChangeSliderValue(slider, newValue);

            GreenAmount.Text = newValue.ToString();
            colorModel.Green = newValue;
        }

        private void BlueValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            var slider = sender as Slider;
            int newValue = (int)e.NewValue;
            ChangeSliderValue(slider, newValue);

            BlueAmount.Text = newValue.ToString();
            colorModel.Blue = newValue;
        }

        private void ChangeSliderValue(Slider slider, double value)
        {
            slider.SelectionEnd = value;
        }

        private void AlphaCheckBoxClick(object sender, RoutedEventArgs e)
        {
            AlphaSlider.IsEnabled = (bool)(sender as CheckBox).IsChecked;
        }
        private void RedCheckBoxClick(object sender, RoutedEventArgs e)
        {
            RedSlider.IsEnabled = (bool)(sender as CheckBox).IsChecked;
        }
        private void BlueCheckBoxClick(object sender, RoutedEventArgs e)
        {
            BlueSlider.IsEnabled = (bool)(sender as CheckBox).IsChecked;
        }
        private void GreenCheckBoxClick(object sender, RoutedEventArgs e)
        {
            GreenSlider.IsEnabled = (bool)(sender as CheckBox).IsChecked;
        }

        private void ColorChanged(object sender, ColorModel.ColorChangedArgs e)
        {
            ColorPresentationRectangle.Fill = e.Color;
            SaveButton.IsEnabled = !ColorAlreadySaved();
        }

        private bool ColorAlreadySaved()
        {
            bool has = false;
            foreach (var item in ColorsListBox.Items)
            {
                if (item.ToString() == colorModel.ToString())
                {
                    has = true;
                    break;
                }
            }
            return has;
        }
        private void SaveButtonClick(object sender, RoutedEventArgs e)
        {
            var colorView = new ColorView(colorModel);
            colorView.Delete += ColorDeleted;

            ColorsListBox.Items.Add(colorView);
            SaveButton.IsEnabled = !ColorAlreadySaved();
        }

        private void ColorDeleted(object sender)
        {
            ColorsListBox.Items.Remove(sender);
            SaveButton.IsEnabled = !ColorAlreadySaved();
        }
    }
}
