namespace deepcheesebacon
{
    partial class Salary
    {
        /// <summary> 
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 구성 요소 디자이너에서 생성한 코드

        /// <summary> 
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            payView = new DataGridView();
            panel1 = new Panel();
            label1 = new Label();
            SelectMonth = new ComboBox();
            label6 = new Label();
            prt_btn = new Button();
            ((System.ComponentModel.ISupportInitialize)payView).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // payView
            // 
            payView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            payView.Location = new Point(22, 260);
            payView.Name = "payView";
            payView.RowHeadersWidth = 51;
            payView.Size = new Size(931, 537);
            payView.TabIndex = 66;
            // 
            // panel1
            // 
            panel1.BackColor = Color.SteelBlue;
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(977, 165);
            panel1.TabIndex = 54;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("맑은 고딕", 15F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = SystemColors.HighlightText;
            label1.Location = new Point(453, 62);
            label1.Name = "label1";
            label1.Size = new Size(168, 41);
            label1.TabIndex = 0;
            label1.Text = "급여내역서";
            // 
            // SelectMonth
            // 
            SelectMonth.FormattingEnabled = true;
            SelectMonth.Items.AddRange(new object[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12" });
            SelectMonth.Location = new Point(22, 198);
            SelectMonth.Name = "SelectMonth";
            SelectMonth.Size = new Size(99, 33);
            SelectMonth.TabIndex = 67;
            SelectMonth.SelectedIndexChanged += SelectMonth_SelectedIndexChanged;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("맑은 고딕", 11F, FontStyle.Regular, GraphicsUnit.Point);
            label6.Location = new Point(127, 198);
            label6.Name = "label6";
            label6.Size = new Size(161, 30);
            label6.TabIndex = 68;
            label6.Text = "월 급여 내역서";
            // 
            // prt_btn
            // 
            prt_btn.Font = new Font("맑은 고딕", 11F, FontStyle.Regular, GraphicsUnit.Point);
            prt_btn.Location = new Point(730, 194);
            prt_btn.Name = "prt_btn";
            prt_btn.Size = new Size(223, 37);
            prt_btn.TabIndex = 69;
            prt_btn.Text = "급여내역서 산출";
            prt_btn.UseVisualStyleBackColor = true;
            prt_btn.Click += prt_btn_Click;
            // 
            // Salary
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(prt_btn);
            Controls.Add(label6);
            Controls.Add(SelectMonth);
            Controls.Add(payView);
            Controls.Add(panel1);
            Name = "Salary";
            Size = new Size(977, 817);
            Load += Salary_Load;
            ((System.ComponentModel.ISupportInitialize)payView).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox listBox1;
        private DataGridView payView;
        private TextBox textBox4;
        private TextBox textBox3;
        private TextBox textBox2;
        private TextBox textBox1;
        private Button button3;
        private Button button2;
        private Button button1;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Panel panel1;
        private Label label1;
        private ComboBox SelectMonth;
        private Label label6;
        private Button prt_btn;
    }
}
