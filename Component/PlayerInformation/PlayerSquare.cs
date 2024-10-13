using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using System.Diagnostics;

namespace MoveSquare.Component.StaticPlayer
{
    public class Player
    {
        public double X { get; private set; }
        public double Y { get; private set; }
        public Rectangle PlayerUIElement { get; private set; }
        private TextBlock textBlock;
        private double jumpHeight = 150;
        private double jumpDuration = 1000;
        private bool isJumping = false; // 점프 중인지 상태를 확인하기 위한 변수

        // 애니메이션 미리 생성
        private DoubleAnimation jumpAnimation;

        public Player(Canvas parentCanvas)
        {
            X = 0;
            Y = 380;

            PlayerUIElement = new Rectangle
            {
                Width = 30,
                Height = 30,
                Fill = Brushes.White,
                Stroke = Brushes.Black
            };

            textBlock = new TextBlock
            {
                Text = "1",
                Foreground = Brushes.Black,
                FontSize = 16,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center
            };

            Canvas.SetLeft(PlayerUIElement, X);
            Canvas.SetTop(PlayerUIElement, Y);
            Canvas.SetLeft(textBlock, X + 7);
            Canvas.SetTop(textBlock, Y + 5);

            parentCanvas.Children.Add(PlayerUIElement);
            parentCanvas.Children.Add(textBlock);

            // 애니메이션 미리 설정
            jumpAnimation = new DoubleAnimation
            {
                Duration = new Duration(TimeSpan.FromMilliseconds(jumpDuration)),
                EasingFunction = new QuadraticEase { EasingMode = EasingMode.EaseInOut },
                AutoReverse = true
            };

            // 애니메이션 완료 시 핸들러
            jumpAnimation.Completed += (s, e) =>
            {
                Debug.WriteLine("Jump animation completed!");
                PlayerUIElement.Fill = Brushes.White;
                textBlock.Text = "0";
                isJumping = false; // 점프 완료 상태로 변경
            };
        }

        public void Move(double deltaX, double deltaY)
        {
            X += deltaX;
            Y += deltaY;

            Canvas.SetLeft(PlayerUIElement, X);
            Canvas.SetTop(PlayerUIElement, Y);
            Canvas.SetLeft(textBlock, X + 7);
            Canvas.SetTop(textBlock, Y + 5);
        }

        public void Jump()
        {
            if (isJumping) return; // 점프 중일 경우 아무 작업도 수행하지 않음

            isJumping = true; // 점프 시작 상태로 변경

            double currentY = Y;
            double targetY = currentY - jumpHeight;

            PlayerUIElement.Fill = Brushes.Red;

            // 애니메이션의 시작과 끝 위치 설정
            jumpAnimation.From = currentY;
            jumpAnimation.To = targetY;

            PlayerUIElement.BeginAnimation(Canvas.TopProperty, jumpAnimation);
            Debug.WriteLine("Jump animation started!");
            Debug.WriteLine($"isJumping: {isJumping}");
        }
    }
}
