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
            // MainWindow에 있는 Frame을 통해 ClearPage으로 이동
            NavigationService?.Navigate(new ClearPage());
        }
    }
}
