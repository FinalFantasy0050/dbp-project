using deepcheesebacon.work;

namespace deepcheesebacon;

partial class ApprovalSystemMainForm
{
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
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
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        buttonCreateNewApproval = new Customizing.CustomButtonStyle();
        buttonCheckMyApprovalList = new Customizing.CustomButtonStyle();
        dataGridViewApprovalList = new DataGridView();
        dataGridViewTaskSummary = new DataGridView();
        customGroupBox1 = new Customizing.CustomGroupBox();
        customGroupBox2 = new Customizing.CustomGroupBox();
        ((System.ComponentModel.ISupportInitialize)dataGridViewApprovalList).BeginInit();
        ((System.ComponentModel.ISupportInitialize)dataGridViewTaskSummary).BeginInit();
        customGroupBox1.SuspendLayout();
        customGroupBox2.SuspendLayout();
        SuspendLayout();
        // 
        // buttonCreateNewApproval
        // 
        buttonCreateNewApproval.BackColor = Color.FromArgb(94, 159, 242);
        buttonCreateNewApproval.BackgroundColor = Color.FromArgb(94, 159, 242);
        buttonCreateNewApproval.BorderColor = Color.PaleVioletRed;
        buttonCreateNewApproval.BorderRadius = 20;
        buttonCreateNewApproval.BorderSize = 0;
        buttonCreateNewApproval.FlatStyle = FlatStyle.Flat;
        buttonCreateNewApproval.Font = new Font("맑은 고딕", 12F, FontStyle.Bold, GraphicsUnit.Point);
        buttonCreateNewApproval.ForeColor = Color.White;
        buttonCreateNewApproval.Location = new Point(243, 418);
        buttonCreateNewApproval.Name = "buttonCreateNewApproval";
        buttonCreateNewApproval.Size = new Size(125, 32);
        buttonCreateNewApproval.TabIndex = 21;
        buttonCreateNewApproval.Text = "신규 결재 등록";
        buttonCreateNewApproval.TextColor = Color.White;
        buttonCreateNewApproval.UseVisualStyleBackColor = false;
        buttonCreateNewApproval.Click += buttonCreateNewApproval_Click;
        // 
        // buttonCheckMyApprovalList
        // 
        buttonCheckMyApprovalList.BackColor = Color.FromArgb(94, 159, 242);
        buttonCheckMyApprovalList.BackgroundColor = Color.FromArgb(94, 159, 242);
        buttonCheckMyApprovalList.BorderColor = Color.PaleVioletRed;
        buttonCheckMyApprovalList.BorderRadius = 20;
        buttonCheckMyApprovalList.BorderSize = 0;
        buttonCheckMyApprovalList.FlatStyle = FlatStyle.Flat;
        buttonCheckMyApprovalList.Font = new Font("맑은 고딕", 10F, FontStyle.Bold, GraphicsUnit.Point);
        buttonCheckMyApprovalList.ForeColor = Color.White;
        buttonCheckMyApprovalList.Location = new Point(578, 422);
        buttonCheckMyApprovalList.Name = "buttonCheckMyApprovalList";
        buttonCheckMyApprovalList.Size = new Size(152, 32);
        buttonCheckMyApprovalList.TabIndex = 4;
        buttonCheckMyApprovalList.Text = "나의 결재 리스트 확인";
        buttonCheckMyApprovalList.TextColor = Color.White;
        buttonCheckMyApprovalList.UseVisualStyleBackColor = false;
        buttonCheckMyApprovalList.Click += buttonCheckMyApprovalList_Click;
        // 
        // dataGridViewApprovalList
        // 
        dataGridViewApprovalList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dataGridViewApprovalList.Location = new Point(6, 36);
        dataGridViewApprovalList.Name = "dataGridViewApprovalList";
        dataGridViewApprovalList.RowHeadersWidth = 51;
        dataGridViewApprovalList.RowTemplate.Height = 25;
        dataGridViewApprovalList.Size = new Size(334, 308);
        dataGridViewApprovalList.TabIndex = 5;
        dataGridViewApprovalList.CellContentClick += dataGridViewApprovalList_CellContentClick;
        // 
        // dataGridViewTaskSummary
        // 
        dataGridViewTaskSummary.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dataGridViewTaskSummary.Location = new Point(9, 36);
        dataGridViewTaskSummary.Name = "dataGridViewTaskSummary";
        dataGridViewTaskSummary.RowHeadersWidth = 51;
        dataGridViewTaskSummary.Size = new Size(334, 308);
        dataGridViewTaskSummary.TabIndex = 6;
        // 
        // customGroupBox1
        // 
        customGroupBox1.BackColor = Color.Transparent;
        customGroupBox1.Controls.Add(dataGridViewApprovalList);
        customGroupBox1.Location = new Point(10, 62);
        customGroupBox1.Name = "customGroupBox1";
        customGroupBox1.Radious = 25;
        customGroupBox1.Size = new Size(349, 350);
        customGroupBox1.TabIndex = 27;
        customGroupBox1.TabStop = false;
        customGroupBox1.Text = "진행 중인 결재 목록";
        customGroupBox1.TitleBackColor = Color.FromArgb(94, 159, 242);
        customGroupBox1.TitleFont = new Font("맑은 고딕", 14F, FontStyle.Bold, GraphicsUnit.Point);
        customGroupBox1.TitleForeColor = Color.White;
        customGroupBox1.TitleHatchStyle = System.Drawing.Drawing2D.HatchStyle.Percent60;
        // 
        // customGroupBox2
        // 
        customGroupBox2.BackColor = Color.Transparent;
        customGroupBox2.Controls.Add(dataGridViewTaskSummary);
        customGroupBox2.Location = new Point(380, 62);
        customGroupBox2.Name = "customGroupBox2";
        customGroupBox2.Radious = 25;
        customGroupBox2.Size = new Size(349, 350);
        customGroupBox2.TabIndex = 28;
        customGroupBox2.TabStop = false;
        customGroupBox2.Text = "결재 업무 요약";
        customGroupBox2.TitleBackColor = Color.FromArgb(94, 159, 242);
        customGroupBox2.TitleFont = new Font("맑은 고딕", 14F, FontStyle.Bold, GraphicsUnit.Point);
        customGroupBox2.TitleForeColor = Color.White;
        customGroupBox2.TitleHatchStyle = System.Drawing.Drawing2D.HatchStyle.Percent60;
        // 
        // ApprovalSystemMainForm
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(740, 462);
        Controls.Add(customGroupBox2);
        Controls.Add(customGroupBox1);
        Controls.Add(buttonCheckMyApprovalList);
        Controls.Add(buttonCreateNewApproval);
        Name = "ApprovalSystemMainForm";
        Text = "ApprovalSystemMainForm";
        ((System.ComponentModel.ISupportInitialize)dataGridViewApprovalList).EndInit();
        ((System.ComponentModel.ISupportInitialize)dataGridViewTaskSummary).EndInit();
        customGroupBox1.ResumeLayout(false);
        customGroupBox2.ResumeLayout(false);
        ResumeLayout(false);
    }

    #endregion
    private DataGridView dataGridViewApprovalList;
    private DataGridView dataGridViewTaskSummary;
    private Customizing.CustomButtonStyle buttonCreateNewApproval;
    private Customizing.CustomButtonStyle buttonCheckMyApprovalList;
    private Customizing.CustomGroupBox customGroupBox1;
    private Customizing.CustomGroupBox customGroupBox2;
}