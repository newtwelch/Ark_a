using Ark.ViewModel;
using System;
using System.Windows;
using System.Windows.Media;

namespace Ark
{
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            DataContext = new MainWindowViewModel();
            InitializeComponent();
            MainMenu.SelectedItem = 0;
        }

        //Hide Window
        private void hideClick(object sender, RoutedEventArgs e)
        {

            Window window = GetParentWindow((DependencyObject)sender);
            window.WindowState = WindowState.Minimized;
        }

        //Resize Window
        private void resizeClick(object sender, RoutedEventArgs e)
        {
            Window window = GetParentWindow((DependencyObject)sender);
            if (window.WindowState == WindowState.Normal)
            {
                window.WindowState = WindowState.Maximized;
            }
            else
            {
                window.WindowState = WindowState.Normal;
            }
        }

        //Close Window
        private void closeClick(object sender, RoutedEventArgs e)
        {
            Window window = GetParentWindow((DependencyObject)sender);
            window.Close();
        }

        private Window GetParentWindow(DependencyObject child)
        {

            DependencyObject parentObject = VisualTreeHelper.GetParent(child);

            if (parentObject == null)
            {
                return null;
            }

            Window parent = parentObject as Window;
            if (parent != null)
            {
                return parent;
            }
            else
            {
                return GetParentWindow(parentObject);
            }

        }
    }
}