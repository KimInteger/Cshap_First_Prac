using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Controls;
using System.Windows.Media.Animation; // �߰��� ���ӽ����̽�

namespace MoveSquare.Component.StaticPlayer
{
    public class Player
    {
        public double X { get; private set; }
        public double Y { get; private set; }
        public Rectangle PlayerUIElement { get; private set; }

        public Player()
        {
            // �÷��̾� UI ����
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

        // �÷��̾� �̵� �Լ�
        public void Move(double deltaX, double deltaY)
        {
            X += deltaX;
            Y += deltaY;

            // UI ��� ��ġ ������Ʈ
            Canvas.SetLeft(PlayerUIElement, X);
            Canvas.SetTop(PlayerUIElement, Y);
        }

        // Space �ٸ� ������ �� �̵� �ִϸ��̼� �Լ�
        public void Jump()
        {
            // ���� Y ��ġ
            double currentY = Y;

            // ��ǥ Y ��ġ (-150)
            double targetY = currentY - 150;

            // Animation�� ���� DoubleAnimation ��ü ����
            DoubleAnimation moveUp = new DoubleAnimation
            {
                From = currentY,
                To = targetY,
                Duration = new Duration(TimeSpan.FromMilliseconds(1500)), // 1500 �и���
                AutoReverse = true, // �ִϸ��̼��� ������ �ǵ��ư�
                EasingFunction = new QuadraticEase { EasingMode = EasingMode.EaseInOut } // �ε巯�� �̵�
            };

            // PlayerUIElement�� Y ��ġ�� �ִϸ��̼� ����
            PlayerUIElement.BeginAnimation(Canvas.TopProperty, moveUp);
        }
    }
}
