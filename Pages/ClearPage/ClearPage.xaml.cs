using System.Windows;
using System.Windows.Controls;

namespace MoveSquare.Pages
{
    public partial class ClearPage : Page
    {
        public ClearPage()
        {
            InitializeComponent();
        }

        private void ReturnToMain_Click(object sender, RoutedEventArgs e)
        {
            // MainWindow에 있는 Frame으로 돌아가기
            NavigationService?.Navigate(new StartPage()); // PageOne으로 이동
        }
    }
}
