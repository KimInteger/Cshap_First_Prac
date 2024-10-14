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
        ExampleBlock // 다른 블록 타입을 추가할 수 있습니다.
    }

    public class Map
    {
        public UIElement[] Blocks { get; private set; }
        private BlockFactory blockFactory; // BlockFactory 인스턴스 추가

        public Map(Canvas parentCanvas)
        {
            // BlockFactory 인스턴스 초기화
            blockFactory = new BlockFactory();

            // 블록 생성 및 위치 설정 (블록 수를 4로 증가)
            Blocks = new UIElement[4];

            // 땅 블록 추가 (화면의 아래쪽에 위치)
            Blocks[0] = blockFactory.CreateBlock(0, 400, 800, 50, Brushes.Green, BlockType.OnGround.ToString()); // 땅 블록

            // BlockFactory를 사용하여 나머지 블록 생성
            Blocks[1] = blockFactory.CreateBlock(300, 380, 30, 30, Brushes.Brown, BlockType.Door.ToString()); // 문
            Blocks[2] = blockFactory.CreateBlock(100, 300, 100, 30, Brushes.Gray, BlockType.OnGround.ToString());  // 예시 블록
            Blocks[3] = blockFactory.CreateBlock(0, 200, 200, 30, Brushes.Gray, BlockType.OnGround.ToString());    // 예시 블록

            // 블록을 부모 캔버스에 추가
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

                // 충돌 감지 로직
                if (playerLeft + playerWidth >= blockLeft &&
                    playerLeft <= blockLeft + blockWidth &&
                    playerTop + playerHeight >= blockTop &&
                    playerTop + playerHeight <= blockTop + blockHeight)
                {
                    Debug.WriteLine("Player is on a block.");
                    return true; // 블록 위에 있음
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

                // 충돌 감지 로직
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
