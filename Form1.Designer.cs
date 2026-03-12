namespace CatchButton
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            boxbox = new Button();
            btnRestart = new Button();
            SuspendLayout();
            // 
            // boxbox
            // 
            boxbox.BackColor = Color.FromArgb(192, 192, 255);
            boxbox.Font = new Font("맑은 고딕", 27.75F, FontStyle.Bold, GraphicsUnit.Point, 129);
            boxbox.Location = new Point(470, 180);
            boxbox.Name = "boxbox";
            boxbox.Size = new Size(242, 100);
            boxbox.TabIndex = 0;
            boxbox.Text = "나를 잡아봐";
            boxbox.UseVisualStyleBackColor = false;
            boxbox.Click += button1_Click;
            boxbox.MouseEnter += boxbox_MouseEnter;
            // 
            // btnRestart
            // 
            btnRestart.Location = new Point(12, 12);
            btnRestart.Name = "btnRestart";
            btnRestart.Size = new Size(100, 30);
            btnRestart.TabIndex = 1;
            btnRestart.Text = "다시시작";
            btnRestart.UseVisualStyleBackColor = true;
            btnRestart.Click += btnRestart_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnRestart);
            Controls.Add(boxbox);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion

        private Button boxbox;
        private Button btnRestart;
    }
}
