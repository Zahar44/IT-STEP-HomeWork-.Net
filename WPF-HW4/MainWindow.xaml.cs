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

namespace WPF_HW4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            FillComboBoxses();
        }

        public void FillComboBoxses()
        {
            for (int i = 1; i < 100; i++)
            {
                if(i % 3 == 0 || i < 12)
                {
                    FontSizeComboBox.Items.Add(i);
                }
            }
            FontSizeComboBox.SelectedItem = 12;

            foreach (var color in Enum.GetValues(typeof(System.Drawing.KnownColor)))
            {
                ColorComboBox.Items.Add(color);
            }
            ColorComboBox.SelectedItem = System.Drawing.KnownColor.Black;
        }

        private void TextBox_SelectionChanged(object sender, RoutedEventArgs e)
        {
            var textBox = sender as RichTextBox;
            int start = textBox.Document.ContentStart.GetOffsetToPosition(textBox.Selection.Start) - 1;
            int end = start + textBox.Selection.Text.Length;
            StartScore.Text = start.ToString();
            EndScore.Text = end.ToString();
        }

        private void BoldTextClick(object sender, RoutedEventArgs e)
        {
            DoBoldTextChanges();
        }
        private void ItalicTextClick(object sender, RoutedEventArgs e)
        {
            DoItalicTextChanges();
        }
        private void UnderlineTextClick(object sender, RoutedEventArgs e)
        {
            DoUnderlineTextChanges();
        }
        private void ClearTextClick(object sender, RoutedEventArgs e)
        {
            DoClearTextChanges();
        }
        private void FontSizeChanged(object sender, SelectionChangedEventArgs e)
        {
            ChangeFontSize((int)(sender as ComboBox).SelectedItem);
        }
        private void TextColorChanged(object sender, SelectionChangedEventArgs e)
        {
            var color = System.Drawing.Color.FromKnownColor((System.Drawing.KnownColor)(sender as ComboBox).SelectedItem);
            var windowColor = new Color();
            windowColor.A = color.A;
            windowColor.R = color.R;
            windowColor.G = color.G;
            windowColor.B = color.B;
            SolidColorBrush brush = new SolidColorBrush(windowColor);
            TextColorChanged(brush);
        }



        private void ChangeFontSize(int size)
        {
            TextRange currentTextRange = new TextRange(MainTextBox.Selection.Start, MainTextBox.Selection.End);
            double? currentStyledTextRange = currentTextRange.GetPropertyValue(Inline.FontSizeProperty) as double?;

            if(currentStyledTextRange is not null)
            {
                currentStyledTextRange = size;
                currentTextRange.ApplyPropertyValue(Inline.FontSizeProperty, currentStyledTextRange);
            }
        }

        private void TextColorChanged(SolidColorBrush brush)
        {
            TextRange currentTextRange = new TextRange(MainTextBox.Selection.Start, MainTextBox.Selection.End);
            var currentStyledTextRange = currentTextRange.GetPropertyValue(Inline.ForegroundProperty) as SolidColorBrush;

            if(currentStyledTextRange is not null)
            {
                currentStyledTextRange = brush;
                currentTextRange.ApplyPropertyValue(Inline.ForegroundProperty, currentStyledTextRange);
            }
        }

        private void DoBoldTextChanges()
        {
            TextRange currentTextRange = new TextRange(MainTextBox.Selection.Start, MainTextBox.Selection.End);
            FontWeight? currentStyledTextRange = currentTextRange.GetPropertyValue(Inline.FontWeightProperty) as FontWeight?;

            if(currentStyledTextRange is not null)
            {
                currentStyledTextRange = FontWeights.Bold;
                currentTextRange.ApplyPropertyValue(Inline.FontWeightProperty, currentStyledTextRange);
            }
        }

        private void DoUnderlineTextChanges()
        {
            TextRange currentTextRange = new TextRange(MainTextBox.Selection.Start, MainTextBox.Selection.End);
            TextDecorationCollection tdc = currentTextRange.GetPropertyValue(Inline.TextDecorationsProperty) as TextDecorationCollection;
            
            if (tdc is not null)
            {
                TextDecorationCollection tdc_clone = new TextDecorationCollection(tdc);
                tdc_clone.Add(TextDecorations.Underline);

                currentTextRange.ApplyPropertyValue(Inline.TextDecorationsProperty, tdc_clone);
            }
        }

        private void DoItalicTextChanges()
        {
            TextRange currentTextRange = new TextRange(MainTextBox.Selection.Start, MainTextBox.Selection.End);
            FontStyle? currentStyledTextRange = currentTextRange.GetPropertyValue(Inline.FontStyleProperty) as FontStyle?;

            if (currentStyledTextRange is not null)
            {
                currentStyledTextRange = FontStyles.Italic;
                currentTextRange.ApplyPropertyValue(Inline.FontStyleProperty, currentStyledTextRange);
            }
        }

        private void DoClearTextChanges()
        {
            TextRange textRange = new TextRange(MainTextBox.Document.ContentStart, MainTextBox.Document.ContentEnd);
            Paragraph paragraph = new Paragraph(new Run(textRange.Text));
            MainTextBox.Document.Blocks.Clear();
            MainTextBox.Document.Blocks.Add(paragraph);
        }
    }
}
