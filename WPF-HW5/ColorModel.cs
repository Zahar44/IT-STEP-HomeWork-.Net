using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace WPF_HW5
{
    public class ColorModel
    {
        private int blue;
        private int green;
        private int red;
        private int alpha;

        public int Alpha
        {
            get => alpha;
            set
            {
                alpha = value;
                ColorChanged?.Invoke(this, new ColorChangedArgs { Color = GetColor() });
            }
        }
        public int Red
        {
            get => red;
            set
            {
                red = value;
                ColorChanged?.Invoke(this, new ColorChangedArgs { Color = GetColor() });
            }
        }
        public int Green 
        { 
            get => green; 
            set
            {
                green = value;
                ColorChanged?.Invoke(this, new ColorChangedArgs { Color = GetColor() });
            }
        }
        public int Blue
        {
            get => blue;
            set
            {
                blue = value;
                ColorChanged?.Invoke(this, new ColorChangedArgs { Color = GetColor() });
            }
        }

        public delegate void ColorChangedHandler(object sender, ColorChangedArgs e);

        public event ColorChangedHandler ColorChanged;


        public ColorModel(Color color)
        {
            Alpha = color.A;
            Red = color.R;
            Green = color.G;
            Blue = color.B;
        }

        public ColorModel()
        {

        }

        public Brush GetColor()
        {
            return new SolidColorBrush(Color.FromArgb((byte)Alpha, (byte)Red, (byte)Green, (byte)Blue));
        }

        public class ColorChangedArgs : EventArgs
        {
            public Brush Color { get; set; }
        }

        public override bool Equals(object obj)
        {
            if(obj is ColorModel model)
            {
                return model.Alpha == Alpha
                    && model.Red == Red
                    && model.Blue == Blue
                    && model.Green == Green;
            }
            return false;
        }

        public override string ToString()
        {
            return new BrushConverter().ConvertToString(GetColor());
        }
    }
}
