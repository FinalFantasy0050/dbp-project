using deepcheesebacon.Customizing;

namespace deepcheesebacon
{
    partial class ApproveForm
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
            buttonRejectApproval = new CustomButtonStyle();
            buttonApproveApproval = new CustomButtonStyle();
            listBoxTaskRequiringMyApprovalList = new ListBox();
            labelDateTime = new Label();
            customGroupBox1 = new CustomGroupBox();
            customGroupBox2 = new CustomGroupBox();
            listBoxTaskDetail = new ListBox();
            textBoxComment = new TextBox();
            label1 = new Label();
            customGroupBox1.SuspendLayout();
            customGroupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // buttonRejectApproval
            // 
            buttonRejectApproval.BackColor = Color.FromArgb(94, 159, 242);
            buttonRejectApproval.BackgroundColor = Color.FromArgb(94, 159, 242);
            buttonRejectApproval.BorderColor = Color.FromArgb(4, 96, 217);
            buttonRejectApproval.BorderRadius = 10;
            buttonRejectApproval.BorderSize = 0;
            buttonRejectApproval.FlatStyle = FlatStyle.Flat;
            buttonRejectApproval.Font = new Font("맑은 고딕", 10F, FontStyle.Bold, GraphicsUnit.Point);
            buttonRejectApproval.ForeColor = Color.White;
            buttonRejectApproval.Location = new Point(569, 410);
            buttonRejectApproval.Name = "buttonRejectApproval";
            buttonRejectApproval.Size = new Size(75, 26);
            buttonRejectApproval.TabIndex = 11;
            buttonRejectApproval.Text = "반려";
            buttonRejectApproval.TextColor = Color.White;
            buttonRejectApproval.UseVisualStyleBackColor = false;
            buttonRejectApproval.Click += buttonRejectApproval_Click;
            // 
            // buttonApproveApproval
            // 
            buttonApproveApproval.BackColor = Color.FromArgb(94, 159, 242);
            buttonApproveApproval.BackgroundColor = Color.FromArgb(94, 159, 242);
            buttonApproveApproval.BorderColor = Color.FromArgb(4, 96, 217);
            buttonApproveApproval.BorderRadius = 10;
            buttonApproveApproval.BorderSize = 0;
            buttonApproveApproval.FlatStyle = FlatStyle.Flat;
            buttonApproveApproval.Font = new Font("맑은 고딕", 10F, FontStyle.Bold, GraphicsUnit.Point);
            buttonApproveApproval.ForeColor = Color.White;
            buttonApproveApproval.Location = new Point(480, 410);
            buttonApproveApproval.Name = "buttonApproveApproval";
            buttonApproveApproval.Size = new Size(75, 26);
            buttonApproveApproval.TabIndex = 10;
            buttonApproveApproval.Text = "결재";
            buttonApproveApproval.TextColor = Color.White;
            buttonApproveApproval.UseVisualStyleBackColor = false;
            buttonApproveApproval.Click += buttonApproveApproval_Click;
            // 
            // listBoxTaskRequiringMyApprovalList
            // 
            listBoxTaskRequiringMyApprovalList.FormattingEnabled = true;
            listBoxTaskRequiringMyApprovalList.ItemHeight = 15;
            listBoxTaskRequiringMyApprovalList.Location = new Point(6, 36);
            listBoxTaskRequiringMyApprovalList.Name = "listBoxTaskRequiringMyApprovalList";
            listBoxTaskRequiringMyApprovalList.Size = new Size(159, 334);
            listBoxTaskRequiringMyApprovalList.TabIndex = 13;
            listBoxTaskRequiringMyApprovalList.SelectedIndexChanged += listBoxTaskRequiringMyApprovalList_SelectedIndexChanged;
            // 
            // labelDateTime
            // 
            labelDateTime.AutoSize = true;
            labelDateTime.Location = new Point(27, 414);
            labelDateTime.Name = "labelDateTime";
            labelDateTime.Size = new Size(66, 15);
            labelDateTime.TabIndex = 14;
            labelDateTime.Text = "결재 시각: ";
            // 
            // customGroupBox1
            // 
            customGroupBox1.BackColor = Color.Transparent;
            customGroupBox1.Controls.Add(listBoxTaskRequiringMyApprovalList);
            customGroupBox1.Location = new Point(21, 17);
            customGroupBox1.Name = "customGroupBox1";
            customGroupBox1.Radious = 25;
            customGroupBox1.Size = new Size(171, 377);
            customGroupBox1.TabIndex = 28;
            customGroupBox1.TabStop = false;
            customGroupBox1.Text = "업무 리스트";
            customGroupBox1.TitleBackColor = Color.FromArgb(94, 159, 242);
            customGroupBox1.TitleFont = new Font("맑은 고딕", 14F, FontStyle.Bold, GraphicsUnit.Point);
            customGroupBox1.TitleForeColor = Color.White;
            customGroupBox1.TitleHatchStyle = System.Drawing.Drawing2D.HatchStyle.Percent60;
            // 
            // customGroupBox2
            // 
            customGroupBox2.BackColor = Color.Transparent;
            customGroupBox2.Controls.Add(label1);
            customGroupBox2.Controls.Add(textBoxComment);
            customGroupBox2.Controls.Add(listBoxTaskDetail);
            customGroupBox2.Location = new Point(216, 17);
            customGroupBox2.Name = "customGroupBox2";
            customGroupBox2.Radious = 25;
            customGroupBox2.Size = new Size(427, 377);
            customGroupBox2.TabIndex = 29;
            customGroupBox2.TabStop = false;
            customGroupBox2.Text = "업무 내용";
            customGroupBox2.TitleBackColor = Color.FromArgb(94, 159, 242);
            customGroupBox2.TitleFont = new Font("맑은 고딕", 14F, FontStyle.Bold, GraphicsUnit.Point);
            customGroupBox2.TitleForeColor = Color.White;
            customGroupBox2.TitleHatchStyle = System.Drawing.Drawing2D.HatchStyle.Percent60;
            // 
            // listBoxTaskDetail
            // 
            listBoxTaskDetail.FormattingEnabled = true;
            listBoxTaskDetail.ItemHeight = 15;
            listBoxTaskDetail.Location = new Point(6, 36);
            listBoxTaskDetail.Name = "listBoxTaskDetail";
            listBoxTaskDetail.Size = new Size(415, 304);
            listBoxTaskDetail.TabIndex = 0;
            // 
            // textBoxComment
            // 
            textBoxComment.Location = new Point(90, 347);
            textBoxComment.Name = "textBoxComment";
            textBoxComment.Size = new Size(331, 23);
            textBoxComment.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 350);
            label1.Name = "label1";
            label1.Size = new Size(78, 15);
            label1.TabIndex = 30;
            label1.Text = "결재 코멘트: ";
            // 
            // ApproveForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(666, 448);
            Controls.Add(customGroupBox2);
            Controls.Add(customGroupBox1);
            Controls.Add(labelDateTime);
            Controls.Add(buttonRejectApproval);
            Controls.Add(buttonApproveApproval);
            Name = "ApproveForm";
            Text = "ApproveForm";
            customGroupBox1.ResumeLayout(false);
            customGroupBox2.ResumeLayout(false);
            customGroupBox2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private ListBox listBoxTaskRequiringMyApprovalList;
        private Label labelDateTime;
        private CustomGroupBox customGroupBox1;
        private CustomButtonStyle buttonRejectApproval;
        private CustomButtonStyle buttonApproveApproval;
        private CustomGroupBox customGroupBox2;
        private ListBox listBoxTaskDetail;
        private Label label1;
        private TextBox textBoxComment;
    }
}