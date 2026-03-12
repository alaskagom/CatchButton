namespace CatchButton
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void boxbox_MouseEnter(object sender, EventArgs e)
        {
            // 1. 난수생성기 준비
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
            // 5. 시각적 피드백 (폼 제목 표시줄에 좌표 출력)
            this.Text = $"버튼위치: ({nextX}, {nextY})";
        }
    }
}
