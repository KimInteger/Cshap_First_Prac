using System.Windows;
using System.Windows.Controls;
using MoveSquare.Pages; // Pages ���ӽ����̽� �߰�

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
            // Frame�� PageOne���� �̵�
            NavigationService?.Navigate(new PageOne());
        }
    }
}
