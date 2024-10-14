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
            // MainWindow에 있는 Frame을 통해 PageTwo로 이동
            NavigationService?.Navigate(new PageTwo());
        }
    }
}
