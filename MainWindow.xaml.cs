using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MoveSquare;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    // 게임 시작 여부를 관리하는 변수
    private bool isGameStart = false;

    // 플레이어의 위치
    private double playerX = 0;
    private double playerY = 170;
    private const double doorX = 300;  // 문 위치
    private const double doorY = 170;

    public MainWindow()
    {
        InitializeComponent();
    }

    // Start 버튼 클릭 이벤트 처리
    private void StartButton_Click(object sender, RoutedEventArgs e)
    {
        isGameStart = true;

        // Start 버튼을 숨기고, 게임 Canvas를 보여줌
        StartButton.Visibility = Visibility.Hidden;
        GameCanvas.Visibility = Visibility.Visible;

        // 게임이 시작되면 키보드 입력을 받기 시작
        this.KeyDown += new KeyEventHandler(OnKeyDown);
    }

    // 키보드 입력 처리
    private void OnKeyDown(object sender, KeyEventArgs e)
    {
        if (e.Key == Key.Right)
        {
            MovePlayer(10, 0);  // 오른쪽 이동
        }
        else if (e.Key == Key.Left)
        {
            MovePlayer(-10, 0);  // 왼쪽 이동
        }

        // 플레이어가 문에 도달했는지 확인
        CheckForClear();
    }

    // 플레이어 이동 함수
    private void MovePlayer(double deltaX, double deltaY)
    {
        playerX += deltaX;
        playerY += deltaY;

        // 플레이어 위치를 Canvas에 적용
        Canvas.SetLeft(Player, playerX);
        Canvas.SetTop(Player, playerY);
    }

    // 문에 도달하면 Clear 문구 표시
    private void CheckForClear()
    {
        if (playerX >= doorX && playerY == doorY)
        {
            ClearText.Visibility = Visibility.Visible;
        }
    }
}