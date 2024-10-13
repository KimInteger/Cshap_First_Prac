using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Controls;
using MoveSquare.Component.MapInformation.BlockFactory;

namespace MoveSquare.Component.BasicMap
{
    public class Map
    {
        public UIElement[] Blocks { get; private set; }
        private BlockFactory blockFactory; // BlockFactory �ν��Ͻ� �߰�

        public Map()
        {
            // BlockFactory �ν��Ͻ� �ʱ�ȭ
            blockFactory = new BlockFactory();

            // ��� ���� �� ��ġ ����
            Blocks = new UIElement[3];

            // BlockFactory�� ����Ͽ� ��� ����
            Blocks[0] = blockFactory.CreateBlock(300, 380, 30, 30, Brushes.Brown); // ��
            Blocks[1] = blockFactory.CreateBlock(100, 300, 100, 30, Brushes.Gray);  // ���� ���
            Blocks[2] = blockFactory.CreateBlock(0, 200, 200, 30, Brushes.Gray);
        }
    }
}