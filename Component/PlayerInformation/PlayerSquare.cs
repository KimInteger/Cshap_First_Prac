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
        private double jumpHeight = 150; // Jump �ִ� ����
        private double jumpDuration = 400; // Jump ���� �ð�

        public Player()
        {
            // �÷��̾� UI ����
            X = 0;
            Y = 380; // �ʱ� Y ��ġ

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

        // �÷��̾� �̵� �Լ�
        public void Move(double deltaX, double deltaY)
        {
            X += deltaX;
            Y += deltaY;

            // UI ��� ��ġ ������Ʈ
            Canvas.SetLeft(PlayerUIElement, X);
            Canvas.SetTop(PlayerUIElement, Y);
        }

        // JUMP
        public void Jump()
        {
            // ���� Y ��ġ
            double currentY = Y;

            // ��ǥ Y ��ġ
            double targetY = currentY - jumpHeight;

            // ���� ���� ������Ʈ (���� ����)
            PlayerUIElement.Fill = Brushes.Red; // ���� ���� �� ������ ���������� ����

            // �ִϸ��̼� ���� �� ����
            DoubleAnimation jumpAnimation = new DoubleAnimation
            {
                From = currentY,
                To = targetY,
                Duration = new Duration(TimeSpan.FromMilliseconds(jumpDuration)), // 400 �и���
                EasingFunction = new QuadraticEase { EasingMode = EasingMode.EaseInOut }
            };

            // ���� �ִϸ��̼� ����
            DoubleAnimation returnAnimation = new DoubleAnimation
            {
                From = targetY,
                To = currentY,
                Duration = new Duration(TimeSpan.FromMilliseconds(jumpDuration)), // 400 �и���
                EasingFunction = new QuadraticEase { EasingMode = EasingMode.EaseInOut }
            };

            // ù ��° �ִϸ��̼� ����
            PlayerUIElement.BeginAnimation(Canvas.TopProperty, jumpAnimation);

            // ù ��° �ִϸ��̼��� �Ϸ�� �� �� ��° �ִϸ��̼� ����
            jumpAnimation.Completed += (s, e) =>
            {
                // ���� �ִϸ��̼� ����
                PlayerUIElement.BeginAnimation(Canvas.TopProperty, returnAnimation);
            };

            // �� ��° �ִϸ��̼� �Ϸ� �� ���� ����
            returnAnimation.Completed += (s, e) =>
            {
                // ���� �ִϸ��̼��� �Ϸ�� �� �÷��̾��� ������ ������� ����
                Application.Current.Dispatcher.Invoke(() =>
                {
                    PlayerUIElement.Fill = Brushes.White; // ���� �� ������ ������� ����
                });
            };
        }
    }
}