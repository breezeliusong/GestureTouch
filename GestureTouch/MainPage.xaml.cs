using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Shapes;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace GestureTouch
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        // Global translation transform used for changing the position of 
        // the Rectangle based on input data from the touch contact.
        private TranslateTransform dragTranslation;
        public MainPage()
        {
            this.InitializeComponent();
            // Pointer event listeners.
            touchRectangle.PointerPressed += touchRectangle_PointerPressed;
            touchRectangle.PointerReleased += touchRectangle_PointerReleased;
            touchRectangle.PointerExited += touchRectangle_PointerExited;

            // Listener for the ManipulationDelta event.
            ManipulationRectangle.ManipulationDelta += touchRectangle_ManipulationDelta;
            // New translation transform populated in 
            // the ManipulationDelta handler.
            dragTranslation = new TranslateTransform();
            // Apply the translation to the Rectangle.
            ManipulationRectangle.RenderTransform = this.dragTranslation;
        }

        // Handler for the ManipulationDelta event.
        // ManipulationDelta data is loaded into the
        // translation transform and applied to the Rectangle.
        void touchRectangle_ManipulationDelta(object sender,
            ManipulationDeltaRoutedEventArgs e)
        {
            // Move the rectangle.
            dragTranslation.X += e.Delta.Translation.X;
            dragTranslation.Y += e.Delta.Translation.Y;
        }

        // Handler for pointer exited event.
        private void touchRectangle_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            Rectangle rect = sender as Rectangle;

            // Pointer moved outside Rectangle hit test area.
            // Reset the dimensions of the Rectangle.
            if (null != rect)
            {
                rect.Fill=new SolidColorBrush(Color.FromArgb(255,255,0,0));
            }
        }
        // Handler for pointer released event.
        private void touchRectangle_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            Rectangle rect = sender as Rectangle;

            // Reset the dimensions of the Rectangle.
            if (null != rect)
            {
                rect.Width = 200;
                rect.Height = 100;
                rect.Fill = new SolidColorBrush(Color.FromArgb(255,  0,255, 0));
            }
        }

        // Handler for pointer pressed event.
        private void touchRectangle_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            Rectangle rect = sender as Rectangle;

            // Change the dimensions of the Rectangle.
            if (null != rect)
            {
                rect.Width = 250;
                rect.Height = 150;
                rect.Fill = new SolidColorBrush(Color.FromArgb(255, 255, 255, 0));
            }
        }
    }
}

