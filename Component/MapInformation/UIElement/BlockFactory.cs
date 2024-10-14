using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Controls;

namespace MoveSquare.Component.MapInformation.BlockFactory
{
    public class BlockFactory
    {
        // 블록 생성 함수
        public UIElement CreateBlock(double left, double top, double width, double height, Brush color, string tag)
        {
            // 기본 색상 설정
            color ??= Brushes.Gray; // 색상이 null일 경우 기본값으로 Gray 사용

            // 블록 생성
            Rectangle block = new Rectangle
            {
                Width = width,
                Height = height,
                Fill = color,
                Stroke = Brushes.Black
            };

            // Tag 설정 (선택적)
            if (block is FrameworkElement frameworkElement)
            {
                frameworkElement.Tag = tag; // Tag 속성 사용
            }

            // 캔버스 위치 설정
            Canvas.SetLeft(block, left);
            Canvas.SetTop(block, top);

            return block; // 생성한 블록 반환
        }
    }
}
