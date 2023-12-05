using deepcheesebacon.Customizing;

namespace deepcheesebacon.SourceCode.MessageSystem.Forms
{
    partial class realtimeChatDetailForm
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
            listBoxChatBox = new ListBox();
            buttonSendMessage = new CustomButtonStyle();
            customGroupBox1 = new CustomGroupBox();
            textBoxInputMessage = new TextBox();
            customGroupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // listBoxChatBox
            // 
            listBoxChatBox.FormattingEnabled = true;
            listBoxChatBox.ItemHeight = 15;
            listBoxChatBox.Location = new Point(9, 39);
            listBoxChatBox.Name = "listBoxChatBox";
            listBoxChatBox.Size = new Size(727, 334);
            listBoxChatBox.TabIndex = 6;
            // 
            // buttonSendMessage
            // 
            buttonSendMessage.BackColor = SystemColors.Window;
            buttonSendMessage.BackgroundColor = SystemColors.Window;
            buttonSendMessage.BorderColor = Color.FromArgb(4, 96, 217);
            buttonSendMessage.BorderRadius = 10;
            buttonSendMessage.BorderSize = 2;
            buttonSendMessage.FlatStyle = FlatStyle.Flat;
            buttonSendMessage.ForeColor = Color.DarkBlue;
            buttonSendMessage.Location = new Point(656, 375);
            buttonSendMessage.Name = "buttonSendMessage";
            buttonSendMessage.Size = new Size(79, 27);
            buttonSendMessage.TabIndex = 8;
            buttonSendMessage.Text = "전송";
            buttonSendMessage.TextColor = Color.DarkBlue;
            buttonSendMessage.UseVisualStyleBackColor = false;
            buttonSendMessage.Click += buttonSendMessage_Click;
            // 
            // customGroupBox1
            // 
            customGroupBox1.BackColor = Color.Transparent;
            customGroupBox1.Controls.Add(textBoxInputMessage);
            customGroupBox1.Controls.Add(buttonSendMessage);
            customGroupBox1.Controls.Add(listBoxChatBox);
            customGroupBox1.Location = new Point(31, 20);
            customGroupBox1.Name = "customGroupBox1";
            customGroupBox1.Radious = 25;
            customGroupBox1.Size = new Size(741, 410);
            customGroupBox1.TabIndex = 27;
            customGroupBox1.TabStop = false;
            customGroupBox1.Text = "실시간 채팅";
            customGroupBox1.TitleBackColor = Color.FromArgb(94, 159, 242);
            customGroupBox1.TitleFont = new Font("맑은 고딕", 17F, FontStyle.Bold, GraphicsUnit.Point);
            customGroupBox1.TitleForeColor = Color.White;
            customGroupBox1.TitleHatchStyle = System.Drawing.Drawing2D.HatchStyle.Percent60;
            // 
            // textBoxInputMessage
            // 
            textBoxInputMessage.BorderStyle = BorderStyle.None;
            textBoxInputMessage.Font = new Font("맑은 고딕", 11F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxInputMessage.Location = new Point(9, 375);
            textBoxInputMessage.Margin = new Padding(2, 2, 2, 2);
            textBoxInputMessage.Multiline = true;
            textBoxInputMessage.Name = "textBoxInputMessage";
            textBoxInputMessage.PlaceholderText = "채팅을 입력해주세요!";
            textBoxInputMessage.Size = new Size(646, 27);
            textBoxInputMessage.TabIndex = 31;
            textBoxInputMessage.TextChanged += textBoxInputMessage_TextChanged;
            // 
            // realtimeChatDetailForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(customGroupBox1);
            Name = "realtimeChatDetailForm";
            Text = "realtimeChatDetailForm";
            FormClosing += realtimeChatDetailForm_FormClosing;
            Leave += realtimeChatDetailForm_Leave;
            customGroupBox1.ResumeLayout(false);
            customGroupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private ListBox listBoxChatBox;
        private CustomButtonStyle buttonSendMessage;
        private CustomGroupBox customGroupBox1;
        private TextBox textBoxInputMessage;
    }
}