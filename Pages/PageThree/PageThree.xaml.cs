using System.Windows;
using System.Windows.Controls;

namespace MoveSquare.Pages
{
    public partial class PageThree : Page
    {
        public PageThree()
        {
            InitializeComponent();
        }

        private void GoToClearPage_Click(object sender, RoutedEventArgs e)
        {
            // MainWindow�� �ִ� Frame�� ���� ClearPage���� �̵�
            NavigationService?.Navigate(new ClearPage());
        }
    }
}
