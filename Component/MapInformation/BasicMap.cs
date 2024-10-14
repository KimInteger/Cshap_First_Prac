using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Controls;
using MoveSquare.Component.MapInformation.BlockFactory;
using MoveSquare.Component.StaticPlayer;
using System.Diagnostics;

namespace MoveSquare.Component.BasicMap
{
    public enum BlockType
    {
        OnGround,
        Door,
        ExampleBlock // �ٸ� ��� Ÿ���� �߰��� �� �ֽ��ϴ�.
    }

    public class Map
    {
        public UIElement[] Blocks { get; private set; }
        private BlockFactory blockFactory; // BlockFactory �ν��Ͻ� �߰�

        public Map(Canvas parentCanvas)
        {
            // BlockFactory �ν��Ͻ� �ʱ�ȭ
            blockFactory = new BlockFactory();

            // ��� ���� �� ��ġ ���� (��� ���� 4�� ����)
            Blocks = new UIElement[4];

            // �� ��� �߰� (ȭ���� �Ʒ��ʿ� ��ġ)
            Blocks[0] = blockFactory.CreateBlock(0, 400, 800, 50, Brushes.Green, BlockType.OnGround.ToString()); // �� ���

            // BlockFactory�� ����Ͽ� ������ ��� ����
            Blocks[1] = blockFactory.CreateBlock(300, 380, 30, 30, Brushes.Brown, BlockType.Door.ToString()); // ��
            Blocks[2] = blockFactory.CreateBlock(100, 300, 100, 30, Brushes.Gray, BlockType.OnGround.ToString());  // ���� ���
            Blocks[3] = blockFactory.CreateBlock(0, 200, 200, 30, Brushes.Gray, BlockType.OnGround.ToString());    // ���� ���

            // ����� �θ� ĵ������ �߰�
            foreach (var block in Blocks)
            {
                parentCanvas.Children.Add(block);
            }
        }

        public bool CheckPlayerOnBlock(Player player)
        {
            double playerLeft = Canvas.GetLeft(player.PlayerUIElement);
            double playerTop = Canvas.GetTop(player.PlayerUIElement);
            double playerWidth = player.PlayerUIElement.Width;
            double playerHeight = player.PlayerUIElement.Height;

            foreach (var block in Blocks)
            {
                double blockLeft = Canvas.GetLeft(block);
                double blockTop = Canvas.GetTop(block);
                double blockWidth = ((Rectangle)block).Width;
                double blockHeight = ((Rectangle)block).Height;

                // �浹 ���� ����
                if (playerLeft + playerWidth >= blockLeft &&
                    playerLeft <= blockLeft + blockWidth &&
                    playerTop + playerHeight >= blockTop &&
                    playerTop + playerHeight <= blockTop + blockHeight)
                {
                    Debug.WriteLine("Player is on a block.");
                    return true; // ��� ���� ����
                }
            }

            Debug.WriteLine("Player is not on a block.");
            return IsOnGround(player);
        }

        public bool IsOnGround(Player player)
        {
            double playerLeft = Canvas.GetLeft(player.PlayerUIElement);
            double playerTop = Canvas.GetTop(player.PlayerUIElement);
            double playerWidth = player.PlayerUIElement.Width;
            double playerHeight = player.PlayerUIElement.Height;

            foreach (var block in Blocks)
            {
                double blockLeft = Canvas.GetLeft(block);
                double blockTop = Canvas.GetTop(block);
                double blockWidth = ((Rectangle)block).Width;
                double blockHeight = ((Rectangle)block).Height;

                // �浹 ���� ����
                if (playerLeft + playerWidth >= blockLeft &&
                    playerLeft <= blockLeft + blockWidth &&
                    playerTop + playerHeight >= blockTop &&
                    playerTop + playerHeight <= blockTop + blockHeight &&
                    block is FrameworkElement frameworkElement && frameworkElement.Tag?.ToString() == BlockType.OnGround.ToString())
                {
                    Debug.WriteLine("Player is standing on an OnGround block.");
                    return true;
                }
            }

            Debug.WriteLine("Player is not on ground.");
            return false;
        }
    }
}
