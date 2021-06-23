using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CPHub
{
   
    public partial class ImageWindow : Window
    {
        
        public ImageWindow(ImageSource input)
        {
            InitializeComponent();
            var ScreenSize = System.Windows.SystemParameters.WorkArea;
            this.MaxHeight = ScreenSize.Height;
            this.MaxWidth = ScreenSize.Width;

            this.Height = input.Height + 30;
            this.Width = input.Width;

            Image.Source = input;
        }

       
    }
    
}
