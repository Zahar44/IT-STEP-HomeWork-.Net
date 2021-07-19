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

namespace WPF_HW5
{
    /// <summary>
    /// Interaction logic for ColorView.xaml
    /// </summary>
    public partial class ColorView : UserControl
    {
        private readonly string colorHash;
        public ColorView(ColorModel colorModel = null)
        {
            colorHash = colorModel.ToString();
            InitializeComponent();
            CreateModel(colorModel);
            DeleteButton.Click += (s, e) => Delete?.Invoke(this);
        }

        public delegate void DeleteHandler(object sender);

        public event DeleteHandler Delete;

        private void CreateModel(ColorModel colorModel)
        {
            colorModel ??= new ColorModel(Colors.Red);

            ColorRectangle.Fill = colorModel.GetColor();
            ColorHashTextBlock.Text = colorModel.ToString();
        }
        public override string ToString() => colorHash;
    }
}
