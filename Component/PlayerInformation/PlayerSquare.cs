using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Controls;
using System.Windows.Media.Animation; 

namespace MoveSquare.Component.StaticPlayer
{
    public class Player
    {
        public double X { get; private set; }
        public double Y { get; private set; }
        public Rectangle PlayerUIElement { get; private set; }
        private double jumpHeight = 150; // Jump 최대 높이
        private double jumpDuration = 400; // Jump 지속 시간

        public Player()
        {
            // 플레이어 UI 설정
            X = 0;
            Y = 380; // 초기 Y 위치

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

        // JUMP
        public void Jump()
        {
            // 현재 Y 위치
            double currentY = Y;

            // 목표 Y 위치
            double targetY = currentY - jumpHeight;

            // 점프 상태 업데이트 (색상 변경)
            PlayerUIElement.Fill = Brushes.Red; // 점프 시작 시 색상을 빨간색으로 변경

            // 애니메이션 생성 및 적용
            DoubleAnimation jumpAnimation = new DoubleAnimation
            {
                From = currentY,
                To = targetY,
                Duration = new Duration(TimeSpan.FromMilliseconds(jumpDuration)), // 400 밀리초
                EasingFunction = new QuadraticEase { EasingMode = EasingMode.EaseInOut }
            };

            // 리턴 애니메이션 생성
            DoubleAnimation returnAnimation = new DoubleAnimation
            {
                From = targetY,
                To = currentY,
                Duration = new Duration(TimeSpan.FromMilliseconds(jumpDuration)), // 400 밀리초
                EasingFunction = new QuadraticEase { EasingMode = EasingMode.EaseInOut }
            };

            // 첫 번째 애니메이션 시작
            PlayerUIElement.BeginAnimation(Canvas.TopProperty, jumpAnimation);

            // 첫 번째 애니메이션이 완료된 후 두 번째 애니메이션 시작
            jumpAnimation.Completed += (s, e) =>
            {
                // 리턴 애니메이션 시작
                PlayerUIElement.BeginAnimation(Canvas.TopProperty, returnAnimation);
            };

            // 두 번째 애니메이션 완료 후 색상 변경
            returnAnimation.Completed += (s, e) =>
            {
                // 리턴 애니메이션이 완료된 후 플레이어의 색상을 흰색으로 변경
                Application.Current.Dispatcher.Invoke(() =>
                {
                    PlayerUIElement.Fill = Brushes.White; // 리턴 후 색상을 흰색으로 변경
                });
            };
        }
    }
}