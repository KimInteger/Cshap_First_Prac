using System.Windows;
using System.Windows.Controls;

namespace MoveSquare.Pages
{
    public partial class PageTwo : Page
    {
        public PageTwo()
        {
            InitializeComponent();
        }

        private void GoToPageThree_Click(object sender, RoutedEventArgs e)
        {
            // MainWindow�� �ִ� Frame�� ���� PageThree�� �̵�
            NavigationService?.Navigate(new PageThree());
        }
    }
}
