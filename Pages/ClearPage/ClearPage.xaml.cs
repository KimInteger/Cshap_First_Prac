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
            // MainWindow�� �ִ� Frame���� ���ư���
            NavigationService?.Navigate(new StartPage()); // PageOne���� �̵�
        }
    }
}
