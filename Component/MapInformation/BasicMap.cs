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
        private BlockFactory blockFactory; // BlockFactory 인스턴스 추가

        public Map()
        {
            // BlockFactory 인스턴스 초기화
            blockFactory = new BlockFactory();

            // 블록 생성 및 위치 설정
            Blocks = new UIElement[3];

            // BlockFactory를 사용하여 블록 생성
            Blocks[0] = blockFactory.CreateBlock(300, 380, 30, 30, Brushes.Brown); // 문
            Blocks[1] = blockFactory.CreateBlock(100, 300, 100, 30, Brushes.Gray);  // 예시 블록
            Blocks[2] = blockFactory.CreateBlock(0, 200, 200, 30, Brushes.Gray);
        }
    }
}