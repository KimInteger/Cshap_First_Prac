using System.Windows;
using MoveSquare.Pages; // Pages 네임스페이스 추가

namespace MoveSquare
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // Frame에 StartPage로 이동
            MainFrame.Navigate(new StartPage());
        }
    }
}
