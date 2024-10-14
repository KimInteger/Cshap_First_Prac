using System.Windows;
using System.Windows.Controls;
using MoveSquare.Pages; // Pages 네임스페이스 추가

namespace MoveSquare.Pages
{
    public partial class StartPage : Page
    {
        public StartPage()
        {
            InitializeComponent();
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            // Frame에 PageOne으로 이동
            NavigationService?.Navigate(new PageOne());
        }
    }
}
