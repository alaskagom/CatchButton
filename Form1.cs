using System;
using System.Media;
using System.Drawing;

namespace CatchButton
{
    public partial class Form1 : Form
    {
        private int score = 0;
        private int misses = 0;
        private Size initialBoxSize;
        private Font initialBoxFont;
        private Point initialBoxLocation;
        private const int MaxMisses = 20;

        public Form1()
        {
            InitializeComponent();
            // 초기 상태 저장
            initialBoxSize = boxbox.Size;
            initialBoxFont = boxbox.Font;
            initialBoxLocation = boxbox.Location;
            // 초기 점수 표시
            this.Text = $"점수: {score}";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 점수 증가 (잡았을 때 +100)
            score += 100;
            // 버튼 크기 10% 축소
            double scale = 0.9;
            int newWidth = Math.Max(10, (int)Math.Round(boxbox.Width * scale));
            int newHeight = Math.Max(10, (int)Math.Round(boxbox.Height * scale));
            boxbox.Size = new Size(newWidth, newHeight);
            // 버튼 폰트도 함께 축소(최소 폰트 크기 제한)
            float newFontSize = Math.Max(6f, boxbox.Font.Size * (float)scale);
            boxbox.Font = new Font(boxbox.Font.FontFamily, newFontSize, boxbox.Font.Style);
            // 버튼이 폼 범위를 벗어나지 않도록 보정
            int maxX = this.ClientSize.Width - boxbox.Width;
            int maxY = this.ClientSize.Height - boxbox.Height;
            if (boxbox.Left > maxX) boxbox.Left = Math.Max(0, maxX);
            if (boxbox.Top > maxY) boxbox.Top = Math.Max(0, maxY);

            // 잡았을 때 소리 재생
            SystemSounds.Exclamation.Play();
            // 잡았을 때 메시지 표시 (최종 점수 포함)
            MessageBox.Show($"축하합니다~!\n최종 점수: {score}", "성공", MessageBoxButtons.OK, MessageBoxIcon.Information);
            // 폼 제목에 점수 표시
            this.Text = $"점수: {score}";
        }

        private void boxbox_MouseEnter(object sender, EventArgs e)
        {
            // 1. 난수생성기 준비
            // 도망갈 때 소리 재생
            SystemSounds.Asterisk.Play();
            var rd = new Random();
            // 2. 가용 영역 계산 (버튼이 폼 테두리에 걸리지 않게 보호)
            int maxX = this.ClientSize.Width - boxbox.Width;
            int maxY = this.ClientSize.Height - boxbox.Height;
            if (maxX < 0) maxX = 0;
            if (maxY < 0) maxY = 0;
            // 3. 랜덤 좌표 추출 (0 ~ 최대 가용치 사이)
            int nextX = rd.Next(0, maxX + 1);
            int nextY = rd.Next(0, maxY + 1);
            // 4. 위치 할당
            boxbox.Location = new Point(nextX, nextY);
            // 점수 감소 (도망갈 때 -10)
            score -= 10;
            // 놓침 카운트 증가
            misses += 1;
            // 게임오버 체크
            if (misses >= MaxMisses)
            {
                GameOver();
                return;
            }
            // 5. 시각적 피드백 (폼 제목 표시줄에 점수, 놓침 수 및 좌표 출력)
            this.Text = $"점수: {score} - 놓침: {misses} - 버튼위치: ({nextX}, {nextY})";
        }

        private void GameOver()
        {
            // 게임오버 메시지
            MessageBox.Show("Game Over", "Game Over", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            // 모든 버튼 비활성화(다시시작 버튼은 활성화 상태로 둠)
            foreach (Control c in this.Controls)
            {
                if (c is Button btn)
                {
                    if (btn.Name == "btnRestart")
                        btn.Enabled = true;
                    else
                        btn.Enabled = false;
                }
            }
        }

        private void btnRestart_Click(object sender, EventArgs e)
        {
            // 게임 관련 정보 초기화
            score = 0;
            misses = 0;
            // 버튼 크기/폰트/위치 복원
            boxbox.Size = initialBoxSize;
            boxbox.Font = initialBoxFont;
            boxbox.Location = initialBoxLocation;
            // 모든 버튼 활성화
            foreach (Control c in this.Controls)
            {
                if (c is Button btn)
                {
                    btn.Enabled = true;
                }
            }
            // 폼 제목 초기화
            this.Text = $"점수: {score}";
        }
    }
}
