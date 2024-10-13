using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Controls;

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
    }
}
