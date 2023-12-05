using deepcheesebacon.Customizing;
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
            prt_btn = new CustomButtonStyle();
            label1 = new Label();
            SelectMonth = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)payView).BeginInit();
            SuspendLayout();
            // 
            // payView
            // 
            payView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            payView.Location = new Point(22, 196);
            payView.Name = "payView";
            payView.RowHeadersWidth = 51;
            payView.Size = new Size(787, 601);
            payView.TabIndex = 66;
            // 
            // prt_btn
            // 
            prt_btn.BackColor = Color.FromArgb(94, 159, 242);
            prt_btn.BackgroundColor = Color.FromArgb(94, 159, 242);
            prt_btn.BorderColor = Color.PaleVioletRed;
            prt_btn.BorderRadius = 20;
            prt_btn.BorderSize = 0;
            prt_btn.FlatAppearance.BorderSize = 0;
            prt_btn.FlatStyle = FlatStyle.Flat;
            prt_btn.Font = new Font("맑은 고딕", 11F, FontStyle.Bold, GraphicsUnit.Point);
            prt_btn.ForeColor = Color.White;
            prt_btn.Location = new Point(585, 123);
            prt_btn.Margin = new Padding(4);
            prt_btn.Name = "prt_btn";
            prt_btn.Size = new Size(220, 40);
            prt_btn.TabIndex = 21;
            prt_btn.Text = "급여 내역서 산출";
            prt_btn.TextColor = Color.White;
            prt_btn.UseVisualStyleBackColor = false;
            prt_btn.Click += prt_btn_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("맑은 고딕", 11F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(231, 128);
            label1.Name = "label1";
            label1.Size = new Size(153, 30);
            label1.TabIndex = 68;
            label1.Text = "월 급여내역서";
            // 
            // SelectMonth
            // 
            SelectMonth.FormattingEnabled = true;
            SelectMonth.Items.AddRange(new object[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12" });
            SelectMonth.Location = new Point(22, 129);
            SelectMonth.Name = "SelectMonth";
            SelectMonth.Size = new Size(182, 33);
            SelectMonth.TabIndex = 69;
            SelectMonth.SelectedIndexChanged += SelectMonth_SelectedIndexChanged;
            // 
            // Salary
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(SelectMonth);
            Controls.Add(label1);
            Controls.Add(prt_btn);
            Controls.Add(payView);
            Name = "Salary";
            Size = new Size(977, 817);
            Load += Salary_Load;
            ((System.ComponentModel.ISupportInitialize)payView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView payView;
        private CustomButtonStyle prt_btn;
        private Label label1;
        private ComboBox SelectMonth;
    }
}
