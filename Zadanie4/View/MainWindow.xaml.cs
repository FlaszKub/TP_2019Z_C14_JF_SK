using System;
using System.Windows;
using ViewModel;

namespace View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public void ShowPopup(string message)
        {
            MessageBox.Show(message);
        }

        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);
            MainViewModel mainViewModel = (MainViewModel)DataContext;
            mainViewModel.MainWindow = this;
        }
    }
}
