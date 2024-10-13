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
        private bool isJumping = false; // ���� ������ ���¸� Ȯ���ϱ� ���� ����

        // �ִϸ��̼� �̸� ����
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

            // �ִϸ��̼� �̸� ����
            jumpAnimation = new DoubleAnimation
            {
                Duration = new Duration(TimeSpan.FromMilliseconds(jumpDuration)),
                EasingFunction = new QuadraticEase { EasingMode = EasingMode.EaseInOut },
                AutoReverse = true
            };

            // �ִϸ��̼� �Ϸ� �� �ڵ鷯
            jumpAnimation.Completed += (s, e) =>
            {
                Debug.WriteLine("Jump animation completed!");
                PlayerUIElement.Fill = Brushes.White;
                textBlock.Text = "0";
                isJumping = false; // ���� �Ϸ� ���·� ����
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
            if (isJumping) return; // ���� ���� ��� �ƹ� �۾��� �������� ����

            isJumping = true; // ���� ���� ���·� ����

            double currentY = Y;
            double targetY = currentY - jumpHeight;

            PlayerUIElement.Fill = Brushes.Red;

            // �ִϸ��̼��� ���۰� �� ��ġ ����
            jumpAnimation.From = currentY;
            jumpAnimation.To = targetY;

            PlayerUIElement.BeginAnimation(Canvas.TopProperty, jumpAnimation);
            Debug.WriteLine("Jump animation started!");
            Debug.WriteLine($"isJumping: {isJumping}");
        }
    }
}
