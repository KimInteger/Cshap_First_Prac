using System.Windows;
using System.Windows.Controls;

namespace MoveSquare.Pages
{
    public partial class PageOne : Page
    {
        public PageOne()
        {
            InitializeComponent();
        }

        private void GoToPageTwo_Click(object sender, RoutedEventArgs e)
        {
            // MainWindow�� �ִ� Frame�� ���� PageTwo�� �̵�
            NavigationService?.Navigate(new PageTwo());
        }
    }
}
