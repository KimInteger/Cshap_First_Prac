using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Controls;

namespace MoveSquare.Component.BasicMap
{
    public class Map
    {
        public UIElement[] Blocks { get; private set; }

        public Map()
        {
            // ��� ���� �� ��ġ ����
            Blocks = new UIElement[2];

            Blocks[0] = CreateBlock(300, 380, 30, 30, Brushes.Brown); // ��
            Blocks[1] = CreateBlock(100, 300, 100, 30, Brushes.Gray);  // ���� ���
        }

        // ��� ���� �Լ�
        private UIElement CreateBlock(double left, double top, double width, double height, Brush color)
        {
            Rectangle block = new Rectangle
            {
                Width = width,
                Height = height,
                Fill = color,
                Stroke = Brushes.Black
            };

            Canvas.SetLeft(block, left);
            Canvas.SetTop(block, top);

            return block;
        }
    }
}
