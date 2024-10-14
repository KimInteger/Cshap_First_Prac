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
            // MainWindow에 있는 Frame을 통해 PageThree로 이동
            NavigationService?.Navigate(new PageThree());
        }
    }
}
