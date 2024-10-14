using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using System.Diagnostics;
using MoveSquare.Component.BasicMap; // 이 네임스페이스가 정확한지 확인

namespace MoveSquare.Component.StaticPlayer
{
    public class Player
    {
        public double X { get; private set; }
        public double Y { get; private set; }
        public Rectangle PlayerUIElement { get; private set; }
        private double jumpHeight = 140;
        private double jumpDuration = 1000;
        public bool isJumping { get; private set; } = false; // 점프 중인지 상태를 확인하기 위한 변수
        public bool IsOnGround { get; private set; } = true; // 플레이어가 바닥에 있는지 확인

        // 애니메이션 미리 생성
        private DoubleAnimation? jumpAnimation;

        public Player(Canvas parentCanvas)
        {
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

            parentCanvas.Children.Add(PlayerUIElement);

            InitializeJumpAnimation(); // 애니메이션 초기화
        }

        private void InitializeJumpAnimation()
        {
            jumpAnimation = new DoubleAnimation
            {
                Duration = new Duration(TimeSpan.FromMilliseconds(jumpDuration)),
                EasingFunction = new QuadraticEase { EasingMode = EasingMode.EaseInOut },
                AutoReverse = true
            };

            jumpAnimation.Completed += (s, e) =>
            {
                Debug.WriteLine("Jump animation completed!");
                PlayerUIElement.Fill = Brushes.White;
                isJumping = false;
                IsOnGround = true; // 점프 완료 후 바닥에 있음
                Debug.WriteLine($"Player is on ground: {IsOnGround}");
            };
        }

        public void Jump()
        {
            if (isJumping || !IsOnGround) return;

            isJumping = true;
            IsOnGround = false;

            double currentY = Y;
            double targetY = currentY - jumpHeight;

            PlayerUIElement.Fill = Brushes.Red;

            jumpAnimation.From = currentY;
            jumpAnimation.To = targetY;

            // 애니메이션 시작
            PlayerUIElement.BeginAnimation(Canvas.TopProperty, jumpAnimation);
            Debug.WriteLine("Jump animation started!");

            // 점프 애니메이션 중단 조건
            jumpAnimation.CurrentStateInvalidated += (s, e) =>
            {
                // 중단 조건은 외부에서 관리하도록 합니다.
                // 이 로직은 점프가 완료된 후에만 상태를 업데이트합니다.
            };
        }

        public void Move(double deltaX, double deltaY)
        {
            if (PlayerUIElement == null) return; // null 체크 추가

            X += deltaX;
            Y += deltaY;

            Canvas.SetLeft(PlayerUIElement, X);
            Canvas.SetTop(PlayerUIElement, Y);
        }

        public void UpdateIsOnGround(bool isOnGround)
        {
            IsOnGround = isOnGround;
            Debug.WriteLine($"Player is on ground: {IsOnGround}");
        }

        public void StopAtGround()
        {
            isJumping = false;
            IsOnGround = true;
            Debug.WriteLine("Player stopped on the ground.");
            // 플레이어의 위치를 바닥에 맞춥니다. 예: Y를 적절한 값으로 변경
            Canvas.SetTop(PlayerUIElement, Y); // Y 좌표를 업데이트
        }

        public bool IsOnBlock(Map map)
        {
            return map.CheckPlayerOnBlock(this); // 맵에서 블록에 있는지 확인
        }
    }
}
