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
using MoveSquare.Component.StaticPlayer;
using MoveSquare.Component.BasicMap;

namespace MoveSquare
{
    public partial class MainWindow : Window
    {
        private Player? player;
        private Map? map;

        public MainWindow()
        {
            InitializeComponent();

            // Start 버튼 생성
            Button startButton = new Button
            {
                Content = "START",
                Width = 100,
                Height = 50,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center
            };
            startButton.Click += StartButton_Click;

            // Start 버튼을 Grid에 추가
            AppGrid.Children.Add(startButton);
        }

        // Start 버튼 클릭 시 게임 시작
        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            // Grid 초기화 (Start 버튼 삭제)
            AppGrid.Children.Clear();

            // Canvas 생성
            Canvas gameCanvas = new Canvas
            {
                Background = System.Windows.Media.Brushes.LightGray,
                Width = 800,
                Height = 450
            };
            AppGrid.Children.Add(gameCanvas);

            // 플레이어 객체 생성 및 추가
            player = new Player();
            gameCanvas.Children.Add(player.PlayerUIElement);

            // 맵 객체 생성 및 추가 (블록 디자인)
            map = new Map();
            foreach (var block in map.Blocks)
            {
                gameCanvas.Children.Add(block);
            }

            // 키 이벤트 핸들러 등록
            this.KeyDown += OnKeyDown;
        }

        // 키 입력 처리
        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Right)
            {
                player.Move(10, 0);  // 오른쪽 이동
            }
            else if (e.Key == Key.Left)
            {
                player.Move(-10, 0);  // 왼쪽 이동
            }
            else if (e.Key == Key.Space)
            {
                player.Jump(); // Jump 메서드 호출
            }
        }
    }
}