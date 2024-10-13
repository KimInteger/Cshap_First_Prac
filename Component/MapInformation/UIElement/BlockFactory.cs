using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Controls;

namespace MoveSquare.Component.MapInformation.BlockFactory
{
    public class BlockFactory
    {
        // ��� ���� �Լ�
        public UIElement CreateBlock(double left, double top, double width, double height, Brush color)
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
