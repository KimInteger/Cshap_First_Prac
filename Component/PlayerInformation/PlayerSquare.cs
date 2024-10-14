using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using System.Diagnostics;
using MoveSquare.Component.BasicMap; // �� ���ӽ����̽��� ��Ȯ���� Ȯ��

namespace MoveSquare.Component.StaticPlayer
{
    public class Player
    {
        public double X { get; private set; }
        public double Y { get; private set; }
        public Rectangle PlayerUIElement { get; private set; }
        private double jumpHeight = 140;
        private double jumpDuration = 1000;
        public bool isJumping { get; private set; } = false; // ���� ������ ���¸� Ȯ���ϱ� ���� ����
        public bool IsOnGround { get; private set; } = true; // �÷��̾ �ٴڿ� �ִ��� Ȯ��

        // �ִϸ��̼� �̸� ����
        private DoubleAnimation? jumpAnimation;

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

            Canvas.SetLeft(PlayerUIElement, X);
            Canvas.SetTop(PlayerUIElement, Y);

            parentCanvas.Children.Add(PlayerUIElement);

            InitializeJumpAnimation(); // �ִϸ��̼� �ʱ�ȭ
        }

        private void InitializeJumpAnimation()
        {
            jumpAnimation = new DoubleAnimation
            {
                Duration = new Duration(TimeSpan.FromMilliseconds(jumpDuration)),
                EasingFunction = new QuadraticEase { EasingMode = EasingMode.EaseInOut },
                AutoReverse = true
            };

            jumpAnimation.Completed += (s, e) =>
            {
                Debug.WriteLine("Jump animation completed!");
                PlayerUIElement.Fill = Brushes.White;
                isJumping = false;
                IsOnGround = true; // ���� �Ϸ� �� �ٴڿ� ����
                Debug.WriteLine($"Player is on ground: {IsOnGround}");
            };
        }

        public void Jump()
        {
            if (isJumping || !IsOnGround) return;

            isJumping = true;
            IsOnGround = false;

            double currentY = Y;
            double targetY = currentY - jumpHeight;

            PlayerUIElement.Fill = Brushes.Red;

            jumpAnimation.From = currentY;
            jumpAnimation.To = targetY;

            // �ִϸ��̼� ����
            PlayerUIElement.BeginAnimation(Canvas.TopProperty, jumpAnimation);
            Debug.WriteLine("Jump animation started!");

            // ���� �ִϸ��̼� �ߴ� ����
            jumpAnimation.CurrentStateInvalidated += (s, e) =>
            {
                // �ߴ� ������ �ܺο��� �����ϵ��� �մϴ�.
                // �� ������ ������ �Ϸ�� �Ŀ��� ���¸� ������Ʈ�մϴ�.
            };
        }

        public void Move(double deltaX, double deltaY)
        {
            if (PlayerUIElement == null) return; // null üũ �߰�

            X += deltaX;
            Y += deltaY;

            Canvas.SetLeft(PlayerUIElement, X);
            Canvas.SetTop(PlayerUIElement, Y);
        }

        public void UpdateIsOnGround(bool isOnGround)
        {
            IsOnGround = isOnGround;
            Debug.WriteLine($"Player is on ground: {IsOnGround}");
        }

        public void StopAtGround()
        {
            isJumping = false;
            IsOnGround = true;
            Debug.WriteLine("Player stopped on the ground.");
            // �÷��̾��� ��ġ�� �ٴڿ� ����ϴ�. ��: Y�� ������ ������ ����
            Canvas.SetTop(PlayerUIElement, Y); // Y ��ǥ�� ������Ʈ
        }

        public bool IsOnBlock(Map map)
        {
            return map.CheckPlayerOnBlock(this); // �ʿ��� ��Ͽ� �ִ��� Ȯ��
        }
    }
}
