using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Controls;
using System.Windows.Media.Animation; // 추가된 네임스페이스

namespace MoveSquare.Component.StaticPlayer
{
    public class Player
    {
        public double X { get; private set; }
        public double Y { get; private set; }
        public Rectangle PlayerUIElement { get; private set; }

        public Player()
        {
            // 플레이어 UI 설정
            X = 0;
            Y = 380;

            PlayerUIElement = new Rectangle
            {
                Width = 30,
                Height = 30,
                Fill = Brushes.White,
                Stroke = Brushes.Black
            };

            Canvas.SetLeft(PlayerUIElement, X);
            Canvas.SetTop(PlayerUIElement, Y);
        }

        // 플레이어 이동 함수
        public void Move(double deltaX, double deltaY)
        {
            X += deltaX;
            Y += deltaY;

            // UI 요소 위치 업데이트
            Canvas.SetLeft(PlayerUIElement, X);
            Canvas.SetTop(PlayerUIElement, Y);
        }

        // Space 바를 눌렀을 때 이동 애니메이션 함수
        public void Jump()
        {
            // 현재 Y 위치
            double currentY = Y;

            // 목표 Y 위치 (-150)
            double targetY = currentY - 150;

            // Animation을 위한 DoubleAnimation 객체 생성
            DoubleAnimation moveUp = new DoubleAnimation
            {
                From = currentY,
                To = targetY,
                Duration = new Duration(TimeSpan.FromMilliseconds(1500)), // 1500 밀리초
                AutoReverse = true, // 애니메이션이 끝나면 되돌아감
                EasingFunction = new QuadraticEase { EasingMode = EasingMode.EaseInOut } // 부드러운 이동
            };

            // PlayerUIElement의 Y 위치에 애니메이션 적용
            PlayerUIElement.BeginAnimation(Canvas.TopProperty, moveUp);
        }
    }
}
